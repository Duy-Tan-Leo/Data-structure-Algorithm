using System;

namespace Binary_Generation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Binary generation");
            int n = 10;
            int[] output = new int[n];
            int current_idx;
            do
            {
                PrintMessage(output);
                current_idx = n;
                while(current_idx >0 && output[current_idx - 1] == 1) current_idx--;
                if(current_idx > 0)
                {
                    output[current_idx - 1] = 1;
                    for(int i =current_idx; i<n; i++){
                        output[i] = 0;
                    }
                }
            }while(current_idx > 0);
        }

        static void PrintMessage(int[] array){
            for(int i = 0; i< array.Length; i ++) Console.Write(array[i]);
            Console.Write("\n");
        }
    }
}
