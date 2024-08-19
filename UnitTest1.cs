using FluentAssertions;

namespace TheMoneyExample.Tests;

// We need to be able to add amounts in two different currencies and convert the result given a set of exchange rates.
// We need to be able to multiply an amount (price per share) by a number (number of shares) and receive an amount.

// TODO list
// [] $5 + 10 CHF = $10 if rate is 2:1
// [x] $5 * 2 = $10
// [x] Make "amount" private
// [x] Dollar side-effects?
// [] Money rounding?
// [x] equals()
// [] hashCode()
// [] Equal null
// [] Equal object
// [x] 5 CHF * 2 = 10 CHF
// [] Dollar/Franc duplication
// [x] Common equals
// [x] Common times
// [x] Compare Francs with Dollars
// [x] Currency?
// [] Delete testFrancMultiplication?

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
    }
    
    [Test]
    public void TestFrancMultiplication()
    {
        Money five = Money.Franc(5);
        Assert.AreEqual(Money.Franc(10), five.Times(2));
        Assert.AreEqual(Money.Franc(15), five.Times(3));
    }

    [Test]
    public void TestCurrency()
    {
        Money.Franc(1).Currency().Should().Be("CHF");
        Money.Dollar(1).Currency().Should().Be("USD");
    }

    [Test]
    public void TestDifferentClassEquality()
    {
        new Money(10, "CHF").Should().Be(new Franc(10, "CHF"));
    }
}