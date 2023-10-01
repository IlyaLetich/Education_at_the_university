using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab_05
{
    static class СontrollerGift
    {
        public static void FindMinimalMassa(Component[] Gift)
        {
            double MinimalMassa = Gift[0].MassaComponent;
            int countMinMassa = 0;

            for (int i = 1; i < Gift.Length; i++)
            {
                if (Gift[i].MassaComponent < MinimalMassa)
                {
                    MinimalMassa = Gift[i].MassaComponent;
                    countMinMassa = i;
                }
            }
            Console.WriteLine($"{Gift[countMinMassa].ToString()}");
        }

        public static void calculatePrice(Component[] Gift)
        {
            int sumGift = 0;

            for (int i = 0; i < Gift.Length; i++)
            {
                sumGift += Gift[i].PriceComponent;
            }
            Console.WriteLine($"Сумма подарка = {sumGift};");
        }

        public static void ReadFile(ContainerGift collection,string patch)
        {
            string[] textFile = System.IO.File.ReadAllLines(patch);
            for (int i = 0; i < textFile.Length; i++) 
            {
                string[] dwordLine = textFile[i].Split(' ');
                // имя цена масса объём
                collection.Add(new Component(Convert.ToDouble(dwordLine[3]), Convert.ToDouble(dwordLine[2]), Convert.ToInt32(dwordLine[1]), dwordLine[0]));
            }
        }

        public static void ReadFileJson(ContainerGift collection, string patch)
        {
            string textJson = File.ReadAllText(patch);
            Component[] components = JsonSerializer.Deserialize<Component[]>(textJson);
            for(int i = 0; i < components.Length; i++)
            {
                collection.Add(components[i]);
            }
        }

    }
}
