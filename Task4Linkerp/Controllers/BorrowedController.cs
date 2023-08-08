using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task4Linkerp.Models.Context;
using Task4Linkerp.Models.Domian;
using Task4Linkerp.Models.Repositories;
using Task4Linkerp.ViewModel.Borrowed;

namespace Task4Linkerp.Controllers
{
    public class BorrowedController : Controller
    {
        private readonly IBorrowedRepository _borrowedRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowerRepository _borrowerRepository;

        public BorrowedController(IBorrowedRepository BorrowedRepository,IBookRepository bookRepository,IBorrowerRepository borrowerRepository)
        {
            _borrowedRepository = BorrowedRepository;
            _bookRepository = bookRepository;
            _borrowerRepository = borrowerRepository;
        }
        public async Task<IActionResult> Index()
        {
           var borroweds= await _borrowedRepository.GetAllAsync();
            List<AllBorrowedViewModel> allBorrowedViewModels= new List<AllBorrowedViewModel>();
            foreach (var borrowed in borroweds)
            {
                Book? book = await _bookRepository.GetByIdAsync(borrowed.BookId);
                Borrower? borrower = await _borrowerRepository.GetByIdAsync(borrowed.BorrowerId);
                if(book!=null&&borrower!=null)
                allBorrowedViewModels.Add(new(book.Id,borrower.PIN, borrower!.NameEN, book!.NameEN,borrowed.DateIssue,borrowed.DateReturned));

            }
            return View(allBorrowedViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await _borrowedRepository.GetAllAsync() == null)
            {
                return NotFound();
            }

            Borrowed? borrowed  = (await _borrowedRepository.GetByIdAsync(id));
            if (borrowed == null)
            {
                return NotFound();
            }
          
                Book? book = await _bookRepository.GetByIdAsync(borrowed.BookId);
                Borrower? borrower = await _borrowerRepository.GetByIdAsync(borrowed.BorrowerId);
                AllBorrowedViewModel allBorrowedViewModels = new AllBorrowedViewModel(book.Id, borrower.PIN, borrower!.NameEN, book!.NameEN, borrowed.DateIssue, borrowed.DateReturned);

                return View(allBorrowedViewModels);

        }

        [HttpGet]
        public async Task<IActionResult> Borrowing()
        {
            ViewBag.checkBorrowing = 0;
            ViewBag.borrowers =await _borrowerRepository.GetAllAsync();
            ViewBag.books = await _bookRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Borrowing(CreateBorrowedViewModel createBorrowedViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBorrowedViewModel);
            }

            try
            {
                ViewBag.borrowers = await _borrowerRepository.GetAllAsync();
                ViewBag.books = await _bookRepository.GetAllAsync();

                Borrowed NewBorrowed = new Borrowed(createBorrowedViewModel.PIN,createBorrowedViewModel.BorrowerId, createBorrowedViewModel.BookId, createBorrowedViewModel.DateIssue, createBorrowedViewModel.DateReturned);
                Book? book = await _bookRepository.GetByIdAsync(createBorrowedViewModel.BookId);
                Borrower? borrower = await _borrowerRepository.GetByIdAsync(createBorrowedViewModel.BorrowerId);
                Borrowed? OldBorrowed = await _borrowedRepository.GetBorrpwedAsync(NewBorrowed);
                if(OldBorrowed!= null&&book!=null&& OldBorrowed.Book.Id == createBorrowedViewModel.BookId && OldBorrowed.Borrower.Id == createBorrowedViewModel.BorrowerId)
                {
                        ViewBag.checkBorrowing = 1;
                        return View(createBorrowedViewModel);
                   

                }
                else if (borrower.PIN != createBorrowedViewModel.PIN)
                {
                    ViewBag.checkBorrowing = 2;
                    return View(createBorrowedViewModel);

                }
                else if (book.Quantity > 0)
                {
                    book.Quantity = book.Quantity - 1;
                    await _bookRepository.UpdateAsync(book);
                    await _borrowedRepository.CreateAsync(NewBorrowed);
                    return RedirectToAction("Index");
                }else
                {
                    ViewBag.checkBorrowing = 3;
                    return View(createBorrowedViewModel);
                }
                

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(createBorrowedViewModel);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Returned()
    {
            ViewBag.check = 0;
            ViewBag.borrowers = await _borrowerRepository.GetAllAsync();
            ViewBag.books = await _bookRepository.GetAllAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Returned(ReturnedViewModel returnedViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(returnedViewModel);
            }
            ViewBag.borrowers = await _borrowerRepository.GetAllAsync();
            ViewBag.books = await _bookRepository.GetAllAsync();
            try
            {

                  Borrowed? resualt = await _borrowedRepository.GetBorroredDetailAsync(returnedViewModel);
                    if (resualt != null && returnedViewModel.PIN != resualt.PIN)
                    {
                         ViewBag.check = 1;
                         return View(returnedViewModel);

                     }
                    else if (resualt != null)
                    {
                   
                        Book? book = await _bookRepository.GetByIdAsync(returnedViewModel.BookId);
                        book.Quantity = book.Quantity + 1;
                        await _bookRepository.UpdateAsync(book);
                       await _borrowedRepository.DeleteAsync(resualt.Id);
                       ViewBag.check = 2;
                        return View (returnedViewModel);

                    }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(returnedViewModel);
            }

               ViewBag.check = 3;
                return View(returnedViewModel);
          
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            try
            {
                await _borrowedRepository.DeleteAsync(id);
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
