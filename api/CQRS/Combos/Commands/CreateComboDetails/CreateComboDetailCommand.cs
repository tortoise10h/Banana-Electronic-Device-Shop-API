using api.Common.Enums;
using api.Contracts.V1.Exceptions;
using api.Contracts.V1.ResponseModels.Combos;
using api.Entities;
using api.Helpers;
using api.Services;
using AutoMapper;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.CQRS.Combos.Commands.CreateComboDetails
{
    public class CreateComboDetailCommand : IRequest<Result<ComboDetailResponse>>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateComboDetailHandler : IRequestHandler<CreateComboDetailCommand, Result<ComboDetailResponse>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateComboDetailHandler(
            DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        Task<Result<ComboDetailResponse>> IRequestHandler<CreateComboDetailCommand, Result<ComboDetailResponse>>.Handle(CreateComboDetailCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
