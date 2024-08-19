namespace TheMoneyExample.Tests;

class Sum : Expression
{
    public Money augend;
    public Money addend;

    public Sum(Money augend, Money addend)
    {
        this.augend = augend;
        this.addend = addend;
    }
    
    public Money Reduce(Bank bank, string to)
    {
        return new Money(augend.Reduce(bank, to).amount + addend.Reduce(bank, to).amount, to);
    }
}