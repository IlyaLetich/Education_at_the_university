using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05
{
    struct ModelCar
    {
        string NameCar { get; set; }
        string BrandCar { get; set; }

        public ModelCar(string nameCar, string brandCar)
        {
            NameCar = nameCar;
            BrandCar = brandCar;
        }
    }
    enum PriceCar
    {
        Lada = 1_000,
        MercedesBenz = 100_000,
        Pagani = 1_000_000,
        RollsRoys = 10_000_000,
    }
}
