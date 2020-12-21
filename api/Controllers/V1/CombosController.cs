using System.Collections.Generic;
using System.Threading.Tasks;
using api.Contracts.V1;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Combos;
using api.CQRS.Categories.Commands.DeleteCategories;
using api.CQRS.Combos.Commands.BulkCreateComboDetails;
using api.CQRS.Combos.Commands.CreateCombos;
using api.CQRS.Combos.Commands.DeleteComboDetails;
using api.CQRS.Combos.Commands.DeleteCombos;
using api.CQRS.Combos.Commands.UpdateComboDetails;
using api.CQRS.Combos.Commands.UpdateCombos;
using api.CQRS.Combos.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.V1
{
    public class CombosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CombosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(ApiRoutes.Combos.Create)]
        public async Task<IActionResult> Create([FromBody] CreateComboCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                data => Created("", new Response<ComboResponse>(
                    data
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpGet(ApiRoutes.Combos.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCombosQuery query)
        {
            var result = await _mediator.Send(query);
            return result.Match<IActionResult>(
                data => Ok(new Response<PagedResponse<ComboResponse>>(
                    data
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(ApiRoutes.Combos.Update)]
        public async Task<IActionResult> Update(
            [FromRoute] int comboId,
            [FromBody] UpdateComboCommand command)
        {
            command.Id = comboId;
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                data => NoContent(),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpGet(ApiRoutes.Combos.GetById)]
        public async Task<IActionResult> GetById(
            [FromRoute] int comboId)
        {
            GetComboByIdQuery query = new GetComboByIdQuery(comboId);
            var result = await _mediator.Send(query);
            return result.Match<IActionResult>(
                data => Ok(new Response<ComboResponse>(data)),
                exp =>
                {
                    throw exp;
                }
            );
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete(ApiRoutes.Combos.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int comboId)
        {
            var deleteCommand = new DeleteComboCommand(comboId);
            var result = await _mediator.Send(deleteCommand);
            return result.Match<IActionResult>(
                data => NoContent(),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(ApiRoutes.Combos.AddProductsToCombo)]
        public async Task<IActionResult> AddProductsToCombo(
            [FromRoute] int comboId,
            [FromBody] BulkCreateComboDetailCommand command)
        {
            command.ComboId = comboId;
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                data => Created("", new Response<List<ComboDetailResponse>>(
                    data
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(ApiRoutes.Combos.UpdateProductInCombo)]
        public async Task<IActionResult> UpdateProductInCombo(
            [FromRoute] int comboId,
            [FromRoute] int comboDetailId,
            [FromBody] UpdateComboDetailCommand command)
        {
            command.Id = comboDetailId;
            command.ComboId = comboId;
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                data => NoContent(),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(ApiRoutes.Combos.DeleteProductInCombo)]
        public async Task<IActionResult> DeleteProductInCombo(
            [FromRoute] int comboId,
            [FromRoute] int comboDetailId)
        {
            DeleteComboDetailCommand command = new DeleteComboDetailCommand(comboDetailId);
            command.ComboId = comboId;
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                data => NoContent(),
                exp =>
                {
                    throw exp;
                }
            );
        }
    }
}
