using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.DAL.Models
{
    public class Teacher:Human
    {

        public Teacher()
        {
            TeacherGrades = new List<TeacherGrade>();
        }
        public List<TeacherGrade> TeacherGrades { get; set; }
        public Subject SubjectName { get; set; }
        public int? SubjectId { get; set; }
        public string Post { get; set; }
        public Teacher(string name, string SecName, string surname, string post, Subject subject)
        {
            this.Name = name;
            this.SecondName = SecName;
            this.Surname = surname;
            this.SecondName = SecName;
            SubjectName = subject;
            Post = post;

        }
    }
}
