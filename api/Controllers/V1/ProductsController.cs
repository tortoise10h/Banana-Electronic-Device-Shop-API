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
using src.CQRS.QuantityLogs.Queries;

namespace api.Controllers.V1
{
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet(ApiRoutes.Product.StatisticQuantityLogByProductId)]
        public async Task<IActionResult> StatisticQuantityLogByProductId(
            [FromRoute] int productId,
            [FromQuery] StatisticQuantityLogOfProductQuery query)
        {
            query.ProductId = productId;
            var result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                data => Ok(new Response<PagedResponse<QuantityLogResponse>>(
                    data
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [HttpGet(ApiRoutes.Product.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int productId)
        {
            var query = new GetProductByIdQuery(productId);
            var result = await _mediator.Send(query);

            return result.Match<IActionResult>(
                productResponse => Ok(new Response<ProductResponse>(
                    productResponse
                )),
                exp =>
                {
                    throw exp;
                }
            );
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete(ApiRoutes.Product.Delete)]
        public async Task<IActionResult> Delete(
            [FromRoute] int productId)
        {
            DeleteProductCommand command = new DeleteProductCommand(productId);
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
