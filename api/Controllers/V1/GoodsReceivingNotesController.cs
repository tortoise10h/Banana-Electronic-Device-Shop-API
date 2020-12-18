using System.Collections.Generic;
using System.Threading.Tasks;
using api.Contracts.V1;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.GoodsReceivingNotes;
using api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingDetails;
using api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingNotes;
using api.CQRS.GoodsReceivingNotes.Commands.DeleteGoodsReceivingNotes;
using api.CQRS.GoodsReceivingNotes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.V1
{
    public class GoodsReceivingNotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoodsReceivingNotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.GoodsReceivingNotes.CreateGoodsReceivingNotes)]
        public async Task<IActionResult> Create([FromBody] CreateGoodsReceivingNotesCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                response => Created("", new Response<GoodsReceivingNoteResponse>(
                    response
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpDelete(ApiRoutes.GoodsReceivingNotes.DeleteGoodsReceivingNotes)]
        public async Task<IActionResult> Delete(
            [FromRoute] int goodsReceivingNoteId
        )
        {
            var delete = new DeleteGoodsReceivingNotesCommand(goodsReceivingNoteId);
            var result = await _mediator.Send(delete);

            return result.Match<IActionResult>(
                response => NoContent(),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpGet(ApiRoutes.GoodsReceivingNotes.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllGoodsReceivingNotesQuery query)
        {
            var result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                data => Ok(new Response<PagedResponse<GoodsReceivingNoteResponse>>(
                    data
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpGet(ApiRoutes.GoodsReceivingNotes.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int goodsReceivingNoteId)
        {
            var query = new GetGoodsReceivingNoteByIdQuery(goodsReceivingNoteId);
            var result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                response => Ok(new Response<GoodsReceivingNoteResponse>(
                    response
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpPost(ApiRoutes.GoodsReceivingNotes.CreateGoodsReceivingDetails)]
        public async Task<IActionResult> CreateGoodsReceivingDetails
        (
            [FromBody] CreateGoodsReceivingDetailsCommand command
        )
        {
            var result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                response => Created("", new Response<List<GoodsReceivingDetailResponse>>(
                    response
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }
    }
}