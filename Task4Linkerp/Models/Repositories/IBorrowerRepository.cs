
using Task4Linkerp.Models.Domian;

namespace Task4Linkerp.Models.Repositories
{
    public interface IBorrowerRepository:IRepository<Borrower>
    {
        Task<IEnumerable<Borrower>> FilterByAsync(string? filter = null, int? code = null);
    }
}
