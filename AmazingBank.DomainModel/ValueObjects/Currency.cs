using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.ValueObjects
{
    //Value Object
    public struct Currency
    {
        //Exemplos de Code: USD, BRL, BTC etc.
        public string Code { get; set; }
    }
}
