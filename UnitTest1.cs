namespace TheMoneyExample.Tests;

// We need to be able to add amounts in two different currencies and convert the result given a set of exchange rates.
// We need to be able to multiply an amount (price per share) by a number (number of shares) and receive an amount.

// TODO list
// [] $5 + 10 CHF = $10 if rate is 2:1
// [] $5 * 2 = $10
// [] Make "amount" private
// [] Dollar side-effects?
// [] Money rounding?

public class Tests
{
    [Test]
    public void TestMultiplication()
    {
        Dollar five = new Dollar(5);
        five.Times(2);
        Assert.AreEqual(10, five.amount);
    }
}

public class Dollar
{
    public int amount;

    public Dollar(int amount)
    {
        this.amount = amount;
    }

    public void Times(int howMuch)
    {
        amount = amount * 2;
    }
}