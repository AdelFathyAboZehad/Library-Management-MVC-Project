using System.ComponentModel.DataAnnotations;
using Task4Linkerp.Models;

namespace Task4Linkerp.ViewModel.Book
{
    public class DetailsBookViewModel
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
        [Display(Name = "CategoryNameEN")]
        public string CategoryNameEN { get; set; }
        [Display(Name = "CategoryNameAR")]
        public string CategoryNameAR { get; set; }

        public DetailsBookViewModel()
        {

        }

    
        public DetailsBookViewModel(int id,int code, string nameEN, string nameAR, string author, string publisher, int qunatity, int price,string categoryNameEN, string categoryNameAR)
        {
            Id = id;
            Code = code;
            NameEN = nameEN;
            NameAR = nameAR;
            Author = author;
            Publisher = publisher;
            Quantity = qunatity;
            Price = price;
            CategoryNameEN = categoryNameEN;
            CategoryNameAR = categoryNameAR;



        }
    }
}
