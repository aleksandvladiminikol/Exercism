namespace Exercism;

static class SavingsAccount
{
    private static double _negativeBalance = 3.213;
    private static double _positiveLess1000 = 0.5;
    private static double _positiveless5000 = 1.621;
    private static double _positivemore5000 = 2.475;
    public static float InterestRate(decimal balance)
    {
        if (balance < 0)
        {
            return (float) _negativeBalance;
        }
        else if (balance >= 0 && balance < 1000)
        {
            return (float) _positiveLess1000;
        }
        else if (balance >= 1000 && balance < 5000)
        {
            return (float) _positiveless5000;
        }
        else
        {
            return (float) _positivemore5000;
        }
    }

    public static decimal Interest(decimal balance)
    {
        return (decimal) InterestRate(balance) * balance / 100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return Interest(balance) + balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var result = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            result++;
        }

        return result;
    }
}
