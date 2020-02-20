using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeyLibrarian.EF
{
    public class User
    { 
        [Key] [Required]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        
        [Required]
        public DateTime DateOfCreation { get; set; }
        public virtual List<Status> Statuses { get; set; }
    }
}
