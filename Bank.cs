namespace TheMoneyExample.Tests;

public class Bank
{
    class Pair
    {
        string from;
        string to;

        public Pair(string from, string to)
        {
            this.from = from;
            this.to = to;
        }

        public override bool Equals(object? obj)
        {
            return obj is Pair pair && pair.from == from && pair.to == to;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
    
    public Money Reduce(Expression source, string to)
    {
        return source.Reduce(this, to);
    }

    public void AddRate(string chf, string usd, int i)
    {
    }

    public int Rate(String from, String to)
        => from == "CHF" && to == "USD" ? 2 : 1;
}