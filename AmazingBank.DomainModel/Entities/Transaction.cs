using AmazingBank.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.Entities
{
    public class Transaction : EntityBase<Guid>
    {
        public DateTime DateTime { get; set; }
        public Account Origin { get; set; }
        public Account Destiny { get; set; }
        public Amount Amount { get; set; }
    }
}
