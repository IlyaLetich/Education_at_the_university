using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03
{
    public class ProductNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string productName)
            {
                if (productName != "product" || productName != "Product")
                    return true;
                else
                    ErrorMessage = "Непонятный продукт";
            }
            return false;
        }
    }
}
