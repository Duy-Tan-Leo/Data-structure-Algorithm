using System;

namespace _4th_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap danh sach n ten nguoi");
            Console.WriteLine("Find k people in n people");
            //Bai nay la theo thu tu tu dien k phan tu cua n.
            // Chinh hop chap k cua n.
            int n = 10, k = 5;
            for(int i = 1; i <= k; i++){
                FindCombinationOf_k_in_n(i,n);
            }
            
        }
        
        static void FindCombinationOf_k_in_n(int k, int n){
            string[] arr_of_people = new string[n];
            for (int m = 0; m < n; m++)
                arr_of_people[m] = "Person " + m.ToString();

            int[] reflection_of_arr = new int[k];
            for (int m = 0; m < k; m++)
                reflection_of_arr[m] = m;

            int i;
            do
            {
                printName(reflection_of_arr, arr_of_people);
                //Tim tu duoi len tren
                i = k - 1;
                //Tim phan tu 
                
                int idx = k;
              
                while (i >= 0 && reflection_of_arr[i] == n - idx + 1)
                {
                    i--;
                    idx++;
                }

                if (i >= 0)
                {
                    reflection_of_arr[i]++;
                    for (int l = i + 1; l < k; l++)
                    {
                        reflection_of_arr[l] = reflection_of_arr[l - 1] + 1;
                    }
                }            

            } while (i >= 0);
        }

        static void printName(int[] arr, string[] arr2)
        {
            Console.Write("{");
            foreach (int i in arr)
            {
                Console.Write(arr2[i] + ',');
            }
            Console.Write("} \n");
        }
    }
}
