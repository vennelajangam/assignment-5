using System;
using System.Collections.Generic;
using System.Linq;


namespace Q180513
{
    class MainClass
    {
        public static void Print(string message, IEnumerable<int> list)
        {
            Console.Write(message + " :   ");
            foreach (int num in list)
                Console.Write(num + "  ");
            Console.WriteLine();
            Console.WriteLine();
        }


        public static void Main(string[] args)
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
           

            
            IEnumerable<int> odd = list.Where(x => x % 2 == 1);
            Print("Odd", odd);

            IEnumerable<int> even = list.Where(x => { return x % 2 == 0; });
            Print("Even", even);

          
            IEnumerable<int> primes = list.Where(delegate (int x) {
                if (x <= 1)
                    return false;
                for (int i = 2; i <= x / 2; i++)
                    if (x % i == 0)
                        return false;
                return true;
            });
            Print("Primes", primes);

          
            IEnumerable<int> primesAnother = list.Where(x => {
                if (x <= 1)
                    return false;
                for (int i = 2; i <= x / 2; i++)
                    if (x % i == 0)
                        return false;
                return true;
            });
            Print("Primes Another", primesAnother);

          
            Func<int, bool> ConditionMore = GreaterThanFive;   // Func<T,TResult> is a delegate
            IEnumerable<int> greaterThanFive = list.Where(ConditionMore);
            Print("Greater Than Five", greaterThanFive);

          
            Func<int, bool> ConditionLess = new Func<int, bool>(LessThanFive);
            IEnumerable<int> lessThanFive = list.Where(ConditionLess);
            Print("Less Than Five", lessThanFive);

            Func<int, bool> Condition3k = new Func<int, bool>(x => x % 3 == 0);
            IEnumerable<int> list3k = list.Where(Condition3k);
            Print("3k", list3k);

           
            Func<int, bool> Condition3kplus1 = new Func<int, bool>(delegate (int x) {
                return x % 3 == 1;
            });
            IEnumerable<int> list3kplus1 = list.Where(Condition3kplus1);
            Print("3k + 1", list3kplus1);

            
            Func<int, bool> Condition3kplus2 = x => x % 3 == 2;
            IEnumerable<int> list3kplus2 = list.Where(Condition3kplus2);
            Print("3k + 2", list3kplus2);

            
            Func<int, bool> Anything = delegate (int x) {
                return x != 0;
            };
            IEnumerable<int> anything = list.Where(Anything);
            Print("Anything", anything);

           
            Func<int, bool> AnythingAnother = AnythingMethod;
            IEnumerable<int> anythingAnother = list.Where(AnythingAnother);
            Print("Anything", anythingAnother);
        }

        public static bool GreaterThanFive(int x)
        {
            return x > 5;
        }

        public static bool LessThanFive(int x)
        {
            return x < 5;
        }
        public static bool AnythingMethod(int x)
        {
            return x != 0;
        }
    }
}
