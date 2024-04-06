using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var selectedproduct = _mapper.Map<Domain.Entities.Product>(request.productDto);
            await _productRepository.DeleteAsync(selectedproduct);
            return selectedproduct;
        }
    }
}
