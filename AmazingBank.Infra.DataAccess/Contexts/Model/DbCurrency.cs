using AmazingBank.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.Infra.DataAccess.Contexts.Model
{
    public class DbCurrency
    {
        public Guid Id { get; set; }
        public Currency Currency { get; set; }
    }
}
