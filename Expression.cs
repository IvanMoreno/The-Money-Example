namespace TheMoneyExample.Tests;

public interface Expression
{
    Money Reduce(Bank bank, string to);
    Expression Plus(Expression addend);
    Expression Times(int multiplier);
}