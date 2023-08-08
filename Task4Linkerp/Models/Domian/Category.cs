using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace Task4Linkerp.Models.Domian
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Name(EN)")]
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        [Display(Name = "Name(AR)")]
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public Category(string nameEN, string nameAR)
        {
            NameEN = nameEN;
            NameAR = nameAR;
            Books = new List<Book>();



        }
        public Category() : this(null!, null!) { }
    }
}
