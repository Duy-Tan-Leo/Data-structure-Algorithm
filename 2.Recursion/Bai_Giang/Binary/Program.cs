using System;

namespace Bai_Giang
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int[] arr = new int[n];
            Recursion(1, n, arr);

        }

        static void Recursion(int k, int n, int[] arr)
        {
            for (int i = 0; i < 2; i++)
            {
                arr[k - 1] = i;
                if (k == n)
                {
                    Console.Write("{ ");
                    foreach(int item in arr)
                        Console.Write(item.ToString() + " ");
                    Console.Write("}\n");
                }
                else
                {                    
                    Recursion(k + 1, n, arr);
                }
            }
        }
    }
}
