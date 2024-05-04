using ST10451547_CLOUD_COMPUTING_PART2.Data;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services
{
    public class UserService
    {
        private readonly IDataStore _dataStore;
        public UserService(IDataStore dataStore)
        {
            _dataStore = dataStore;

        }

        public async Task<IEnumerable<User>> GetVehiclesAsync(CancellationToken cancellationToken = default)
        {
            return await _dataStore.GetUsersAsync(cancellationToken);
        }

    }
}