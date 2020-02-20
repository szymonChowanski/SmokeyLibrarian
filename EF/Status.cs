using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeyLibrarian.EF
{
    public enum ReadingStatus { WaitingForReading=0, ReadingInProgress = 1, AlreadyRead = 2}
    public class Status
    {
        [Key] [Required]
        public int StatusId { get; set; }
        [Required]
        public int ReadingStatus { get; set; }
        [Required] [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [Required] [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
