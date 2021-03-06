﻿using AmazingBank.DomainModel.Entities;
using AmazingBank.DomainModel.Interfaces.Repositories;
using AmazingBank.Infra.DataAccess.Contexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.Infra.DataAccess.Repositories
{
    public class AmountTransactionEntityFrameworkRepository : IAmountTransactionRepository
    {
        private readonly AmazingBankContext _amazingBankContext;

        public AmountTransactionEntityFrameworkRepository(AmazingBankContext amazingBankContext)
        {
            _amazingBankContext = amazingBankContext;
        }

        public void Create(AmountTransaction transaction)
        {
            _amazingBankContext.Add<AmountTransaction>(transaction);
        }

        public AmountTransaction Read(Guid id)
        {
            return _amazingBankContext.AmountTransactions
                .SingleOrDefault(t => t.Id.Equals(id));
        }
    }
}
