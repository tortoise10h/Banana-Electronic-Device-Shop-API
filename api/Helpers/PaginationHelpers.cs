using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using api.Common.Enums;
using api.Contracts.V1.RequestModels;
using api.Contracts.V1.ResponseModels;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using api.Contracts.V1.Exceptions;

namespace api.Helpers
{
    public interface IPaginationHelpers
    {
        Task<PagedResponse<TResponse>> Paginate<TEntity, TResponse>(
            IQueryable<TEntity> queryable,
            PaginationQuery query);
    }

    public class PaginationHelpers : IPaginationHelpers
    {
        private readonly IMapper _mapper;

        public PaginationHelpers(IMapper mapper)
        {
            _mapper = mapper;
        }

        private PagedResponse<TResponse> CreatePaginatedResponse<TEntity, TResponse>(
            PaginationQuery query,
            List<TEntity> entities,
            int total)
        {
            int totalPage = (int)Math.Ceiling((double)total / query.Limit);

            return new PagedResponse<TResponse>
            {
                Data = _mapper.Map<IEnumerable<TResponse>>(entities),
                CurrentPage = query.Page,
                PageSize = query.Limit,
                TotalPages = totalPage == 0 ? 1 : totalPage,
                TotalItems = total
            };
        }
        public async Task<PagedResponse<TResponse>> Paginate<TEntity, TResponse>(
            IQueryable<TEntity> queryable,
            PaginationQuery query)
        {
            int skip = (query.Page - 1) * query.Limit;

            queryable = CustomSortQuery<TEntity>(queryable, query.SortName, query.IsAscending);
            queryable = CustomFilterQuery<TEntity>(queryable, query.Filters, query.FilterConditions);

            var entities = await queryable
                .Skip(skip)
                .Take(query.Limit)
                .ToListAsync();
            var totalEntities = await queryable.CountAsync();

            return CreatePaginatedResponse<TEntity, TResponse>(
                query, entities, totalEntities);
        }

        public IQueryable<TEntity> CustomSortQuery<TEntity>(
            IQueryable<TEntity> queryable,
            string sortName,
            bool isAscending
        )
        {
            if (isAscending)
            {
                queryable = queryable
                    .OrderBy($"{sortName}");
            }
            else
            {
                queryable = queryable
                    .OrderBy($"{sortName} desc");
            }

            return queryable;
        }
        public IQueryable<TEntity> CustomFilterQuery<TEntity>(
            IQueryable<TEntity> queryable,
            Dictionary<string, string> filters,
            Dictionary<string, string> filterConditions
        )
        {
            if (filters != null && filters.Count > 0)
            {
                foreach (KeyValuePair<string, string> entry in filters)
                {
                    string filterOperator = "";
                    if (filterConditions != null && filterConditions.Count > 0)
                    {
                        filterConditions.TryGetValue(entry.Key, out filterOperator);
                    }

                    switch (filterOperator)
                    {
                        case "not":
                            {
                                queryable = queryable
                                    .Where($"{entry.Key} != {entry.Value}");
                                break;
                            }
                        case "like":
                            {
                                queryable = queryable
                                    .Where($"{entry.Key}.Contains({entry.Value})");
                                break;
                            }
                        case "=":
                            {
                                queryable = queryable
                                    .Where($"{entry.Key} = {entry.Value}");
                                break;
                            }
                        case ">":
                            {
                                queryable = queryable
                                    .Where($"{entry.Key} > {entry.Value}");
                                break;
                            }
                        case "<":
                            {
                                queryable = queryable
                                    .Where($"{entry.Key} < {entry.Value}");
                                break;
                            }
                        case ">=":
                            {
                                queryable = queryable
                                    .Where($"{entry.Key} >= {entry.Value}");
                                break;
                            }
                        case "<=":
                            {
                                queryable = queryable
                                    .Where($"{entry.Key} <= {entry.Value}");
                                break;
                            }
                        case "in":
                            {
                                string inRegex = @"^[^\,]+(\,[^\,]+)*$";
                                var match = Regex.Match(entry.Value, inRegex, RegexOptions.IgnoreCase);
                                if (!match.Success)
                                {
                                    throw new BadRequestException(new ApiError("The correct value when using in dynamic filter is 'value,value,value,value'"));
                                }

                                string[] valArr = entry.Value.Split(",");
                                string values = "";
                                int c;
                                bool isInt = Int32.TryParse(valArr[0], out c);

                                if (!isInt)
                                {
                                    foreach (var str in valArr)
                                    {
                                        values += $"\"{str}\",";
                                    }
                                    values = values.Remove(values.Length - 1);
                                }
                                else
                                {
                                    values = entry.Value;
                                }

                                queryable = queryable
                                    .Where($"{entry.Key} IN ({values})");
                                break;
                            }
                        case "notin":
                            {
                                string inRegex = @"^[^\,]+(\,[^\,]+)*$";
                                var match = Regex.Match(entry.Value, inRegex, RegexOptions.IgnoreCase);
                                if (!match.Success)
                                {
                                    throw new BadRequestException(new ApiError("The correct value when using not in dynamic filter is 'value,value,value,value'"));
                                }

                                string[] valArr = entry.Value.Split(",");
                                string values = "";
                                int c;
                                bool isInt = Int32.TryParse(valArr[0], out c);

                                if (!isInt)
                                {
                                    foreach (var str in valArr)
                                    {
                                        values += $"\"{str}\",";
                                    }
                                    values = values.Remove(values.Length - 1);
                                }
                                else
                                {
                                    values = entry.Value;
                                }

                                queryable = queryable
                                    .Where($"!({entry.Key} IN ({values}))");
                                break;
                            }
                        case "between":
                            {
                                string requestValue = entry.Value.ToString();
                                string betweenRegex = @"^([^\,]+\,[^\,]+)$";
                                var match = Regex.Match(
                                    requestValue, betweenRegex, RegexOptions.IgnoreCase);
                                if (!match.Success)
                                {
                                    throw new BadRequestException(new ApiError("The correct value when using between dynamic filter is 'value,value'"));
                                }

                                var values = requestValue.Split(",");
                                queryable = queryable
                                    .Where($"{entry.Key} >= \"{values[0]}\" && {entry.Key} <= \"{values[1]}\"");
                                break;
                            }
                        default:
                            {
                                queryable = queryable
                                    .Where($"{entry.Key} = {entry.Value}");
                                break;
                            }
                    }
                }
            }

            return queryable;
        }
    }
}
