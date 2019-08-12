using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Web.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public List<TeacherGradeViewModel> TeacherGrades { get; set; }
        public SubjectViewModel SubjectName { get; set; }
        public int? SubjectId { get; set; }
        public string Post { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
    }
}
