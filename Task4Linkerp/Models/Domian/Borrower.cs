using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task4Linkerp.Models.Domian
{
    [Table("Borrower")]
    public class Borrower
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
        public IEnumerable<Borrowed> Borroweds { get; set; }

        public Borrower(int pin, string nameEN, string nameAR, Gender gender)
        {
            PIN = pin;
            Gender = gender;
            NameEN = nameEN;
            NameAR = nameAR;
            Borroweds = new List<Borrowed>();


        }
        public Borrower() : this(0, null!, null!, 0)
        {
        }
    }
    public enum Gender
    {
        Male = 0,
        Female = 1,

    }
}
