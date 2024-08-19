using System.Collections;

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

    Dictionary<Pair, int> rates = new();
    
    public Money Reduce(Expression source, string to)
    {
        return source.Reduce(this, to);
    }

    public void AddRate(string chf, string usd, int rate)
    {
        rates.Add(new Pair(chf, usd), rate);
    }

    public int Rate(String from, String to)
        => rates[new Pair(from, to)];
}