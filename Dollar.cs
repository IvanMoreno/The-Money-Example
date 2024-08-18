namespace TheMoneyExample.Tests;

public abstract class Money
{
    protected int amount;

    public abstract Money Times(int multiplier);

    public override bool Equals(object? obj)
    {
        return ((Money)obj).amount == amount && obj.GetType() == GetType();
    }
}

public class Dollar : Money
{
    public Dollar(int amount)
    {
        this.amount = amount;
    }

    public override Money Times(int multiplier)
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

    public override Money Times(int multiplier)
    {
        return new Franc(amount * multiplier);
    }
}