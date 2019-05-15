using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.ValueObjects
{
    //Value Object
    public struct Amount
    {
        public Currency Currency { get; set; }
        public Decimal Value { get; set; }
    }
}
