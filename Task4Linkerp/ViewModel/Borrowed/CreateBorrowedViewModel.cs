using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task4Linkerp.Models;

namespace Task4Linkerp.ViewModel.Borrowed
{
    public class CreateBorrowedViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Personal Identification Number")]
        //[RegularExpression(@"^[0-9]{4}[0]{2}[A-Z0-9]{12}[0-9]{2}$", ErrorMessage = "Invalid PIN")]
        public long PIN { get; set; }
        [Display(Name = "BorrowerName")]
        public int BorrowerId { get; set; }
        [Display(Name = "BookName")]
        public int BookId { get; set; }
        [Display(Name = "Beginning Borrowing")]
        public DateTime DateIssue { get; set; }
        [Display(Name = "End Borrowing")]
        public DateTime DateReturned { get; set; }
        public CreateBorrowedViewModel() { }

        public CreateBorrowedViewModel(int id,long pin, int borrowerId, int bookId, DateTime dateIssue, DateTime dateReturned)
        {
            Id = id;
            PIN= pin;
            BorrowerId = borrowerId;
            BookId = bookId;
            DateIssue = dateIssue;
            DateReturned = dateReturned;
        }
    }
}
