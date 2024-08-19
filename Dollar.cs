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

    public String Currency() => currency;

    public override bool Equals(object? obj)
    {
        return ((Money)obj).amount == amount && ((Money)obj).currency == currency;
    }

    public Money Times(int multiplier)
    {
        return new Money(amount * multiplier, currency);
    }

    public override string ToString()
    {
        return amount + " " + currency;
    }

    public static Money Dollar(int amount) => new Money(amount, "USD");

    public static Money Franc(int amount) => new Money(amount, "CHF");
}

public class Dollar : Money
{
    public Dollar(int amount, string currency)
        : base(amount, currency){}
}

public class Franc : Money
{
    public Franc(int amount, string currency)
        : base(amount, currency){}
}