using ContactManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Data
{
    public interface IContactRepository
    {
        IEnumerable<Client> GetAllClients(bool includeAddresses);
        Client GetClientById(int id);

        void AddEntity(object entity);
        bool SaveAll();
    }
}
