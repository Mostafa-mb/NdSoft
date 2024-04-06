using Application.DTOs;
using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetProductDetail
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var selectedProduct = await _productRepository.GetByIdAsync(request.Id);
            if (selectedProduct != null)
            {
                throw new Exception("Product Not Found!");
            }

            var returnProduct = _mapper.Map<ProductDetailsDto>(selectedProduct);
            return returnProduct;
        }
    }
}
