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

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void AddClient(Client client)
        {
            _clientRepository.Create(client);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.ReadAll();
        }

        public Client GetClientById(Guid id)
        {
            return _clientRepository.Read(id);
        }

        public IEnumerable<Client> SearchByName(string name)
        {
            return _clientRepository.ReadAll()
                .Where(c => c.Name.ToLower()
                .Contains(name.ToLower()));
        }
    }
}
