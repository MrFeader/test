using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Web.Models
{
    public class GradeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClassTeacherId { get; set; }
        public List<PupilViewModel> Pupils { get; set; }
        public List<TeacherGradeViewModel> TeacherGrades { get; set; }
        public TeacherViewModel ClassTeacher { get; set; }
    }
    public class TeacherGradeViewModel
    {
        public int TeacherId { get; set; }
        public TeacherViewModel teacher { get; set; }

        public int GradeId { get; set; }
        public GradeViewModel grade { get; set; }
    }
}
