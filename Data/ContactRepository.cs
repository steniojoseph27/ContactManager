using ContactManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsDbContext _context;

        public ContactRepository(ContactsDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Client> GetAllClients(bool includeAddresses)
        {
            if (includeAddresses)
            {
                return _context.Clients
                    .Include(c => c.Addresses)
                    .ToList();
            }
            else
            {
                return _context.Clients
                    .ToList();
            }
        }

        public Client GetClientById(int id)
        {
            return _context.Clients
                .Include(c => c.Addresses)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void AddEntity(object entity)
        {
            _context.Add(entity);
        }
	}
}
