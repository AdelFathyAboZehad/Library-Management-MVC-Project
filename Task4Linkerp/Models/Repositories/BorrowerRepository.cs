using Microsoft.EntityFrameworkCore;
using Task4Linkerp.Models.Context;
using Task4Linkerp.Models.Domian;

namespace Task4Linkerp.Models.Repositories
{
    public class BorrowerRepository:Repository<Borrower>,IBorrowerRepository
    {
        

        public BorrowerRepository(DBContext context):base(context)
        {
         
        }
        public Task<IEnumerable<Borrower>> FilterByAsync(string? filter = null, int? code = null)
        {

            IEnumerable<Borrower> FilterCitiesQuery =
                _context.Borrowers.
                Include(borroweds=>borroweds.Borroweds).
                Where(a => filter == null || a.NameEN.ToLower().Contains(filter.ToLower()) || a.NameAR.ToLower().Contains(filter.ToLower()));

            return Task.FromResult(FilterCitiesQuery);

        }
    }
}
