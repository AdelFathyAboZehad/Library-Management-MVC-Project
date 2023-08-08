using System.ComponentModel.DataAnnotations;

namespace Task4Linkerp.ViewModel.Borrowed
{
    public class ReturnedViewModel
    {

        [Display(Name = "Personal Identification Number")]
        public long PIN { get; set; }
        [Display(Name = "BorrowerName")]
        public int BorrowerId { get; set; }

        [Display(Name = "BookName")]
        public int BookId { get; set; }

        public ReturnedViewModel() 
        {
        }
        public ReturnedViewModel(long pin, int borrowerId, int bookId)
        {
            PIN= pin;
            BorrowerId = borrowerId;
            BookId = bookId;
           
        }

    }
}
