using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] calorie = new int[protein.Length];
            for (int i = 0; i < protein.Length; i++)
                calorie[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;
            int[] bestFood = new int[dietPlans.Length];
            for(int i=0;i<dietPlans.Length;i++)
            {
                List<int> Temp = new List<int>();
                for (int j = 0; j < protein.Length; j++)
                    Temp.Add(j);
                
                    for(int j=0;j<dietPlans[i].Length;j++)
                    {
                        if (dietPlans[i][j] == 'C')
                            Temp = MaxCompare(carbs, Temp);
                        else if (dietPlans[i][j] == 'c')
                            Temp = MinCompare(carbs, Temp);
                        else if (dietPlans[i][j] == 'P')
                            Temp = MaxCompare(protein, Temp);
                        else if (dietPlans[i][j] == 'p')
                            Temp = MinCompare(protein, Temp);
                        else if (dietPlans[i][j] == 'F')
                            Temp = MaxCompare(fat, Temp);
                        else if (dietPlans[i][j] == 'f')
                            Temp = MinCompare(fat, Temp);
                        else if (dietPlans[i][j] == 'T')
                            Temp = MaxCompare(calorie, Temp);
                        else if (dietPlans[i][j] == 't')
                            Temp = MinCompare(calorie, Temp);
                        if (Temp.Count == 1)
                        {
                            bestFood[i] = Temp[0];
                            break;
                        }

                    }
                if (Temp.Count > 1)
                    bestFood[i] = Temp[0];

            }
            return bestFood;
        }

        public static List<int> MaxCompare(int[] arr, List<int> Temp)
        {
            List<int> Temp1 = new List<int>();
            int max = arr[Temp[0]];
            for (int i = 1; i < Temp.Count; i++)
                if (arr[Temp[i]] > max)
                    max = arr[Temp[i]];
            for (int i = 0; i < Temp.Count; i++)
                if (arr[Temp[i]] == max)
                    Temp1.Add(Temp[i]);
            return Temp1;
        }
        public static List<int> MinCompare(int[] arr, List<int> Temp)
        {
            List<int> Temp1 = new List<int>();
            int min = arr[Temp[0]];
            for (int i = 1; i < Temp.Count; i++)
                if (arr[Temp[i]] < min)
                    min = arr[Temp[i]];
            for (int i = 0; i < Temp.Count; i++)
                if (arr[Temp[i]] == min)
                    Temp1.Add(Temp[i]);
            return Temp1;
        }
    }
}
