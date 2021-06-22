using System;

namespace _10th_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[] arr = new int[n];
            arr[0] = n;
            int i = 0;

            int counterOfOne = 0;

            while (arr[0] != 0)
            {
                for (int m = n - 1; m > 0; m--)
                {
                    FindParentValue(n, m, arr);
                    bool continuePoint = true;
                    do
                    {
                        Print(arr);
                        if (arr[1] == 1) break;
                        i = n;
                        counterOfOne = 0;
                        // find item that higher than 1
                        // Total left  
                        while ((arr[i - 1] == 1 || arr[i - 1] == 0) && i > 0)
                        {
                            i--;
                            //switch the last item.
                            if (arr[i - 1] == 1)
                            {
                                counterOfOne++;
                                arr[i] = 1;
                                arr[i - 1] = 0;
                            }
                        }
                    
                        if (i > 0)
                        {
                            int sum = 0;
                            arr[i - 1]--;
                            //Total right after change
                            for (int temp = 0; temp < i; temp++) sum += arr[temp];
                            //Overall sum - total left - total right
                            arr[i] = n - sum - counterOfOne;
                        }
                    } while (continuePoint);
                    
                    for (int temp = 0; temp < n; temp++) arr[temp] = 0;
                }
            }
        }

        static void FindParentValue(int sum, int startValue, int[] arr)
        {
            // int sum = 14;
            // int startValue = 4;

            int currentValue = startValue;
            int nextvalue;
            int i = 0;
            while (sum > 0)
            {
                arr[i] = currentValue;
                // Console.WriteLine(currentValue.ToString() + "");
                nextvalue = sum - currentValue;
                if (nextvalue < currentValue)
                {
                    currentValue = nextvalue;
                }
                sum -= startValue;
                i++;
            }

        }

        static void Print(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write((arr[i] == 0 ? "" : arr[i] + " "));
            }
            Console.Write("}\n");
        }
    }
}
