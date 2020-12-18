using System.Threading.Tasks;
using api.Contracts.V1;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Categories;
using api.CQRS.Categories.Commands.CreateCategories;
using api.CQRS.Categories.Commands.DeleteCategories;
using api.CQRS.Categories.Commands.UpdateCategories;
using api.CQRS.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.V1
{
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(ApiRoutes.Categories.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                data => Created("", new Response<CategoryResponse>(
                    data
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpGet(ApiRoutes.Categories.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            return result.Match<IActionResult>(
                data => Ok(new Response<PagedResponse<CategoryResponse>>(
                    data
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(ApiRoutes.Categories.Update)]
        public async Task<IActionResult> Update(
            [FromRoute] int categoryId,
            [FromBody] UpdateCategoryCommand command)
        {
            command.Id = categoryId;
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
        [HttpDelete(ApiRoutes.Categories.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int categoryId)
        {
            var deleteCommand = new DeleteCategoryCommand(categoryId);
            var result = await _mediator.Send(deleteCommand);
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
