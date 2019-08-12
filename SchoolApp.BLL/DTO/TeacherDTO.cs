using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.DTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public List<TeacherGradeDTO> TeacherGrades { get; set; }
        public SubjectDTO SubjectName { get; set; }
        public int? SubjectId { get; set; }
        public string Post { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
    }
}
