using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarambaOpen.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste svara på alla frågor, pucko!")]
        public string Alt1 { get; set; }
        [Required(ErrorMessage = "Du måste svara på alla frågor, pucko!")]
        public string Alt2 { get; set; }
        [Required(ErrorMessage = "Du måste svara på alla frågor, pucko!")]
        public string Alt3 { get; set; }
        [Required(ErrorMessage = "Du måste svara på alla frågor, pucko!")]
        public string Alt4 { get; set; }

        [Required]
        public Question Question { get; set; }
        //public int QuestionId { get; set; }

        [Required]
        public Poll Poll { get; set; }
        //public int PollId { get; set; }
    }
}
