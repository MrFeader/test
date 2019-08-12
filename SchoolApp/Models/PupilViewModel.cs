using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Web.Models
{
    public class PupilViewModel
    {
        public int Id { get; set; }
        public GradeViewModel GradeProp { get; set; }
        public int? GradePropId { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }

        public int Age
        {
            get
            {
                return Birthday.Month <= DateTime.Today.Month && DateTime.Today.Day >= Birthday.Day ?
                    DateTime.Today.Year - Birthday.Year : DateTime.Today.Year - Birthday.Year - 1;
            }
        }
    }
}
