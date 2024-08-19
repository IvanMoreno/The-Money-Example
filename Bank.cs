namespace TheMoneyExample.Tests;

public class Bank
{
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