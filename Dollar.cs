namespace TheMoneyExample.Tests;

public class Dollar
{
    public int amount;

    public Dollar(int amount)
    {
        this.amount = amount;
    }

    public Dollar Times(int multiplier)
    {
        return new Dollar(amount * multiplier);
    }
}