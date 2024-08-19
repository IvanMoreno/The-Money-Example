using FluentAssertions;

namespace TheMoneyExample.Tests;

// We need to be able to add amounts in two different currencies and convert the result given a set of exchange rates.
// We need to be able to multiply an amount (price per share) by a number (number of shares) and receive an amount.

// TODO list
// [] $5 + 10 CHF = $10 if rate is 2:1
// [x] $5 + $5 = $10
//      [] Return Money from $5 + $5
// [x] Bank.reduce(Money)
// [x] Reduce money with conversion
// [x] Reduce(Bank, String)
// [] Money rounding?
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

    [Test]
    public void TestSimpleAddition()
    {
        Money five = Money.Dollar(5);
        Expression sum = five.Plus(five);
        Bank bank = new Bank();
        Money reduced = bank.Reduce(sum, "USD");
        reduced.Should().Be(Money.Dollar(10));
    }

    [Test]
    public void TestPlusReturnSum()
    {
        Money five = Money.Dollar(5);
        Sum sum = five.Plus(five) as Sum;
        sum.augend.Should().Be(five);
        sum.addend.Should().Be(five);
    }

    [Test]
    public void TestReduceSum()
    {
        Expression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
        Bank bank = new Bank();
        bank.Reduce(sum, "USD").Should().Be(Money.Dollar(7));
    }

    [Test]
    public void TestReduceMoney()
    {
        Bank bank = new Bank();
        bank.Reduce(Money.Dollar(1), "USD").Should().Be(Money.Dollar(1));
    }

    [Test]
    public void TestReduceMoneyDifferentCurrency()
    {
        Bank bank = new Bank();
        bank.AddRate("CHF", "USD", 2);
        bank.Reduce(Money.Franc(2), "USD").Should().Be(Money.Dollar(1));
    }

    [Test]
    public void TestIdentityRate()
    {
        new Bank().Rate("USD", "USD").Should().Be(1);
    }

    [Test]
    public void TestMixedAdditions()
    {
        Expression fiveBucks = Money.Dollar(5);
        Expression tenFrancs = Money.Franc(10);
        Bank bank = new Bank();
        bank.AddRate("CHF", "USD", 2);
        bank.Reduce(fiveBucks.Plus(tenFrancs), "USD").Should().Be(Money.Dollar(10));
    }
}