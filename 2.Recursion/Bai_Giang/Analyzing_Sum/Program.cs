using System;

namespace Analyzing_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int n;
            n = 20;
            int[] arr = new int[n + 1];
            int[] storedValue = new int[n + 1];

            //Initilization
            arr[0] = 1;
            storedValue[0] = 0;

            Recursion(n, 1, arr, storedValue);
        }

        static void Recursion(int n, int i, int[] arr, int[] storedValue)
        {
            int j;
            int[] output = new int[n + 1];

            for (int m = 0; m < n; m++)
            {
                output[m] = arr[m];
            }

            for (j = output[i - 1]; j <= (n - storedValue[i - 1]) / 2; j++)
            {
                storedValue[i] = storedValue[i - 1] + j;
                output[i] = j;
                Recursion(n, i + 1, output, storedValue);
            }
            output[i] = n - storedValue[i - 1];
            Print(i, output);
        }

        static void Print(int i, int[] arr)
        {
            Console.Write("Result: [ ");
            for (int k = 1; k <= i; k++)
                Console.Write(arr[k].ToString() + " ");
            Console.Write("]\n");
        }
    }
}
