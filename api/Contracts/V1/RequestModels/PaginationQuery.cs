using api.Common.Enums;
using System.Collections.Generic;

namespace api.Contracts.V1.RequestModels
{
    public class PaginationQuery
    {
        public int Page { get; set; } = PaginationDefault.Page;
        public int Limit { get; set; } = PaginationDefault.Limit;
        public string SortName { get; set; } = PaginationDefault.SortName;
        public bool IsAscending { get; set; } = PaginationDefault.IsAscending;
        public Dictionary<string, string> Filters { get; set; }
        public Dictionary<string, string> FilterConditions { get; set; }
    }
}