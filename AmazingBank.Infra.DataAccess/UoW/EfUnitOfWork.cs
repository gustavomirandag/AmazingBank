using AmazingBank.DomainModel.Interfaces.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazingBank.Infra.DataAccess.UoW
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public EfUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        /// <summary>
        /// Save changes to database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public int Commit()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Save changes to database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
