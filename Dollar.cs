namespace TheMoneyExample.Tests;

public abstract class Money
{
    protected int amount;
    protected string currency;

    protected Money(int amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public abstract Money Times(int multiplier);

    public override bool Equals(object? obj)
    {
        return ((Money)obj).amount == amount && obj.GetType() == GetType();
    }

    public static Money Dollar(int amount) => new Dollar(amount, "USD");
    public static Money Franc(int amount) => new Franc(amount, "CHF");
    public String Currency() => currency;
}

public class Dollar : Money
{
    public Dollar(int amount, string currency)
        : base(amount, currency){}

    public override Money Times(int multiplier)
    {
        return new Dollar(amount * multiplier, currency);
    }
}

public class Franc : Money
{
    public Franc(int amount, string currency)
        : base(amount, currency){}

    public override Money Times(int multiplier)
    {
        return new Franc(amount * multiplier, currency);
    }
}