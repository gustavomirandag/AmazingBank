using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.Entities
{
    public class Document : EntityBase<Guid>
    {
        public string Url { get; set; }
    }
}
