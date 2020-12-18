using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Contracts.V1;
using api.Contracts.V1.ResponseModels;
using api.Contracts.V1.ResponseModels.Products;
using api.CQRS.Products.Commands.CreateProducts;
using api.CQRS.Products.Commands.UpdateProducts;
using api.CQRS.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.CQRS.Products.Queries;

namespace api.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Sale,WarehouseKeeper,WarehouseKeeperManager,Boss")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin,Boss")]
        [HttpPost(ApiRoutes.Product.Create)]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                productResponse => Created("", new Response<ProductResponse>(
                    productResponse
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpGet(ApiRoutes.Product.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query)
        {
            var result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                data => Ok(new Response<PagedResponse<ProductResponse>>(
                    data
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpGet(ApiRoutes.Product.GetBySku)]
        public async Task<IActionResult> GetBySku([FromRoute] string sku)
        {
            var query = new GetProductBySkuQuery(sku);
            var result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                productRespons => Ok(new Response<ProductResponse>(
                    productRespons
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [Authorize(Roles = "Admin,Boss")]
        [HttpPut(ApiRoutes.Product.Update)]
        public async Task<IActionResult> Update(
            [FromRoute] int productId,
            [FromBody] UpdateProductCommand command)
        {
            command.Id = productId;
            var result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                productResponse => NoContent(),
                exp =>
                {
                    throw exp;
                }
            );
        }
    }
}
