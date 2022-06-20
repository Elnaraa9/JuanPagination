using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductCategories
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
    }
}
