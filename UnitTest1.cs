namespace TheMoneyExample.Tests;

// We need to be able to add amounts in two different currencies and convert the result given a set of exchange rates.
// We need to be able to multiply an amount (price per share) by a number (number of shares) and receive an amount.

// TODO list
// [] $5 + 10 CHF = $10 if rate is 2:1
// [x] $5 * 2 = $10
// [] Make "amount" private
// [x] Dollar side-effects?
// [] Money rounding?

public class Tests
{
    [Test]
    public void TestMultiplication()
    {
        Dollar five = new Dollar(5);
        Dollar product = five.Times(2);
        Assert.AreEqual(10, product.amount);
        product = five.Times(3);
        Assert.AreEqual(15, product.amount);
    }
}