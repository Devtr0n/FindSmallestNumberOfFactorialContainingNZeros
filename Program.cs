using System;

namespace FindSmallestNumberOfFactorialContainingNZeros
{
    /// <summary>
    /// The main Program class
    /// Contains all methods for performing calculations for determining the smallest factorial for n zeros
    /// </summary>
    /// <remarks>The challenge is to use </remarks>
    internal class Program
    {
        // calculate the smallest number of which the factorial contains 'n' zeros
        internal static int FindSmallestFactorialForNZeros(int n)
        {
            // when 'n' equals 1, the easy answer is 5!
            if (n == 1)
                return 5;

            // initialize bottom and top for binary search
            int low = 0, high = 5 * n;

            // recursive search
            while (low < high)
            {
                // binary bit shift
                int middle = (low + high) >> 1;

                // determine trailing zeroes
                if (HasTrailingZeros(middle, n))
                    high = middle;
                else
                    low = middle + 1;
            }

            return low;
        }

        // determine number's factorial contains at-least 'n' trailing zeros
        internal static bool HasTrailingZeros(int p, int n)
        {
            int count = 0, f = 5;
            while (f <= p)
            {
                count += p / f;
                f *= 5;
            }
            return (count >= n);
        }

        // main entry point
        private static void Main()
        {
            Console.WriteLine($"Input: {1} Output: {FindSmallestFactorialForNZeros(1)}");               // expected output 5
            Console.WriteLine($"Input: {6} Output: {FindSmallestFactorialForNZeros(6)}");               // expected output 25
            Console.WriteLine($"Input: {31} Output: {FindSmallestFactorialForNZeros(31)}");             // expected output 125
            Console.WriteLine($"Input: {156} Output: {FindSmallestFactorialForNZeros(156)}");           // expected output 625
            Console.WriteLine($"Input: {781} Output: {FindSmallestFactorialForNZeros(781)}");           // expected output 3125
            Console.WriteLine($"Input: {3906} Output: {FindSmallestFactorialForNZeros(3906)}");         // expected output 15625
            Console.ReadLine(); // paused
        }
    }
}