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

public class Franc
{
    int amount;

    public Franc(int amount)
    {
        this.amount = amount;
    }

    public Franc Times(int multiplier)
    {
        return new Franc(amount * multiplier);
    }

    public override bool Equals(object? obj)
    {
        return ((Franc)obj).amount == amount;
    }
}