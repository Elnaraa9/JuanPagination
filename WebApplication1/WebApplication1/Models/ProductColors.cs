using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductColors
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorID { get; set; }
        public Products Product { get; set; }
        public Colors Color { get; set; }
    }
}
