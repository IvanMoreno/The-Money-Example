namespace TheMoneyExample.Tests;

public class Money
{
    protected int amount;
    protected string currency;

    public Money(int amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public virtual Money Times(int multiplier) => null;
    public String Currency() => currency;

    public override bool Equals(object? obj)
    {
        return ((Money)obj).amount == amount && obj.GetType() == GetType();
    }

    public override string ToString()
    {
        return amount + " " + currency;
    }

    public static Money Dollar(int amount) => new Dollar(amount, "USD");
    public static Money Franc(int amount) => new Franc(amount, "CHF");
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