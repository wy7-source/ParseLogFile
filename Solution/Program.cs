using System;

namespace Solution
{
    class Program
    {            

        static void Main(string[] args)
        {
            // aka 'A'.
            int[] numbers = new int[40000];
            // To populate A.
            var rand = new Random();

            // To limit the populate interval
            int min = (-2147483647);
            int max = 2147483647;
            Solution solution = new Solution();

            Console.WriteLine("Populating the 'A' array...");
            // Populating the numbers
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(min,max);
            }
            // foreach( int v in numbers)
            // Console.WriteLine(v);
            Console.WriteLine("The max distance of Adjacent numbers is: " + solution.solution(numbers));
        }
    }
}
