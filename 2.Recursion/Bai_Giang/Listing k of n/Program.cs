using System;

namespace Listing_k_of_n
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int k = 5;
            int[] arr = new int[k + 1];
            // RecursionOfListing(1, k, n, arr);
            int[] arrSelectedValue = new int[n];
            for (int i = 1; i <= n; i++) arrSelectedValue[i - 1] = i;
            RecursionOfPermutation(1, k, n, arr, arrSelectedValue);
        }

        static void RecursionOfListing(int j, int k, int n, int[] arr)
        {
            //Next value has to be higher than the previous one arr[j - 1] + 1;
            //We pretend that first value is 0.
            for (int i = arr[j - 1] + 1; i <= n; i++)
            {
                arr[j] = i;
                if (j == k) Print(arr);
                else
                {
                    RecursionOfListing(j + 1, k, n, arr);
                }
            }
        }

        static void RecursionOfPermutation(int j, int k, int n, int[] arr, int[] arrSelectedValue)
        {
            //Next value has to be higher than the previous one arr[j - 1] + 1;
            //We pretend that first value is 0.            
            int[] remainArrValue = new int[n];

            for (int i = 0; i < arrSelectedValue.Length; i++)
            {
                for (int l = 0; l < arrSelectedValue.Length; l++)
                {
                    remainArrValue[l] = arrSelectedValue[l];
                }

                //Bo qua cac phan tu da duoc chon
                if (remainArrValue[i] == 0) continue;

                arr[j] = remainArrValue[i];
                if (j == k) Print(arr);
                else
                {
                    remainArrValue[i] = 0;
                    RecursionOfPermutation(j + 1, k, n, arr, remainArrValue);
                }
            }
        }

        static void Print(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 1; i < arr.Length; i++) Console.Write(arr[i].ToString() + " ");
            Console.Write("}\n");
        }
    }
}
