using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Sliders
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
