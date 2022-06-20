using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HomeViewModel
    {
        public List<Sliders> Slides { get; set; }
        public List<Features> Features { get; set; }
        public List<Products> Products { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Blogs> Blogs { get; set; }
        public List<Brands> Brands { get; set; }
    }
}
