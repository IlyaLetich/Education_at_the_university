using System;

namespace KR_OOP_01
{
    public class Program
    {
        interface IHuge
        {
            Recipe Huge(Recipe[] recipes);
        }

        public class Recipe : IComparable<Recipe>
        {
            public string author { get; set; }
            public string title { get; set; }

            public List<String> steps = new List<string>();

            public static bool operator true(Recipe recipe)
            {
                if( recipe.steps.Count == 0 ) return false;
                return true;
            }

            public static bool operator false(Recipe recipe)
            {
                if (recipe.steps.Count == 0) return true;
                return false;
            }

            public int CompareTo(Recipe? recipe)
            {
                return this.steps.Count.CompareTo(recipe.steps.Count);
            }

            public static bool operator >(Recipe recipe_01, Recipe recipe_02)
            {
                if(recipe_01.steps.Count > recipe_02.steps.Count) return true;

                return false;
            }
            public static bool operator <(Recipe recipe_01, Recipe recipe_02)
            {
                if (recipe_01.steps.Count < recipe_02.steps.Count) return true;

                return false;
            }

            public static bool operator ==(Recipe recipe_01, Recipe recipe_02)
            {
                if (recipe_01.steps.Count == recipe_02.steps.Count) return true;

                return false;
            }
            public static bool operator !=(Recipe recipe_01, Recipe recipe_02)
            {
                if (recipe_01.steps.Count == recipe_02.steps.Count) return false;

                return false;
            }

        }

        public class Book : IHuge
        { 
            public Recipe Huge(Recipe[] recipes)
            {
                Recipe recipeMax = recipes[0];
                
                for(int i = 0; i < recipes.Length; i++)
                {
                    if (recipes[i].steps.Count > recipeMax.steps.Count) recipeMax = recipes[i];
                }

                return recipeMax;
            }
        }


        static void Main()
        {

            // --------- 1 ЗАДАНИЕ(А) -------------

            Console.WriteLine("--------- 1 ЗАДАНИЕ(А) -------------\n");

            Console.Write("Введите первое число: ");
            int numUser_01 = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int numUser_02 = int.Parse(Console.ReadLine());

            string resultSum = (numUser_01 + numUser_02).ToString();

            Console.WriteLine($"Сумма двух чисел = {resultSum}");

            // --------- 1 ЗАДАНИЕ(Б) -------------

            Console.WriteLine("\n--------- 1 ЗАДАНИЕ(Б) -------------\n");

            string[,] arrayString = new string[2,2] { { " друг", " дорогой" }, { " мой", "Привет" } };

            for (int i = 1; i >= 0; i--) 
            {
                for (int j = 1; j >= 0; j--)
                    Console.Write(arrayString[i,j]);
            }

            // ----------- 2 ЗАДАНИЕ --------------

            Console.WriteLine("\n----------- 2 ЗАДАНИЕ --------------\n");

            Recipe recipe_01 = new Recipe();
            recipe_01.steps.Add("Привет");
            recipe_01.steps.Add("Друг");

            Recipe recipe_02 = new Recipe();
            recipe_02.steps.Add("Привет");
            recipe_02.steps.Add("Дорогой");
            recipe_02.steps.Add("Друг");

            Console.WriteLine($"Рельтать recipe_02.CompareTo(recipe_01) = {recipe_02.CompareTo(recipe_01)}");
            Console.WriteLine($"Рельтать recipe_02 > recipe_01 = {recipe_02 > recipe_01}");
        }
    }
}