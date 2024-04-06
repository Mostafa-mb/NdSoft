using Application.DTOs;
using MediatR;

namespace Application.Features.Product.Queries.GetProductDetail
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsDto>
    {
        public int Id { get; set; }

    }
}
