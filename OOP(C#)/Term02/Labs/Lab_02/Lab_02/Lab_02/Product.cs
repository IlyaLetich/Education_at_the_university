using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    [DataContract]
    internal class Product
    {
        [DataMember]
        internal string Name;
        [DataMember]
        internal string InventoryNumber;
        [DataMember]
        internal double Size;
        [DataMember]
        internal double Weight;
        [DataMember]
        internal string Type;
        [DataMember]
        internal string DeliveryDate;
        [DataMember]
        internal int Quantity;
        [DataMember]
        internal double Price;

        [DataMember]
        internal Company CompanyProduct;
        [DataMember]
        internal Warehouseman WarehousemanProduct;

        public Product(string name, string inventoryNumber, double size, double weight, string type, string 
            deliveryDate, int quantity, double price, Company companyProduct, Warehouseman warehousemanProduct)
        {
            Name = name;
            InventoryNumber = inventoryNumber;
            Size = size;
            Weight = weight;
            Type = type;
            DeliveryDate = deliveryDate;
            Quantity = quantity;
            Price = price;
            CompanyProduct = companyProduct;
            WarehousemanProduct = warehousemanProduct;
        }

        public override string ToString()
        {
            return ($"Product name - {Name},\n Inventory number - {InventoryNumber}, Size - {Size}, " +
                $"Weight - {Weight}, Type - {Type}, Delivery date - {DeliveryDate}, Quantity - {Quantity}, " +
                $"Price - {Price}, Company - {CompanyProduct.Organization}, Warehouseman - {WarehousemanProduct.FIO}");
        }
    }
}
