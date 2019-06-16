using AmazingBank.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmazingBank.DomainModel.Entities
{
    public class Account : EntityBase<Guid>
    {
        public Client Client { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public Amount Amount { get; set; }

        public Account()
        {
            Documents = new List<Document>();
        }
    }
}
