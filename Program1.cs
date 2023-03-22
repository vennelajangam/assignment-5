using System;

public static class IntExtensions
{
    public static bool IsOdd(this int number)
    {
        return number % 2 != 0;
    }

    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }

    public static bool IsPrime(this int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsDivisibleBy(this int number, int divisor)
    {
        if (divisor == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.");
        }

        return number % divisor == 0;
    }
}
