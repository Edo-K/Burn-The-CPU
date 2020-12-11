using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Burn_The_CPU
{
    public class LucasLehmerTest
    {
        static BigInteger ZERO = new BigInteger(0);
        static BigInteger ONE = new BigInteger(1);
        static BigInteger TWO = new BigInteger(2);
        static BigInteger FOUR = new BigInteger(4);

        private static bool IsMersennePrime(int p)
        {
            if (p % 2 == 0) return (p == 2);
            else
            {
                for (int i = 3; i <= (int)Math.Sqrt(p); i += 2)
                    if (p % i == 0) return false; //not prime
                BigInteger m_p = BigInteger.Pow(TWO, p) - ONE;
                BigInteger s = FOUR;
                for (int i = 3; i <= p; i++)
                    s = (s * s - TWO) % m_p;
                return s == ZERO;
            }
        }

        public static int[] GetMersennePrimeNumbers(int upTo)
        {
            List<int> response = new List<int>();
            Parallel.For(2, upTo + 1, i => {
                if (IsMersennePrime(i)) response.Add(i);
            });
            response.Sort();
            return response.ToArray();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("This software uses intensive Lucas–Lehmer calculations " +
                "to test the processor and it's cooling capacity. Use at your own risk!" +
                "\n" +
                "Press any key to continue");
            Console.ReadKey(true);
            Console.WriteLine("\n" + "Calculating...");
            int[] mersennePrimes = LucasLehmerTest.GetMersennePrimeNumbers(11213);
            foreach (int mp in mersennePrimes)
                Console.Write("M" + mp + " ");
            Console.ReadLine();
        }
    }
}
