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
// [] 5 CHF * 2 = 10 CHF

public class Tests
{
    [Test]
    public void TestMultiplication()
    {
        Dollar five = new Dollar(5);
        Assert.AreEqual(new Dollar(10), five.Times(2));
        Assert.AreEqual(new Dollar(15), five.Times(3));
    }

    [Test]
    public void TestEquality()
    {
        Assert.AreEqual(new Dollar(5), new Dollar(5));
        Assert.AreNotEqual(new Dollar(5), new Dollar(6));
    }
    
    [Test]
    public void TestFrancMultiplication()
    {
        Franc five = new Franc(5);
        Assert.AreEqual(new Franc(10), five.Times(2));
        Assert.AreEqual(new Franc(15), five.Times(3));
    }
}