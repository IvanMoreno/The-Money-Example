namespace TheMoneyExample.Tests;

public abstract class Money
{
    protected int amount;
    protected string currency;

    public abstract Money Times(int multiplier);

    public override bool Equals(object? obj)
    {
        return ((Money)obj).amount == amount && obj.GetType() == GetType();
    }

    public static Money Dollar(int amount) => new Dollar(amount);
    public static Money Franc(int amount) => new Franc(amount, "CHF");
    public String Currency() => currency;
}

public class Dollar : Money
{
    public Dollar(int amount)
    {
        this.amount = amount;
        currency = "USD";
    }

    public override Money Times(int multiplier)
    {
        return Money.Dollar(amount * multiplier);
    }
}

public class Franc : Money
{
    public Franc(int amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public override Money Times(int multiplier)
    {
        return Money.Franc(amount * multiplier);
    }
}