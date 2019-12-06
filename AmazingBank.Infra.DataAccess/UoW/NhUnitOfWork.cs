using AmazingBank.DomainModel.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazingBank.Infra.DataAccess.UoW
{
    public class NhUnitOfWork : IUnitOfWork
    {
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
