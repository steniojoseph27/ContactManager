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

		//
		public Client Create(Client client)
		{
			_context.Clients.Add(client);
			_context.SaveChanges();
			
			return client;
		}

		public Client Edit(int id)
		{
			var client = _context.Clients.FirstOrDefault(c => c.Id == id);

			if (client == null)
				return null;

			return client;
		}


		public Client Edit(Client client)
		{
			_context.Clients.Update(client);
			_context.SaveChanges();
			
			return client;
		}


		public Client Delete(int id)
		{
			var client = _context.Clients.FirstOrDefault(c => c.Id == id);

			if (client == null)
				return null;

			return client;
		}

		public Client Destroy(int id)
		{
			var client = _context.Clients.FirstOrDefault(c => c.Id == id);

			if (client == null)
				return null;

			_context.Clients.Remove(client);
			_context.SaveChangesAsync();

			return client;
		}
	}
}
