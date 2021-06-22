using System;

namespace Permutation_Generation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Permutation Generation");
            int n = 5;
            int[] array = new int[n];
            //initialize the firstmost element
            for (int i = 1; i <= n; i++) array[i - 1] = i;

            int idx;
            do
            {
                PrintArray(array);
                idx = n;
                // Looking from down to up to find the index that need to be swapped.
                // It comply 2 condition: 
                // It had'nt to be the firstmost element
                // The previous element have to lower than the current index of element.
                while (idx > 1 && array[idx - 1] < array[idx - 2]) idx--;
                if (idx > 1)
                {
                    int k = n;
                    // Find the element that higher enough than the current index and swap.
                    while (array[k - 1] < array[idx - 2]) k--;
                    if (k > 0)
                    {
                        int temp = array[idx - 2];
                        array[idx - 2] = array[k - 1];
                        array[k - 1] = temp;
                    }
                    int i;
                    // Sorting again to find the smallest premutation in comparasion with current preference.
                    do
                    {
                        i = idx;
                        while(i<n && array[i] > array[i-1]) i++;
                        if (i < n)
                        {
                            int temp = array[i];
                            array[i] = array[i-1];
                            array[i-1] = temp;
                        }
                    } while (i < n);
                }
            } while (idx > 1);
        }
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i]);
            Console.Write("\n");
        }
    }
}
