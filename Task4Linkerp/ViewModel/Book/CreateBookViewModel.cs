using System.ComponentModel.DataAnnotations;
using Task4Linkerp.Models;

namespace Task4Linkerp.ViewModel.Book
{
    public class CreateBookViewModel
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
        [Display(Name = "Category(EN|AR)")]
        public int CategoryId { get; set; }

        public CreateBookViewModel() { }

        public CreateBookViewModel(int id,int code, string nameEN, string nameAR, string auther, string publisher,int categoryId, int qunatity, int price)
        {
            Id = id;
            Code = code;
            NameEN = nameEN;
            NameAR = nameAR;
            Author = auther;
            Publisher = publisher;
            CategoryId = categoryId;
            Quantity = qunatity;
            Price = price;


        }

    }
}
