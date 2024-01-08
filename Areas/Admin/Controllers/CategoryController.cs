using AgencyWebSite.Areas.Admin.ViewModel;
using AgencyWebSite.DAL;
using AgencyWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgencyWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.Where(c=>c.IgnoreQuery==false).Include(c=>c.Products).ToListAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM vm)
        {
            if (!ModelState.IsValid) return View();

            bool isExist = await _context.Categories.AnyAsync(c => c.Name == vm.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This category is already exist");
                return View(vm);
            }

            Category category = new()
            {
                Name = vm.Name
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category is null) return NotFound();


            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category is null) return NotFound();

            CategoryUpdateVM vm = new()
            {
                Name = category.Name
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,CategoryUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category is null) return NotFound();

            bool isExisted = await _context.Categories.AnyAsync(c => c.Id != id && c.Name == vm.Name);
            if (isExisted)
            {
                ModelState.AddModelError("Name", "This Category is already existed");
                return View(vm);
            }


            category.Name = vm.Name;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
