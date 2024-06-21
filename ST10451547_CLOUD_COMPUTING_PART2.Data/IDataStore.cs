using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.Data
{
    public interface IDataStore
    {
        Task<User> GetUserAsync(User user,CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task SaveUserAsync(User user);
        Task SaveProdutAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task SaveLineItemAsync(LineItem lineItem);
        Task<IEnumerable<Product>> GetProdutAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<LineItem>> GetLineItemAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken cancellationToken = default);
        Task SaveRoleAsync(Role role);
        Task SaveOrdersAsync(Order orders);
        Task UpdateOrderAsync(Order orders);
    }
}
