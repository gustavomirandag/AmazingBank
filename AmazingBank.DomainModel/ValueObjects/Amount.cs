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

        public static readonly Amount MinValue = new Amount() { Value = Decimal.MinValue };           // absolute zero
        public static readonly Amount MaxValue = new Amount() { Value = Decimal.MaxValue };

        public Amount(Currency currency, Decimal value)
        {
            if (value < Amount.MinValue.Value)
                throw new ArgumentOutOfRangeException("value", "Value cannot be less then Amount.MinValue (absolute zero)");
            if (value > Amount.MaxValue.Value)
                throw new ArgumentOutOfRangeException("value", "Value cannot be more then Amount.MaxValue");

            Currency = currency;
            Value = value;
        }

        public Amount(string currency, Decimal value)
        {
            if (value < Amount.MinValue.Value)
                throw new ArgumentOutOfRangeException("value", "Value cannot be less then Amount.MinValue (absolute zero)");
            if (value > Amount.MaxValue.Value)
                throw new ArgumentOutOfRangeException("value", "Value cannot be more then Amount.MaxValue");

            Currency = new Currency(currency);
            Value = value;
        }

        public static Amount NewAmount (Currency currency, Decimal value)
        {
            return new Amount(currency, value);
        }

        public static Amount Parse(string amountStr)
        {
            var splittedAmount = amountStr.Split(' ');
            Currency currency = splittedAmount[0];
            Decimal value = Decimal.Parse(splittedAmount[1]);
            return new Amount(currency, value);
        }

        public static Amount operator +(Amount amount1, Amount amount2)
        {
            if (amount1.Currency != amount2.Currency)
                throw new InvalidCastException("Invalid cast in sum operation.", new Exception("Amounts Currency needs to be of the same type."));
            return new Amount(amount1.Currency, amount1.Value + amount2.Value);
        }

        public static Amount operator -(Amount amount1, Amount amount2)
        {
            if (amount1.Currency != amount2.Currency)
                throw new InvalidCastException("Invalid cast in subtraction operation.", new Exception("Amounts Currency needs to be of the same type."));
            return new Amount(amount1.Currency, amount1.Value - amount2.Value);
        }

        public static Amount operator ++(Amount amount)
        {
            amount.Value++;
            return amount;
        }

        public static Amount operator --(Amount amount)
        {
            amount.Value--;
            return amount;
        }

        public static bool operator ==(Amount amount1, Amount amount2)
        {
            if (amount1.Currency != amount2.Currency)
                return false;
                //throw new InvalidCastException("Invalid cast in sum operation.", new Exception("Amounts Currency needs to be of the same type."));
            return amount1.Value == amount2.Value;
        }

        public static bool operator != (Amount amount1, Amount amount2)
        {
            if (amount1.Currency != amount2.Currency)
                return true;
                //throw new InvalidCastException("Invalid cast in sum operation.", new Exception("Amounts Currency needs to be of the same type."));
            return amount1.Value != amount2.Value;
        }

        public static Amount operator +(Amount amount, int value)
        {
            return new Amount(amount.Currency, amount.Value + value);
        }

        public static Amount operator -(Amount amount, int value)
        {
            return new Amount(amount.Currency, amount.Value - value);
        }

        public static implicit operator Decimal(Amount amount)
        {
            return amount.Value;
        }

        public override bool Equals(object obj)
        {
            return this == ((Amount)obj);
        }

        public override int GetHashCode()
        {
            return this.Currency.GetHashCode() + this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Currency.ToString()} {Value.ToString()}";
        }
    }
}
