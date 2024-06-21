using ST10451547_CLOUD_COMPUTING_PART2.Data;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services
{

    public class CheckOutService
    {
        private readonly IDataStore _dataStore;
        public CheckOutService(IDataStore dataStore)
        {
            _dataStore = dataStore;

        }

        public async Task AddProductAsync(Order order)
        {
            await _dataStore.SaveOrdersAsync(order);
        }
    }
}