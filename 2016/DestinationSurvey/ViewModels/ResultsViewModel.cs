using System.Collections.Generic;
using CarambaOpen.Models;

namespace CarambaOpen.ViewModels
{
    public class ResultsViewModel
    {
        public string UserName { get; set; }
        public IList<Question> Questions { get; set; }
        public IList<Poll> Polls { get; set; }
    }
}
