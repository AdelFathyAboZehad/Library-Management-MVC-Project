using Microsoft.AspNetCore.Mvc;
using Task4Linkerp.Models.Repositories;
using Task4Linkerp.Models.Domian;

namespace Task4Linkerp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _categoryRepository.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await _categoryRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            Category? category = (await _categoryRepository.GetByIdAsync(id));
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                await _categoryRepository.CreateAsync(category);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(category);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View(id);
            try
            {
                Category? category = await _categoryRepository.GetByIdAsync(id);
                if (category != null)
                    return View(category);

                return View(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {

            if (!ModelState.IsValid)
                return View(category);
            try
            {
                await _categoryRepository.UpdateAsync(category);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(category);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            try
            {
                await _categoryRepository.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }

        }
    }
}
