using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {   
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
