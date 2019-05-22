using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.Entities
{
    public class Client : EntityBase<Guid>
    {
        public string Name { get; set; }
        public DateTime  Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
    }
}
