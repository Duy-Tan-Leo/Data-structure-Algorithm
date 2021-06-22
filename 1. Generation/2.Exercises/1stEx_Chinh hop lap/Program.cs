using System;

namespace _1stEx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Nhap n");
            // int n = int.Parse(Console.ReadLine());
            // Console.WriteLine("Nhap k");
            // int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Cac phan tu in ra la");
            int n = 10;
            int k = 3;
            //Initialize first elemet
            int[] arr = new int[k];
            for (int i = 0; i < k; i++) arr[i] = 0;

            int idx;
            do
            {
                printArr(arr);
                idx = k;
                while (idx > 0 && arr[idx - 1] == n-1) --idx;
                if (idx > 0)
                {
                    arr[idx - 1]++;
                    for (int i = idx; i < k; i++) arr[i] = 0;
                }
            } while (idx > 0);
        }
        static void printArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.Write("\n");
        }
    }
}
