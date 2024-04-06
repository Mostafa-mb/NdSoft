using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public ProductDetailsDto productDto { get; set; }
    }
}
