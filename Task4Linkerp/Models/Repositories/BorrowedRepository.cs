using Microsoft.EntityFrameworkCore;
using System.Net;
using Task4Linkerp.Models.Context;
using Task4Linkerp.Models.Domian;
using Task4Linkerp.ViewModel.Borrowed;

namespace Task4Linkerp.Models.Repositories
{
    public class BorrowedRepository : Repository<Borrowed>, IBorrowedRepository
    {
        private readonly IBookRepository _bookRepository;

        public BorrowedRepository(DBContext context,IBookRepository bookRepository):base(context) 
        {
            _bookRepository = bookRepository;
        }

        public  async Task<Borrowed?> GetBorroredDetailAsync(ReturnedViewModel returnedViewModel)
        {
            var resualt = await _dbset.FirstOrDefaultAsync(b => b.BookId == returnedViewModel.BookId && b.BorrowerId == returnedViewModel.BorrowerId);
            if (resualt == null)
                return null;
            else
                return resualt;

        }
        public async Task<Borrowed?> GetBorrpwedAsync(Borrowed Item)
        {
            var resualt = await _dbset.Include(b=>b.Book).Include(bor=> bor.Borrower).FirstOrDefaultAsync(b => b.BookId == Item.BookId && b.BorrowerId == Item.BorrowerId);
            if (resualt == null)
                return null;
            else
                return resualt;

        }
    }
}
