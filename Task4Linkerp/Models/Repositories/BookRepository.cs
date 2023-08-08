using Microsoft.EntityFrameworkCore;
using Task4Linkerp.Models.Context;
using Task4Linkerp.Models.Domian;
using Task4Linkerp.ViewModel.Book;

namespace Task4Linkerp.Models.Repositories
{
    public class BookRepository:Repository<Book>, IBookRepository
    {
        

        public BookRepository(DBContext context):base(context) 
        {
            
        }

        public Task<IEnumerable<Book>> FilterByAsync(string? filter = null, int? code = null)
        {

            IEnumerable<Book> FilterCitiesQuery =
                _context.Books.
                Include(c=>c.Category).
                Include(borroweds=>borroweds.Borroweds).
                Where(a => filter == null || a.NameEN.ToLower().Contains(filter.ToLower()) || a.NameAR.ToLower().Contains(filter.ToLower()));

            return Task.FromResult(FilterCitiesQuery);

        }
        //public async Task<Book?> GetByIdAllDetailsAsync(int id)
        //{
        //    return await (_dbset.Include(c=>c.Category).FirstOrDefaultAsync(p => p.Id == id));
        //}
        public async Task<Book?> GetByNameAllDetailsAsync(CreateBookViewModel createBookViewModel)
        {
            return await (_dbset.Include(c => c.Category).FirstOrDefaultAsync(b => b.NameEN == createBookViewModel.NameEN));// && b.Author==createBookViewModel.Author));
        }
        public override async Task<Book?> GetByIdAsync(int id)
        {
            return await (_dbset.Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == id));
        }
    }
}
