using System;

namespace lab3_3
{

    public abstract class Currency
    {
        public double Value { get; set; }

        protected Currency(double value)
        {
            Value = value;
        }
    }

    public class CurrencyUSD : Currency
    {
        public CurrencyUSD(double value) : base(value) { }

        //явное преобразование USD в EUR
        public static explicit operator CurrencyEUR(CurrencyUSD usd)
        {
            //курс USD к EUR
            double exchangeRate = 0.91;
            return new CurrencyEUR(usd.Value * exchangeRate);
        }

        //явное преобразование USD в RUB
        public static explicit operator CurrencyRUB(CurrencyUSD usd)
        {
            //курс USD к RUB
            double exchangeRate = 95;
            return new CurrencyRUB(usd.Value * exchangeRate);
        }
    }

    public class CurrencyEUR : Currency
    {
        public CurrencyEUR(double value) : base(value) { }

        //явное преобразование EUR в USD
        public static explicit operator CurrencyUSD(CurrencyEUR eur)
        {
            //курс EUR к USD
            double exchangeRate = 1.1;
            return new CurrencyUSD(eur.Value * exchangeRate);
        }

        //явное преобразование EUR в RUB
        public static explicit operator CurrencyRUB(CurrencyEUR eur)
        {
            //курс EUR к RUB
            double exchangeRate = 100;
            return new CurrencyRUB(eur.Value * exchangeRate);
        }
    }

    public class CurrencyRUB : Currency
    {
        public CurrencyRUB(double value) : base(value) { }

        //явное преобразование RUB в USD
        public static explicit operator CurrencyUSD(CurrencyRUB rub)
        {
            //курс RUB к USD
            double exchangeRate = 0.01;
            return new CurrencyUSD(rub.Value * exchangeRate);
        }

        //явное преобразование RUB в EUR
        public static explicit operator CurrencyEUR(CurrencyRUB rub)
        {
            //курс RUB к EUR
            double exchangeRate = 0.009;
            return new CurrencyEUR(rub.Value * exchangeRate);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.Write("Введите сумму в USD: ");
            double usdValue = Convert.ToDouble(Console.ReadLine());
            CurrencyUSD usd = new CurrencyUSD(usdValue);

            CurrencyEUR eur = (CurrencyEUR)usd; //преобразование из USD в EUR
            CurrencyRUB rub = (CurrencyRUB)usd; //преобразование из USD в RUB

            Console.WriteLine($"{usd.Value} USD = {eur.Value} EUR");
            Console.WriteLine($"{usd.Value} USD = {rub.Value} RUB");

        }
    }
}
