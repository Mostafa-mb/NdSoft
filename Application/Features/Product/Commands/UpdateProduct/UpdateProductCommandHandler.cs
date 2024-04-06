using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Domain.Entities.Product>(request.productDto);
            var result = _productRepository.Update(newProduct);
            return result;
        }
    }
}
