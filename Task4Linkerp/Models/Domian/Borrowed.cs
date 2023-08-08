using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Task4Linkerp.Models.Domian
{
    [Table("Borrowed")]
    public class Borrowed
    {

        public int Id { get; set; }
        [Display(Name = "Personal Identification Number")]
        public long PIN { get; set; }
        [Display(Name = "BorrowerName")]
        public int BorrowerId { get; set; }
        [Display(Name = "BookName")]
        public int BookId { get; set; }

        [Display(Name = "Beginning Borrowing")]
        public DateTime DateIssue { get; set; }
        [Display(Name = "End Borrowing")]
        public DateTime DateReturned { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [ForeignKey(nameof(BorrowerId))]
        public Borrower Borrower { get; set; }
        public Borrowed(long pin,int borrowerId, int bookId, DateTime dateIssue, DateTime dateReturned)
        {
            PIN= pin;
            BorrowerId = borrowerId;
            BookId = bookId;
            DateIssue = dateIssue;
            DateReturned = dateReturned;
        }

        public Borrowed() : this(0,0, 0, DateTime.Now, DateTime.Now)
        {

        }



    }

}
