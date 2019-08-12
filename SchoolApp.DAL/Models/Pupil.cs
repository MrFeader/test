using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.DAL.Models
{
    public class Pupil:Human
    {
        public Grade GradeProp { get; set; }
        public int? GradePropId { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public Pupil()
        {

        }
        public Pupil(string name, string secName, string surname, string gender, DateTime Bday)//, Grade grade)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = Bday.Date;
            this.SecondName = secName;
            Gender = gender;
        }
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
