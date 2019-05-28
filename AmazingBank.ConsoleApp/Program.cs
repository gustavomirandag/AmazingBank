using AmazingBank.DomainModel.ValueObjects;
using System;

namespace AmazingBank.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Amount bitWallet = new Amount("BTC", 4000);
            Amount bitWallet2 = new Amount("BTC", 4000);
            Console.WriteLine($"bitWallet == bitWallet2: {bitWallet == bitWallet2}");

            Amount dollarWallet = new Amount("USD", 10000);
            Amount dollarWallet2 = new Amount("USD", 20000);
            Console.WriteLine($"dollarWallet == dollarWallet2: {dollarWallet == dollarWallet2}");

            bitWallet++;
            Console.WriteLine(bitWallet);

            bitWallet = bitWallet + 100;
            Console.WriteLine(bitWallet);

            Console.WriteLine(bitWallet+bitWallet);

            dollarWallet++;
            Console.WriteLine(dollarWallet);

            Currency btc = new Currency("BTC");
            Currency usd = new Currency("USD");
            Console.WriteLine($"btc == usd: {btc == usd}");

            Console.ReadLine();
        }
    }
}
