using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task4Linkerp.Models.Domian
{
    [Table("Book")]
    public class Book
    {

        public int Id { get; set; }
        [Display(Name = "Code")]
        public int Code { get; set; }
        [Display(Name = "Name(EN)")]
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        [Display(Name = "Name(AR)")]
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        [Display(Name = "Author")]
        [MinLength(3), MaxLength(200)]
        public string Author { get; set; }
        [Display(Name = "Publisher")]
        [MinLength(3), MaxLength(200)]
        public string Publisher { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Price")]
        public int Price { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Borrowed> Borroweds { get; set; }


        public Book(int code, string nameEN, string nameAR, string author, string publisher, Category category, int qunatity, int price)
        {
            Code = code;
            NameEN = nameEN;
            NameAR = nameAR;
            Author = author;
            Publisher = publisher;
            Category = category;
            Quantity = qunatity;
            Price = price;

            Borroweds = new List<Borrowed>();

        }
        public Book() : this(0, null!, null!, null!, null!, null!, 0, 0)
        {
        }
    }
}
