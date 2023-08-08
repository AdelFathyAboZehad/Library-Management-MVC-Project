using System.ComponentModel.DataAnnotations;

namespace Task4Linkerp.ViewModel.Borrowed
{
    public class AllBorrowedViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Personal Identification Number")]
        public long PIN { get; set; }
        [Display(Name = "BorrowerName")]
        public string BorrowerName { get; set; }
        [Display(Name = "BookName")]
        public string BookName{ get; set; }
        [Display(Name = "Beginning Borrowing")]
        public DateTime DateIssue { get; set; }
        [Display(Name = "End Borrowing")]
        public DateTime DateReturned { get; set; }
        public AllBorrowedViewModel()
        {

        }
        public AllBorrowedViewModel(int id,long pin, string borrowerName, string bookName, DateTime dateIssue, DateTime dateReturned)
        {

            Id = id;
            PIN = pin;
            BorrowerName = borrowerName;
            BookName = bookName;
            DateIssue = dateIssue;
            DateReturned = dateReturned;
        }


    }
}
