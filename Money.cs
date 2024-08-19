namespace TheMoneyExample.Tests;

public interface Expression
{
    Money Reduce(string to);
}

class Sum : Expression
{
    public Money augend;
    public Money addend;

    public Sum(Money augend, Money addend)
    {
        this.augend = augend;
        this.addend = addend;
    }
    
    public Money Reduce(string to)
    {
        return new Money(augend.amount + addend.amount, to);
    }
}

public class Bank
{
    public Money Reduce(Expression source, string to)
    {
        if(source is Money) return source as Money;
        var sum = (Sum)source;
        return sum.Reduce(to);
    }
}

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

    public Expression Plus(Money addend)
    {
        return new Sum(this, addend);
    }

    public Money Reduce(string to)
    {
        return this;
    }

    public override string ToString()
    {
        return amount + " " + currency;
    }

    public static Money Dollar(int amount) => new Money(amount, "USD");

    public static Money Franc(int amount) => new Money(amount, "CHF");
}