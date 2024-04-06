using Application.DTOs;
using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Commands.DeleteProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Queries.GetAllProducts;
using Application.Features.Product.Queries.GetProductDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDetailsDto>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDetailsDto>> GetproductDetails(int id)
        {
            var product = _mediator.Send(new GetProductDetailsQuery { Id = id });
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody]ProductDetailsDto product)
        {
            var result = _mediator.Send(new UpdateProductCommand { productDto = product });
            return Ok(result);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody]ProductDetailsDto updateProduct)
        {
            var result = _mediator.Send(new UpdateProductCommand { productDto = updateProduct });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(ProductDetailsDto selectedProduct)
        {
            var command = _mediator.Send(new DeleteProductCommand { productDto = selectedProduct });
            return NoContent();
        }

    }
}
