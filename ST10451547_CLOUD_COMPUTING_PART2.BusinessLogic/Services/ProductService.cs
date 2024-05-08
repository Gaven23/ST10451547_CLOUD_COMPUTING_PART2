using ST10451547_CLOUD_COMPUTING_PART2.Data;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services
{
    public class ProductService
    {
        private readonly IDataStore _dataStore;
        public ProductService(IDataStore dataStore)
        {
            _dataStore = dataStore;

        }

        public async Task AddProductAsync(Product product)
        {
            await _dataStore.SaveProdutAsync(product);
        }
    }

}
