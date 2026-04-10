using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMApp.Database;
using CRMApp.Models;

namespace CRMApp.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository()
        {
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            var existing = await _context.Clients.FindAsync(client.Id);
            if (existing != null)
            {
                existing.Name = client.Name;
                existing.Company = client.Company;
                existing.Phone = client.Phone;
                existing.Email = client.Email;
                existing.DealsCount = client.DealsCount;
                existing.Status = client.Status;
            }
        }

        public async Task DeleteClientAsync(Client client)
        {
            var existing = await _context.Clients.FindAsync(client.Id);
            if (existing != null)
            {
                _context.Clients.Remove(existing);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}