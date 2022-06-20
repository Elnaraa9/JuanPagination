using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ShopController:Controller
    {
        private AppDbContext _context { get; }
        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pg = 1)
        {
            var products = _context.Products.Where(p => !p.IsDeleted).Include(p => p.Images).ToList();
            const int pageSize = 12;
            if (pg < 1)

                pg = 1;

            int recsCount = products.Count();
            var pagination = new Pagination(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;


            var data = products.Skip(recSkip).Take(pagination.PageSize).ToList();
            this.ViewBag.Pagination = pagination;

            ShopViewModel shop = new ShopViewModel
            {
                Products = data,
                ProductImages = _context.ProductImages.ToList(),
                Categories = _context.Categories.ToList()
            };
            return View(shop);
        }
    }
}

