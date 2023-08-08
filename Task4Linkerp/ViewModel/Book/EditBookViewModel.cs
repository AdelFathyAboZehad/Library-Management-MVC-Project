using System.ComponentModel.DataAnnotations;
using Task4Linkerp.Models;

namespace Task4Linkerp.ViewModel.Book
{
    public class EditBookViewModel
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
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public EditBookViewModel()
        {

        }
        public EditBookViewModel(int id,int code, string nameEN, string nameAR, string author, string publisher, int qunatity, int price,int categoryId)
        {
            Id = id;
            Code = code;
            NameEN = nameEN;
            NameAR = nameAR;
            Author = author;
            Publisher = publisher;
            Quantity = qunatity;
            Price = price;
            CategoryId = categoryId;




        }
    }
}
