using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarambaOpen.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste väl veta vem du är, idiot!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Försöker du vara smart?! Sista chansen, annars blir du utlåst...PUCKO!!!")]
        public string Password { get; set; }

        public List<Poll> Polls { get; set; }
    }
}
