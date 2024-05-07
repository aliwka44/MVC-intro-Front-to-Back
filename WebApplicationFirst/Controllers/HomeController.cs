﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationFirst.DataAccesLayer;
using WebApplicationFirst.Models;
using WebApplicationFirst.ViewModels.Catagories;


namespace WebApplicationFirst.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly PrionaContext _context;
        public HomeController(PrionaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data =await _context.Categories
                .Where(x=>x.IsDeleted == false)
                .Select(x=> new GetCategoryVM
                {
                    Id= x.Id,
                    Name= x.Name,
                }
                ).ToListAsync();
            return  View(data);
        }
        public async Task<IActionResult> Test(int? id)
        {
            //if (string.IsNullOrWhiteSpace(name)) return BadRequest();
            // Category cat = new Category
            // {
            //     Name = name,
            //     CreatedTime = DateTime.Now,
            //     IsDeleted = false
            // };
            //await _context.Categories.AddAsync(cat);
            //    await _context.SaveChangesAsync();
            if (id == null || id < 1) return BadRequest();
           var cat= await _context.Categories.FindAsync(id);
            if (cat == null) return NotFound();
            _context.Remove(cat);
            await _context.SaveChangesAsync();
            return Content(cat.Name);
        }
        public async Task<IActionResult> Contact()
        {
            return new ViewResult();
        }
    }
}
