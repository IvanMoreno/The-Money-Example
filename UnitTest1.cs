using FluentAssertions;

namespace TheMoneyExample.Tests;

// We need to be able to add amounts in two different currencies and convert the result given a set of exchange rates.
// We need to be able to multiply an amount (price per share) by a number (number of shares) and receive an amount.

// TODO list
// [] $5 + 10 CHF = $10 if rate is 2:1
// [] Money rounding?
// [x] hashCode()
// [x] Equal null
// [] Equal object

public class Tests
{
    [Test]
    public void TestMultiplication()
    {
        Money five = Money.Dollar(5);
        Assert.AreEqual(Money.Dollar(10), five.Times(2));
        Assert.AreEqual(Money.Dollar(15), five.Times(3));
    }

    [Test]
    public void TestEquality()
    {
        Assert.AreEqual(Money.Dollar(5), Money.Dollar(5));
        Assert.AreNotEqual(Money.Dollar(5), Money.Dollar(6));
        Money.Franc(5).Should().NotBe(Money.Dollar(5));
        Money.Franc(5).Equals(null).Should().BeFalse();
    }

    [Test]
    public void TestCurrency()
    {
        Money.Franc(1).Currency().Should().Be("CHF");
        Money.Dollar(1).Currency().Should().Be("USD");
    }
}