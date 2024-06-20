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

        public async Task AddLineItem(LineItem lineItem)
        {
            await _dataStore.SaveLineItemAsync(lineItem);
        }

        public async Task<IEnumerable<LineItem>> GetLineItemAsync(CancellationToken cancellationToken)
        {
            return await _dataStore.GetLineItemAsync(cancellationToken);
        }
        public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await _dataStore.GetProdutAsync(cancellationToken);
        }
    }
}
