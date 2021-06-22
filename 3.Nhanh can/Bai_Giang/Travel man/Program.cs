using System;
using System.IO;
namespace Travel_man
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string current_path = Directory.GetCurrentDirectory();
            string file_name = "Debai.txt";

            string string_path = Path.Combine(current_path, file_name);
            string[] data = File.ReadAllLines(string_path);

            int number_of_city = ParseNumber(data[0][0].ToString());
            int number_of_traffic = ParseNumber(data[0][0].ToString());

            int max = int.MaxValue;
            int[,] cost = new int[number_of_city, number_of_city];

            for (int i = 0; i < number_of_city; i++)
            {
                for (int j = 0; j < number_of_city; j++)
                {
                    if (i == j) cost[i, j] = 0;
                    else cost[i, j] = max;
                }
            }

            for (int k = 1; k < data.Length; k++)
            {
                int point_1 = ParseNumber(data[k][0].ToString());
                int point_2 = ParseNumber(data[k][2].ToString());
                int expense = ParseNumber(data[k][4].ToString());

                cost[point_1 - 1, point_2 - 1] = expense;
                cost[point_2 - 1, point_1 - 1] = expense;
            }

            int[] root = new int[number_of_city];
            int[] result = new int[number_of_city];
            int[] temp_cost = new int[number_of_city];

            int minSpending = int.MaxValue;
            bool[] marked_route = new bool[number_of_city];

            marked_route[0] = true; //Bo qua thanh pho 1
            root[0] = 1; // Xuat phat tu thanh pho 1
            temp_cost[0] = 0; // Chi phi ban dau bang 0

            Try(2); // Bat dau tu thanh pho 2

            Console.Write("");

            void Try(int m)
            {
                for (int j = 2; j <= number_of_city; j++) // go through all remaining city.
                {
                    if (!marked_route[j - 1]) // if this city wasn't visited
                    {
                        root[m - 1] = j;
                        int previousCity = root[m - 2] - 1;
                        int currentCity = j - 1;
                        temp_cost[m - 1] = temp_cost[m - 2] + cost[previousCity, currentCity]; //previous + current cost
                        
                        string currentRoute = "";
                        foreach(int item in root) currentRoute += item.ToString() + " -> ";

                        Console.WriteLine("current route: " + currentRoute);
                        Console.Write("From city " + (previousCity + 1).ToString());
                        Console.Write(" to city " + (currentCity + 1).ToString());
                        Console.Write(" - cost" + (cost[previousCity, currentCity]).ToString());
                        Console.Write(" - Total Cost " + (temp_cost[m - 1]).ToString() + "\n");

                        if (temp_cost[m - 1] < minSpending)
                        {
                            if (m < number_of_city) // It's not the last city
                            {
                                marked_route[j - 1] = true;
                                Try(m + 1);
                                marked_route[j - 1] = false;
                            }
                            else
                            {
                                if (temp_cost[number_of_city - 1] + cost[j - 1, 0] < max)
                                {
                                    for (int i = 0; i < root.Length; i++) result[i] = root[i];
                                    minSpending = temp_cost[number_of_city - 1] + cost[j - 1, 0];

                                    Console.Write("From city " + (j - 1 + 1).ToString());
                                    Console.Write(" to city " + (1).ToString());
                                    Console.Write(" - cost" + (cost[j - 1 , 0]).ToString());
                                    Console.Write(" - Total Cost " + (minSpending).ToString() + "\n");
                                }
                            }
                        }
                    }
                }
            }

            int ParseNumber(string str)
            {
                return Int16.Parse(str, System.Globalization.NumberStyles.Integer);
            }
        }
    }
}
