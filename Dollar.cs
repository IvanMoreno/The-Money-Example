namespace TheMoneyExample.Tests;

public class Dollar
{
    int amount;

    public Dollar(int amount)
    {
        this.amount = amount;
    }

    public Dollar Times(int multiplier)
    {
        return new Dollar(amount * multiplier);
    }

    public override bool Equals(object? obj)
    {
        return ((Dollar)obj).amount == amount;
    }
}