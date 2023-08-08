using Microsoft.AspNetCore.Mvc;
using Task4Linkerp.Models.Repositories;
using Task4Linkerp.ViewModel.Book;
using Task4Linkerp.Models.Domian;

namespace Task4Linkerp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookController(IBookRepository bookRepository,ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index(string? searchString)
        {
            IEnumerable<Book> books = await _bookRepository.FilterByAsync(searchString);
            List<AllBooksViewModel> allBooks = new List<AllBooksViewModel>();
           
            foreach(var book in books)
            {

                allBooks.Add(new(book.Id,book.Code, book.NameEN, book.NameAR, book.Author, book.Quantity, book.Category.NameEN, book.Category.NameAR));
            }
            return View(allBooks);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await _bookRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            var book = (await _bookRepository.GetByIdAsync(id));
            if (book == null)
            {
                return NotFound();
            }

            return View(new DetailsBookViewModel()
            {
                Id = book.Id,
                Code=book.Code,
                NameEN = book.NameEN,
                NameAR = book.NameAR,
                Author= book.Author,
                Publisher=book.Publisher,
                Quantity = book.Quantity,
                Price=book.Price,
                CategoryNameEN = book.Category.NameEN,
                CategoryNameAR = book.Category.NameAR,


            });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _categoryRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookViewModel createBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBookViewModel);

            }

            try
            {
                Book? OldBook = await _bookRepository.GetByNameAllDetailsAsync(createBookViewModel);
                if(OldBook!=null)
                {
                    OldBook.Quantity =(OldBook.Quantity + createBookViewModel.Quantity);
                    await _bookRepository.UpdateAsync(OldBook);
                    return RedirectToAction("Index");
                }
                else
                {
                    Category? category = await _categoryRepository.GetByIdAsync(createBookViewModel.CategoryId);
                    Book book = new Book(
                        createBookViewModel.Code,
                        createBookViewModel.NameEN,
                        createBookViewModel.NameAR,
                        createBookViewModel.Author,
                        createBookViewModel.Publisher,
                        category,
                        createBookViewModel.Quantity,
                        createBookViewModel.Price
                        );
                    await _bookRepository.CreateAsync(book);
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(createBookViewModel);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!ModelState.IsValid)
                return View(id);
            try
            {
                Book? book = await _bookRepository.GetByIdAsync(id);
                if (book != null)
                {
                    EditBookViewModel editBookViewModel = new EditBookViewModel
                        (
                        book.Id,
                        book.Code,
                        book.NameEN,
                        book.NameAR,
                        book.Author,
                        book.Publisher,
                        book.Quantity,
                        book.Price,
                        book.Category.Id

                        );
                    ViewBag.categories = await _categoryRepository.GetAllAsync();
                    return View(editBookViewModel);
                }
                  

                return View(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(id);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,EditBookViewModel editBookViewModel)
        {

            if (!ModelState.IsValid)
                return View(editBookViewModel);
            try
            {
              Category? category = await _categoryRepository.GetByIdAsync(editBookViewModel.CategoryId);
                Book? book = await _bookRepository.GetByIdAsync(id);
                if(book!=null)
                {
                    book.Code = editBookViewModel.Code;
                    book.NameEN = editBookViewModel.NameEN;
                    book.NameAR =editBookViewModel.NameAR;
                    book.Author= editBookViewModel.Author;
                    book.Publisher= editBookViewModel.Publisher;
                    book.Category = category;
                    book.Quantity = editBookViewModel.Quantity;
                    book.Price = editBookViewModel.Price;


                    await _bookRepository.UpdateAsync(book);
                    return RedirectToAction("Index");

                }

                return View(editBookViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(editBookViewModel);
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
                await _bookRepository.DeleteAsync(id);
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
