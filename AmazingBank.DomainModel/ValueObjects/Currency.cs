using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.ValueObjects
{
    //Value Object
    public struct Currency : IComparable<Currency>
    {
        //Exemplos de Code: USD, BRL, BTC etc.
        public string Code { get; set; }

        public Currency(string code)
        {
            if (code.Length!=3)
                throw new ArgumentOutOfRangeException("Currency needs to have three characters length.");

            Code = code;
        }

        public static implicit operator String(Currency currency)
        {
            return currency.Code;
        }


        public static implicit operator Currency(string currency)
        {
            return new Currency(currency);
        }

        public static bool operator == (Currency currency1, Currency currency2)
        {
            if (currency1.Code == currency2.Code)
                return true;
            return false;
        }

        public static bool operator !=(Currency currency1, Currency currency2)
        {
            if (currency1.Code != currency2.Code)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }

        public override string ToString()
        {
            return Code;
        }

        public int CompareTo(Currency other)
        {
            return this.Code.CompareTo(other.Code);
        }
    }
}