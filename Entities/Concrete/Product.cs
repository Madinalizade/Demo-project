using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product :IEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitOnOrder { get; set; }
        public int CategoryId { get; set; }
        public int SuppliesId { get; set; }
    }
}
