using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParasutIntegration.Features.Product.Commands;
using ParasutIntegration.Features.Product.Queries;
using ParasutIntegration.Models.Product;
using ParasutIntegration.Util;

namespace ParasutIntegration.Controllers
{
    [Route("parasutApi/product")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProductContact()
        {
            var products = await _mediator.Send(new GetProductsQuery(id: 0));
            return Ok(products);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductContactById(int id)
        {
            var products = await _mediator.Send(new GetProductsQuery(id));
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParasutProductModel model)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel("", model);
            var response = await _mediator.Send(new ProductOperationCommands(parameters, HttpMethod.Post));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ParasutProductModel model, string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, model);
            var response = await _mediator.Send(new ProductOperationCommands(parameters, HttpMethod.Put));
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var parameters = ParasutRequestFactory.CreateRequestModel(id, new ParasutProductModel());
            var response = await _mediator.Send(new ProductOperationCommands(parameters, HttpMethod.Delete));
            return Ok(response);
        }
    }
}
