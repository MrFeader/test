using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.DAL.Models
{
    public class Grade
    {
        public Grade()
        {
            TeacherGrades = new List<TeacherGrade>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher ClassTeacher { get; set; }
        public int? ClassTeacherId { get; set; }
        public List<Pupil> Pupils { get; set; }
        public List<TeacherGrade> TeacherGrades { get; set; }
    }
    public class TeacherGrade
    {
        public TeacherGrade()
        {

        }
        public int TeacherId { get; set; }
        public Teacher teacher { get; set; }

        public int GradeId { get; set; }
        public Grade grade { get; set; }
    }
}
