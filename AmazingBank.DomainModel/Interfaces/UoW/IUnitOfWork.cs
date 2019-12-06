using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazingBank.DomainModel.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}
