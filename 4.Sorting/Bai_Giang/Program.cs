using System;

namespace Bai_Giang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to method of sort");

            int choice = 8;

            int[] sortArr = new int[] { 100, 2, 5, 6, 7, 2, 2, 4, 9, 8, 0, 10, 14, 13, 2, 25, 74, 23, 54, 75, 87, 54, 32, 24, 74, 300, 200, 234, 123, 999, 1};
            // 

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Normal sort");
                    sortArr = NormalSort(sortArr);
                    break;

                case 2:
                    Console.WriteLine("Selection sort sort");
                    sortArr = SelectionSort(sortArr);
                    break;

                case 3:
                    Console.WriteLine("BubbleSort sort");
                    sortArr = BubbleSort(sortArr);
                    break;

                case 4:
                    Console.WriteLine("Insertion Sort");
                    sortArr = InsertionSort(sortArr);
                    break;

                case 5:
                    Console.WriteLine("Shell Sort");
                    sortArr = ShellSort(sortArr);
                    break;

                case 6:
                    Console.WriteLine("Quick Sort");
                    sortArr = QuickSort(sortArr);
                    break;

                case 7:
                    Console.WriteLine("Heap Sort");
                    // PrintTree(sortArr);
                    sortArr = HeapSort(sortArr);
                    break;

                case 8:
                    Console.WriteLine("Distribution Counting Sort");
                    // PrintTree(sortArr);
                    sortArr = DistributionCountingSort(sortArr);
                    break;
            }


            PrintArr(sortArr);
        }

        static int[] DistributionCountingSort(int[] arr)
        {
            int[] countingArr = new int[999 + 1];
            for(int i = 0; i < arr.Length; i++)
            {
                countingArr[arr[i]]++;
            }
            
            int idx = 0;
            for(int i = 0; i < countingArr.Length; i++)
            {
                int number_number = countingArr[i];
                while(number_number != 0)
                {
                    arr[idx] = i;
                    number_number--;
                    idx++;
                }
            }

            return arr;
        }

        static int[] HeapSort(int[] arr)
        {
            for (int i = arr.Length / 2; i > 0; i--) Adjust(i, arr.Length); // Create heap.
            // Swap(arr, 1, arr.Length - 1);
            // Adjust(0, arr.Length - 2);
            PrintArr(arr);

            for (int i = arr.Length; i > 1; i--) 
            {
                Swap(arr, 0, i - 1); // Push highest item to the end of array.
                Adjust(1, i - 1); // Heaping again.
            }

            void Adjust(int root, int endnode)
            {
                int rootValue = arr[root - 1];
                while (root * 2 <= endnode)
                {
                    int leftNode = root * 2;
                    int rightNode = root * 2 + 1;

                    int valueLeftNodeIndex = leftNode - 1;
                    int valueRightNodeIndex = rightNode - 1;

                    int swapNode = leftNode;
                    if (leftNode < endnode && arr[valueLeftNodeIndex] < arr[valueRightNodeIndex]) swapNode = rightNode;

                    if (arr[swapNode - 1] <= rootValue) break;
                    arr[root - 1] = arr[swapNode - 1];
                    root = swapNode;
                }
                arr[root - 1] = rootValue;
                PrintArr(arr);
            }
            return arr;
        }
        static int[] QuickSort(int[] arr)
        {
            Partition(0, arr.Length - 1);

            void Partition(int l, int h)
            {
                int pivot = arr[(l + h) / 2]; // Key here
                if (l < h)
                {
                    int i = l, j = h;
                    do
                    {
                        while (arr[i] < pivot) i++;
                        while (arr[j] > pivot) j--;
                        if (i <= j)
                        {
                            Swap(arr, i, j);
                            i++;
                            j--;
                        }
                        PrintArr(arr);
                    } while (i <= j);
                    Partition(l, j);
                    Partition(i, h);
                }
            }
            return arr;
        }
        static int[] ShellSort(int[] arr) // An improvement of InsertionSort
        {
            int h = arr.Length / 2;
            while (h != 0)
            {
                for (int i = h + 1; i < arr.Length; i++)
                {
                    int temp = arr[i], j = i - h;
                    while (j >= 0 && arr[j] > temp)
                    {
                        arr[j + h] = arr[j];
                        j -= h;
                    }
                    arr[j + h] = temp;
                }
                h = h / 2;
            }
            return arr;
        }
        static int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++) // Start with 2nd position.
            {
                int temp = arr[i]; // Clear value of 2nd position.
                int j = i - 1; // Finding from this position to the top.
                while (j >= 0 && temp < arr[j]) // If exsist an item that higher than highest one, push it back one index.
                //then do it until can't find the new one.
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp; //add selection value to new position to make a new sorting array.
            }
            return arr;
        }
        static int[] BubbleSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j >= i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        Swap(arr, j, j - 1);
                    }
                }
            }
            return arr;
        }
        static int[] SelectionSort(int[] arr)
        {
            int min;
            for (int i = 0; i < arr.Length; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if (i != min)
                {
                    Swap(arr, min, i);
                }
            }
            return arr;
        }
        static int[] NormalSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        Swap(arr, j, i);
                    }
                }
            }
            return arr;
        }
        static void Swap(int[] arr, int idx1, int idx2)
        {
            int temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }
        static void PrintArr(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i].ToString() + " ");
            }
            Console.WriteLine("}");
        }
        static void PrintTree(int[] arr)
        {
            int n = arr.Length;
            int numSpace = n / 2;
            string space = new string(' ', numSpace);
            Console.Write(space + arr[0].ToString() + "\n");
            for (int i = 1; i < n; i++)
            {
                string spaceHeader = new string(' ', numSpace + 1);
                string spaceAfter = new string(' ', i * 2 + 1);
                if (i % 2 != 0) Console.Write(spaceHeader + arr[i].ToString());
                else
                {
                    numSpace--;
                    Console.Write(spaceAfter + arr[i].ToString() + "\n");
                }
            }
        }
    }
}
