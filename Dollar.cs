namespace TheMoneyExample.Tests;

public abstract class Money
{
    protected int amount;

    public abstract Money Times(int multiplier);

    public override bool Equals(object? obj)
    {
        return ((Money)obj).amount == amount && obj.GetType() == GetType();
    }

    public static Money Dollar(int amount) => new Dollar(amount);
    public static Money Franc(int amount) => new Franc(amount);
    public abstract String Currency();
}

public class Dollar : Money
{
    string currency;
    
    public Dollar(int amount)
    {
        this.amount = amount;
        currency = "USD";
    }

    public override Money Times(int multiplier)
    {
        return new Dollar(amount * multiplier);
    }

    public override string Currency()
    {
        return currency;
    }
}

public class Franc : Money
{
    string currency;
    
    public Franc(int amount)
    {
        this.amount = amount;
        currency = "CHF";
    }

    public override Money Times(int multiplier)
    {
        return new Franc(amount * multiplier);
    }

    public override string Currency()
    {
        return currency;
    }
}