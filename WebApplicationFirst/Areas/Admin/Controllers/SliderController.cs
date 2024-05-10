using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationFirst.DataAccesLayer;
using WebApplicationFirst.Models;
using WebApplicationFirst.ViewModels.Sliders;

namespace WebApplicationFirst.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly PrionaContext _context;
        public SliderController(PrionaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
          var data=  await _context.Sliders.Select(s=>new GetSliderVm
            {
                Discount = s.Discount,
                Id = s.Id,
                ImageUrl = s.ImageUrl,
                Subtitle    = s.Subtitle,
                    Title = s.Title           

            }).ToListAsync();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSliderVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            Slider slider = new Slider
            {
                Discount = vm.Discount,
                CreatedTime = DateTime.Now,
                ImageUrl = vm.ImageUrl,
                IsDeleted=false,
                Title = vm.Title,
            };
             _context.AddAsync(slider);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
