using ProductProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public Product()
        {

        }

        public Product(int productId, string productName, decimal unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
        }

        public override string ToString()
        {
            return $"{ProductId,-5} {ProductName,-25} {UnitPrice,-10}";
        }
    }
}
