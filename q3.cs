using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethodDemo
{
    static class Extensions
    {
        public static bool CustomAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CustomAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static T CustomMax<T>(this IEnumerable<T> source, Func<T, T, int> compare)
        {
            T max = source.FirstOrDefault();
            foreach (T item in source.Skip(1))
            {
                if (compare(item, max) > 0)
                {
                    max = item;
                }
            }
            return max;
        }

        public static T CustomMin<T>(this IEnumerable<T> source, Func<T, T, int> compare)
        {
            T min = source.FirstOrDefault();
            foreach (T item in source.Skip(1))
            {
                if (compare(item, min) < 0)
                {
                    min = item;
                }
            }
            return min;
        }

        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> CustomSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

            bool allEven = numbers.CustomAll(x => x % 2 == 0);
            Console.WriteLine("All even: " + allEven);

            bool anyOdd = numbers.CustomAny(x => x % 2 != 0);
            Console.WriteLine("Any odd: " + anyOdd);

            int max = numbers.CustomMax((x, y) => x.CompareTo(y));
            Console.WriteLine("Max: " + max);

            int min = numbers.CustomMin((x, y) => x.CompareTo(y));
            Console.WriteLine("Min: " + min);

            IEnumerable<int> evenNumbers = numbers.CustomWhere(x => x % 2 == 0);
            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

            IEnumerable<string> words = new List<string>() { "foo", "bar", "baz" };
            IEnumerable<int> wordLengths = words.CustomSelect(x => x.Length);
            Console.WriteLine("Word lengths: " + string.Join(", ", wordLengths));
        }
    }
}

