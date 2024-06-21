using ST10451547_CLOUD_COMPUTING_PART2.Data;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services
{

    public class OrderService
    {
        private readonly IDataStore _dataStore;
        public OrderService(IDataStore dataStore)
        {
            _dataStore = dataStore;

        }

        public async Task AddOrdersAsync(Order orders)
        {
            await _dataStore.SaveOrdersAsync(orders);
        }

        public async Task UpdateOrdersAsync(Order orders)
        {
            await _dataStore.UpdateOrderAsync(orders);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken cancellationToken)
        {
            return await _dataStore.GetOrdersAsync(cancellationToken);
        }

    }
}