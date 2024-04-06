using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Commands.AddProduct
{
    public class CreateProductCommand : IRequest
    {
        public ProductDetailsDto productDto { get; set; }
    }
}
