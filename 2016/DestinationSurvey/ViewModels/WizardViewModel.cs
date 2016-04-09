using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarambaOpen.Models;
using Microsoft.AspNet.Mvc.Rendering;

namespace CarambaOpen.ViewModels
{
    public class WizardViewModel
    {
        [Required(ErrorMessage = "Vet du inte vem du är? Pucko!")]
        public IEnumerable<SelectListItem> Users { get; set; } = new List<SelectListItem>();

        public int SelectedUserId { get; set; }

        [Required(ErrorMessage = "Försök inte lura mig, gosse! Skriv in ditt j@vl@ lösenord")]
        public string Password { get; set; }

        public Question Question1 { get; set; }
        public Question Question2 { get; set; }
        public Question Question3 { get; set; }
        public Question Question4 { get; set; }
        public Question Question5 { get; set; }
        public Question Question6 { get; set; }
        public Question Question7 { get; set; }

        public Answer Answer1 { get; set; }
        public Answer Answer2 { get; set; }
        public Answer Answer3 { get; set; }
        public Answer Answer4 { get; set; }
        public Answer Answer5 { get; set; }
        public Answer Answer6 { get; set; }
        public Answer Answer7 { get; set; }
    }
}
