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

        public async Task<IEnumerable<LineItem>> GetLineItemAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.LineItem.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken cancellationToken = default)
        {
            var orders =  await _dbContext.Order.AsNoTracking().ToListAsync(cancellationToken);

            return orders;  
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

        public async Task UpdateProductAsync(Product product)
        {
            // Retrieve the existing product from the database
            var existingProduct = await _dbContext.Product.FindAsync(product.ProductId);

            if (existingProduct == null)
            {
                throw new Exception("Product not found.");
            }

            // Update the existing product's properties
            existingProduct.Name = product.Name;
            existingProduct.Supplier = product.Supplier;

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }



        public async Task SaveLineItemAsync(LineItem lineItem)
        {
            var newlineItem1 = new LineItem
            {
                Price = lineItem.Price,
                Quantity = lineItem.Quantity,
                ProductId = lineItem.ProductId,
            };

            _dbContext.LineItem.Add(newlineItem1);

            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateOrderAsync(Order order)
        {
            // Retrieve the existing product from the database
            var existingProduct = await _dbContext.Order.FindAsync(order.OrderID);

            if (existingProduct == null)
            {
                throw new Exception("Order not found.");
            }

            existingProduct.FirstName = order.FirstName;
            existingProduct.LastName = order.LastName;
            existingProduct.CardNumber = order.CardNumber;
            existingProduct.CVV = order.CVV;

            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveOrdersAsync(Order order)
        {
            // Generate a user-friendly order code
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var randomPart = GenerateRandomString(6);

            try
            {
                // Create a new order instance
                var newOrder = new Order
                {
                    UserFriendlyOrderCode = $"{datePart}-{randomPart}",
                    TotalPrice = order.TotalPrice,
                    TotalQuantity = order.TotalQuantity,
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    CardNumber = order.CardNumber,
                    CVV = order.CVV,
                    // Add other necessary fields here
                };

                // Add the new order to the DbSet
                _dbContext.Order.Add(newOrder);

                // Save changes asynchronously
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Handle database update specific exceptions
                // Log exception details here if using a logging framework
                throw new Exception("An error occurred while updating the database. Please try again.", dbEx);
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                // Log exception details here if using a logging framework
                throw new Exception("An unexpected error occurred while saving the order.", ex);
            }
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


        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
