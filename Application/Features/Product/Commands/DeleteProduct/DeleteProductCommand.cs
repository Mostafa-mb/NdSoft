using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public ProductDetailsDto productDto { get; set; }
    }
}
