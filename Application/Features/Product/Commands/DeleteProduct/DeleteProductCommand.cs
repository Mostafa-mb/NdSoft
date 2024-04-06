using Application.DTOs;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public ProductDetailsDto productDto { get; set; }
    }


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
            var selectedproduct = _mapper.Map<Product>(request.productDto);
            await _productRepository.DeleteAsync(selectedproduct);
            return selectedproduct;
        }
    }
}
