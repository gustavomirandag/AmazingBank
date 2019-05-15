using AmazingBank.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.Interfaces.Repositories
{
    public interface IRepository<T,EntityId> where T : EntityBase<EntityId>
    {
        void Create(T entity);
        T Read(EntityId id);
        IEnumerable<T> ReadAll();
        void Update(T entity);
        void Delete(EntityId id);
    }
}
