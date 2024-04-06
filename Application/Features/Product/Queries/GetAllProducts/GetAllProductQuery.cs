using Application.DTOs;
using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductQuery : IRequest<List<ProductDetailsDto>>
    {

    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductDetailsDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<List<ProductDetailsDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var query = await _productRepository.GetAllAsync();
            var data = _mapper.Map<List<ProductDetailsDto>>(query);
            return data;
        }
    }
}
