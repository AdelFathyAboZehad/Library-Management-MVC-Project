
using Microsoft.EntityFrameworkCore;
using Task4Linkerp.Models.Domian;
using Task4Linkerp.ViewModel.Borrowed;

namespace Task4Linkerp.Models.Repositories
{
    public interface IBorrowedRepository:IRepository<Borrowed>
    {
        Task<Borrowed?> GetBorroredDetailAsync(ReturnedViewModel returnedViewModel);
        Task<Borrowed?> GetBorrpwedAsync(Borrowed Item);
        


    }
}
