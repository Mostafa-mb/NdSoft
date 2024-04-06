using Application.DTOs;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public ProductDetailsDto productDto { get; set; }
    }


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
            var newProduct = _mapper.Map<Product>(request.productDto);
            return newProduct;
        }
    }
}
