using AmazingBank.DomainModel.Entities;
using AmazingBank.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingBank.DomainService
{
    public class ClientService
    {
        private IClientRepository _clientRepository;
        void AddClient(Client client)
        {
            _clientRepository.Create(client);
        }

        IEnumerable<Client> SearchByName(string name)
        {
            return _clientRepository.ReadAll()
                .Where(c => c.Name.ToLower()
                .Contains(name.ToLower()));
        }
    }
}
