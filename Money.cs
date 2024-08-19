namespace TheMoneyExample.Tests;

public class Money : Expression
{
    public int amount;
    string currency;

    public Money(int amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public String Currency() => currency;

    public override bool Equals(object? other)
    {
        return other is Money money && money.amount == amount && money.currency == currency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(amount, currency);
    }

    public Money Times(int multiplier)
    {
        return new Money(amount * multiplier, currency);
    }

    public Expression Plus(Expression addend)
    {
        return new Sum(this, addend);
    }

    public Money Reduce(Bank bank, string to)
    {
        var rate = bank.Rate(currency, to);

        return new Money(amount / rate, to);
    }

    public override string ToString()
    {
        return amount + " " + currency;
    }

    public static Money Dollar(int amount) => new Money(amount, "USD");
    public static Money Franc(int amount) => new Money(amount, "CHF");
}