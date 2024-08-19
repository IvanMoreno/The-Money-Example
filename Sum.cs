namespace TheMoneyExample.Tests;

class Sum : Expression
{
    public Expression augend;
    public Expression addend;

    public Sum(Expression augend, Expression addend)
    {
        this.augend = augend;
        this.addend = addend;
    }
    
    public Money Reduce(Bank bank, string to)
    {
        return new Money(augend.Reduce(bank, to).amount + addend.Reduce(bank, to).amount, to);
    }
}