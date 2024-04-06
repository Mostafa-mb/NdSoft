using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.AddProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Domain.Entities.Product>(request.productDto);
            newProduct = await _productRepository.Add(newProduct);
        }
    }
}
