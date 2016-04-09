using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarambaOpen.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public int Order { get; set; }

        public string Quest { get; set; }
        public string Alt1 { get; set; }
        public string Alt2 { get; set; }
        public string Alt3 { get; set; }
        public string Alt4 { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
