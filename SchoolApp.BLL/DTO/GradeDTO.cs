using System;
using System.Collections.Generic;
using System.Text;


namespace SchoolApp.BLL.DTO
{
    public class GradeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClassTeacherId { get; set; }
        public List<PupilDTO> Pupils { get; set; }
        public List<TeacherGradeDTO> TeacherGrades { get; set; }
        public TeacherDTO ClassTeacher { get; set; }
    }
    public class TeacherGradeDTO
    {
        public int TeacherId { get; set; }
        public TeacherDTO teacher { get; set; }

        public int GradeId { get; set; }
        public GradeDTO grade { get; set; }
    }
}
