using System.ComponentModel.DataAnnotations;
using Task4Linkerp.Models.Domian;

namespace Task4Linkerp.ViewModel.Borrower
{
    public class AllBorrowersViewModel
    {

        public int Id { get; set; }
        [Display(Name = "Personal Identification Number")]
        public long PIN { get; set; }
        [Display(Name = "Name(EN)")]
        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }
        [Display(Name = "Name(AR)")]
        [MinLength(3), MaxLength(200)]
        public string NameAR { get; set; }
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
        public AllBorrowersViewModel()
        {

        }

        public AllBorrowersViewModel(int id,long pin, string nameEN, string nameAR, Gender gender)
        {
            Id = id;
            PIN = pin;
            NameEN = nameEN;
            NameAR = nameAR;
            Gender = gender;


        }
    }
}
