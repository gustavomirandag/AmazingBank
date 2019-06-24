using AmazingBank.DomainModel.Entities;
using AmazingBank.Infra.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.Infra.DataAccess.Repositories
{
    public class AccountEntityFrameworkRepository
    {
        private readonly AmazingBankContext _db;

        public AccountEntityFrameworkRepository(AmazingBankContext db)
        {
            _db = db;
        }

        public void Create(Account entity)
        {
            _db.Accounts.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
            _db.SaveChanges();
        }

        public Account Read(Guid id)
        {
            return _db.Accounts.Find(id);
        }

        public IEnumerable<Account> ReadAll()
        {
            return _db.Accounts;
        }

        public void Update(Account entity)
        {
            _db.Accounts.Update(entity);
            _db.SaveChanges();
        }

    }
}
