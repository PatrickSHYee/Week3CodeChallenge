using System;
using System.Collections.Generic;
using System.Linq;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        /// <summary>
        /// A function that calculates the starting value of the longest Collatz sequence.
        /// This function will start at 1 million and look at which value generates the
        /// longest sequence.
        /// </summary>
        /// <returns>Starting value of the longest sequence</returns>
        public static long LongestCollatzSequence()
        {
            // an lambda expression to do the recursive calls
            return Enumerable.Range(1, 999999).AsParallel().Select(x => new { num = x, count = GenSequence(x) }).OrderByDescending(x => x.count).Select(x => x.num).First();
        }

        /// <summary>
        /// The base case is 1 for this recursive aligorthm, where the even numbers is divided by 2 and the odd numbers are times 3 plus 1
        /// until the base case is reached. The count of the sequence is returned.
        /// </summary>
        /// <param name="num">a number to do the math with.</param>
        /// <returns>1</returns>
        private static long GenSequence(long num)
        {
            if (num == 1) return 1;
            long next = (num % 2 == 0) ? num / 2 : 3 * num + 1;
            return GenSequence(next) + 1;
        }

        /// <summary>
        /// A Function that adds up each even number in a Fibonacci Sequence until the maxValue
        /// then prints the sum of those numbers to the console
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns>The sum of every even number for the given number of Fibonacci digits</returns>
        public static long EvenFibonacciSequencer(long maxValue)
        {
            // setting everything up
            long sum_Even = 2;  // 2 is already valued, so I need this even number to be set
            long num1 = 1;  // first number in the sequence
            long num2 = 2;  // second number in the sequence
            long fibNum = num1 + num2;  // the next number in the sequence

            while (fibNum <= maxValue)  // checks if the fibonacci number is less than or equal to the max Value
            {
                if (fibNum % 2 == 0)  // checks if the fibonacci number is even
                {
                    sum_Even += fibNum;  // adds the even numbers together
                }
                num1 = num2;            // replaces the first number with the 2nd number
                num2 = fibNum;          // replaces the 2nd number with the checked number
                fibNum = num1 + num2;   // the next number in the sequence
            }
            return sum_Even;
        }

        /// <summary>
        /// Function that finds the n'th prime indicated by the parameter
        /// </summary>
        /// <param name="maxPrime"></param>
        /// <returns>The prime number which is the n'th found</returns>
        public static int FindNPrimes(int maxPrime)
        {
            int n = 3;      // a great prime number to start with
            int count = 2;  // this is where 3 is the count at

            while (count < maxPrime)    // checks the count to the nth
            {
                n += 2;                 // skips the even numbers
                // finds the number is prime
                if (IsPrime(n))
                {
                    count++;
                }
            }
            return n; // returns the nth prime the maxPrime
        }

        /// <summary>
        /// Finds the prime number
        /// </summary>
        /// <param name="number">a test number</param>
        /// <returns>prime returns true and not returns false</returns>
        public static bool IsPrime(int number)
        {
            // I want to return a bool variable to return
            bool thatPrime = true;

            if (number < 3)
            {
                thatPrime = true;
            }
            // finding the prime number
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) thatPrime = false;
            }
            return thatPrime;
        }
    }
}
