using AmazingBank.DomainModel.Entities;
using AmazingBank.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingBank.Infra.DataAccess.Repositories
{
    public class ClientMemDbRepository : IClientRepository
    {
        private static readonly List<Client> _set = new List<Client>();

        public void Create(Client entity)
        {
            _set.Add(entity);
        }

        public void Delete(Guid id)
        {
            _set.Remove(Read(id));
        }

        public IEnumerable<Client> FindByName(string name)
        {
            return ReadAll()
                .Where(cli => cli.Name.ToLower()
                    .Contains(name.ToLower()));
        }

        public Client Read(Guid id)
        {
            return _set.Find(e => e.Id == id);
        }

        public IEnumerable<Client> ReadAll()
        {
            return _set;
        }

        public void Update(Client entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
}
