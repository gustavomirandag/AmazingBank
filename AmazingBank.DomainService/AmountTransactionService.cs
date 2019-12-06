using AmazingBank.DomainModel.Entities;
using AmazingBank.DomainModel.Interfaces.Repositories;
using AmazingBank.DomainModel.Interfaces.UoW;
using AmazingBank.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainService
{
    public class AmountTransactionService
    {
        private readonly IAmountTransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AmountTransactionService(IAmountTransactionRepository transactionRepository,
            IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public void TransferAmount(Account origin, Account destiny, Amount amount)
        {
            _unitOfWork.BeginTransaction();

            try
            {
                //Retira a quantidade de Amount da conta de origem
                origin = _accountRepository.Read(origin.Id);
                origin.Amount -= amount;
                _accountRepository.Update(origin);

                //Coloca a quantidade de Amount na conta de destino
                destiny = _accountRepository.Read(destiny.Id);
                destiny.Amount += amount;
                _accountRepository.Update(destiny);

                //Crio a transação
                _transactionRepository.Create(new AmountTransaction
                {
                    Id = Guid.NewGuid(),
                    Origin = origin,
                    Destiny = destiny,
                    Amount = amount,
                    DateTime = DateTime.Now
                });

                //Save Changes
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
            }

        }
    }
}
