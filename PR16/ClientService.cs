using CrmDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrmDemo.Services
{
    public class ClientService
    {
        public Task<List<ClientModel>> LoadClientsAsync()
        {
            return Task.Run(async () =>
            {
                await Task.Delay(1500);
                return new List<ClientModel>
                {
                    new ClientModel { FullName = "Иванов Иван", Phone = "+375291111111" },
                    new ClientModel { FullName = "Петров Петр", Phone = "+375292222222" }
                };
            });
        }
    }
}