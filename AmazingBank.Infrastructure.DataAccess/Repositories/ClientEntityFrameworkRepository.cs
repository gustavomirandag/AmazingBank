using AmazingBank.DomainModel.Entities;
using AmazingBank.DomainModel.Interfaces.Repositories;
using AmazingBank.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazingBank.Infrastructure.DataAccess.Repositories
{
    public class ClientEntityFrameworkRepository : IClientRepository
    {

        private readonly AmazingBankContext _db;
        
        public ClientEntityFrameworkRepository(AmazingBankContext db)
        {
            _db = db;
        }

        public void Create(Client entity)
        {
            _db.Clients.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
            _db.SaveChanges();
        }

        public IEnumerable<Client> FindByName(string name)
        {
            //_db.Clients.FromSql($"Select * from Clients where Name LIKE %{name}%");

            return _db.Clients
                .Where(cli => EF.Functions
                .Like(cli.Name, $"%{name}%"));
        }

        public Client Read(Guid id)
        {
            return _db.Clients.Find(id);
        }

        public IEnumerable<Client> ReadAll()
        {
            return _db.Clients;
        }

        public void Update(Client entity)
        {
            _db.Clients.Update(entity);
            _db.SaveChanges();
        }
    }
}
