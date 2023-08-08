using Task4Linkerp.Models.Context;
using Task4Linkerp.Models.Domian;

namespace Task4Linkerp.Models.Repositories
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DBContext context):base(context) 
        {

        }
    }
}
