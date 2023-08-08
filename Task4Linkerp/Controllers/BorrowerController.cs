using Microsoft.AspNetCore.Mvc;
using Task4Linkerp.Models.Repositories;
using Task4Linkerp.ViewModel.Book;
using Task4Linkerp.Models.Domian;

namespace Task4Linkerp.Controllers
{
    public class BorrowerController : Controller
    {
        private readonly IBorrowerRepository _borrowerRepository;

        public BorrowerController(IBorrowerRepository BorrowerRepository)
        {
           
            _borrowerRepository = BorrowerRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _borrowerRepository.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await _borrowerRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            var borrower = (await _borrowerRepository.GetByIdAsync(id));
            if (borrower == null)
            {
                return NotFound();
            }

            return View(borrower);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Borrower borrower)
        {
            if (!ModelState.IsValid)
            {
                return View(borrower);
            }

            try
            {
                await _borrowerRepository.CreateAsync(borrower);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(borrower);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View(id);
            try
            {
                Borrower? Borrower = await _borrowerRepository.GetByIdAsync(id);
                if (Borrower != null)
                    return View(Borrower);

                return View(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Borrower borrower)
        {

            if (!ModelState.IsValid)
                return View(borrower);
            try
            {
                await _borrowerRepository.UpdateAsync(borrower);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(borrower);
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
                await _borrowerRepository.DeleteAsync(id);
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
