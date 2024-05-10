using Microsoft.EntityFrameworkCore;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.Data.DataStore
{
    partial class DataStore
    {
        public async Task<IEnumerable<Product>> GetProdutAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Product.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
           return await _dbContext.User.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task SaveProdutAsync(Product product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Supplier = product.Supplier,
            };

            _dbContext.Product.Add(newProduct);

            await _dbContext.SaveChangesAsync();
        }

        public Task SaveRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task SaveUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
