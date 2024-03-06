using Newtonsoft.Json;
using RiaMoneyTransfer.ApplicationCore.Entities;
using RiaMoneyTransfer.ApplicationCore.Helpers;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Infrastructure;

namespace RiaMoneyTransfer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<Customer[]> GetAsync()
        {
            if (!Path.Exists(Config.ConnectionString))
                return [];

            var file = await File.ReadAllTextAsync(Config.ConnectionString);
            var ret = JsonConvert.DeserializeObject<Customer[]>(file);

            if (ret is null)
                return [];

            return ret;
        }

        public async Task PostAsync(Customer[] customers)
        {
            var json = JsonConvert.SerializeObject(customers);
            await File.WriteAllTextAsync(Config.ConnectionString, json);
        }
    }
}