using System.Collections.Generic;
using System.Threading.Tasks;
using CRMApp.Models;

namespace CRMApp.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClientsAsync();
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Client client);
        Task SaveChangesAsync();
    }
}