using Domain.Entities;

namespace Application.IRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long id);
        Task<bool> Exist(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<Product> DeleteAsync(Product product);

    }
}
