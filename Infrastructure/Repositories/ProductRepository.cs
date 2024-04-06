using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            var selectedProduct =await _context.Products.FindAsync(product.Id);
            if(selectedProduct == null)
            {
                return null;
            }
            _context.Products.Remove(selectedProduct);
            await _context.SaveChangesAsync();
            return selectedProduct;
        }

        public async Task<bool> Exist(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
            if(product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            var Existingproduct = await _context.Products.FirstOrDefaultAsync(p=>p.Id == product.Id);
            if(Existingproduct == null)
            {
                return null;
            }
            
            Existingproduct.ManufactureEmail = product.ManufactureEmail;
            Existingproduct.ManufacturePhone = product.ManufacturePhone;
            Existingproduct.Name = product.Name;
            Existingproduct.ProductDate = product.ProductDate;

            await _context.SaveChangesAsync();

            return product;
        }
    }
}
