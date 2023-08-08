
using Task4Linkerp.Models.Domian;
using Task4Linkerp.ViewModel.Book;

namespace Task4Linkerp.Models.Repositories
{
    public interface IBookRepository:IRepository<Book>
    {
        Task<IEnumerable<Book>> FilterByAsync(string? filter = null, int? code = null);
        //Task<Book?> GetByIdAllDetailsAsync(int id);
        Task<Book?> GetByNameAllDetailsAsync(CreateBookViewModel createBookViewModel);
    }
}
