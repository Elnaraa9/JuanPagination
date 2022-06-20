using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Areas.JuanAdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class SliderController : Controller
    {
        [Area("AdminPanel")]
        public class SlideController : Controller
        {
            private AppDbContext _context { get; }
            private IWebHostEnvironment _env { get; }
            public SlideController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
            public IActionResult Index()
            {
                return View(_context.Slides);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Sliders slide)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                if (!slide.Photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "Max size image must be less than 200kb");
                    return View();
                }
                if (!slide.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Type of file must be image");
                    return View();
                }

                slide.Image = await slide.Photo.SaveFileAsync(_env.WebRootPath, "assets", "images", "slider");
                await _context.Slides.AddAsync(slide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return BadRequest();
                }
                var slider = _context.Slides.Find(id);
                if (slider == null)
                {
                    return NotFound();
                }
                var path = Helper.GetPath(_env.WebRootPath, "assets", "images", "slider", slider.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _context.Slides.Remove(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            public IActionResult Update(int? id)
            {
                if (id == null)
                {
                    return BadRequest();
                }
                var slide = _context.Slides.Find(id);
                if (slide == null)
                {
                    return NotFound();
                }
                return View(slide);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> UpdateAsync(int? id, Sliders slide)
            {
                if (id == null)
                {
                    return BadRequest();
                }
                var slider = _context.Slides.Find(slide.Id);
                if (slider == null)
                {
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    return View();
                }
                if (!slide.Photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "Max size image must be less than 200kb");
                    return View();
                }
                if (!slide.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Type of file must be image");
                    return View();
                }
                slide.Image = await slide.Photo.SaveFileAsync(_env.WebRootPath, "assets", "images", "slider");
                await _context.Slides.AddAsync(slide);
                await _context.SaveChangesAsync();
                var _slide = _context.Slides.Find(id);
                if (_slide == null)
                {
                    return NotFound();
                }
                var path = Helper.GetPath(_env.WebRootPath, "assets", "images", "slider", _slide.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _context.Slides.Remove(_slide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
