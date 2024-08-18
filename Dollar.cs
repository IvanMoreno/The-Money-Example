namespace TheMoneyExample.Tests;

public class Money
{
    protected int amount;
    
    public override bool Equals(object? obj)
    {
        return ((Money)obj).amount == amount;
    }
}

public class Dollar : Money
{
    public Dollar(int amount)
    {
        this.amount = amount;
    }

    public Dollar Times(int multiplier)
    {
        return new Dollar(amount * multiplier);
    }
}

public class Franc : Money
{
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