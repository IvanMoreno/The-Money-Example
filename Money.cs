namespace TheMoneyExample.Tests;

public class Money
{
    int amount;
    string currency;

    Money(int amount, string currency)
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

    public Money Plus(Money addend)
    {
        return new Money(amount + addend.amount, currency);
    }

    public override string ToString()
    {
        return amount + " " + currency;
    }

    public static Money Dollar(int amount) => new Money(amount, "USD");

    public static Money Franc(int amount) => new Money(amount, "CHF");
}