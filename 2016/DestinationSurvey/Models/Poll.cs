using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarambaOpen.Models
{
    public class Poll
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Har du inget användarnamn, eller?")]
        public User User { get; set; }
        //public int UserId { get; set; }    

        public List<Answer> Answers { get; set; }
    }
}
