using AmazingBank.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace AmazingBank.DomainModel.Interfaces.Repositories
{
    public interface IAmountTransactionRepository
    {
        void Create(AmountTransaction transaction);
        AmountTransaction Read(Guid id);
    }
}
