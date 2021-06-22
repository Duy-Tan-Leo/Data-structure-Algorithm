using System;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int n = 5, k = 3;
            int[] current_array = new int[k];

            //Initialize first preference
            for (int i = 0; i < k; i++)
            {
                current_array[i] = i;
            }

            int current_index;
            do
            {
                PrintMessage(current_array);
                current_index = k;
                
                while (current_index > 0 && current_array[current_index - 1] == n - k + current_index)
                    current_index--; 
                // This process is using for teminating the iteration. 
                //In case of the lastmost element get highest number that it should be, the iteration will end.

                if (current_index > 0)
                {
                    current_array[current_index - 1]++;
                    for (int i = current_index; i < k; i++)
                    {
                        current_array[i] = current_array[i - 1] + 1;
                    }
                }
            }
            while (current_index > 0);
            Console.WriteLine(0);
        }

        static void PrintMessage(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i]);

            Console.Write("\n");
        }
    }
}
