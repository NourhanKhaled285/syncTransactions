using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using SyncProject.BLL;
using SyncProject.DAL;

namespace SyncTransactions.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            // 1. ViewData is a Dictionary Object (introduced in ASP.NET Framework 3.5)
            //      => It helps us to transfer the data from controller to view
            ViewData["Message"] = "Hello ViewData";
            // 2. ViewBag is a Dynamic Property (introduced in ASP.NET Framework 4.0 based on dynamic Feature)
            //      => It helps us to transfer the data from controller to view
            ViewBag.Message = "Hello ViewBag";

            TempData.Keep(); // Keep TempData in Session Storage
            return View(await categoryRepository.GetAll());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var Category = await categoryRepository.Get(id);
            if (Category == null)
                return NotFound();
            return View(Category);
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                await categoryRepository.Add(category);
                // 3. TempData is a Dictionary Object (introduced in ASP.NET Framework 3.5)
                //  =>  It is used to pass data between two consecutive requests.
                TempData["Message"] = "category is created successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var Category = await categoryRepository.Get(id);
            if (Category == null)
                return NotFound();
            return View(Category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryId)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await categoryRepository.Update(category);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(category);
                }
            }
            return View(category);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var Category = await categoryRepository.Get(id);
            if (Category == null)
                return NotFound();
            return View(Category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Category category)
        {
            if (id != category.CategoryId)
                return NotFound();
            try
            {
                await categoryRepository.Delete(category);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(category);
            }
        }
    }
}
