using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Categories;
using api.Contracts.V1.ResponseModels.Combos;
using api.Contracts.V1.ResponseModels.Products;
using api.Helpers;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Queries
{
    public class GetComboByIdQuery : IRequest<Result<ComboResponse>>
    {
        public GetComboByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }

    public class GetComboByIdHandler : IRequestHandler<GetComboByIdQuery, Result<ComboResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetComboByIdHandler(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<ComboResponse>> Handle(
            GetComboByIdQuery request,
            CancellationToken cancellationToken)
        {
            var combo = await _context.Combos
                .Include(x => x.ComboDetails)
                    .ThenInclude(cd => cd.ProductId)
                .SingleOrDefaultAsync(
                    x => x.Id == request.Id);

            if (combo == null)
            {
                return new Result<ComboResponse>(
                    new NotFoundException()
                );
            }

            return new Result<ComboResponse>(
                _mapper.Map<ComboResponse>(combo)
            );
        }
    }
}
