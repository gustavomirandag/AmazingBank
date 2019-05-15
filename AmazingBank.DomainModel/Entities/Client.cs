using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.Entities
{
    public class Client : EntityBase<Guid>
    {
        public string Name { get; set; }
    }
}
