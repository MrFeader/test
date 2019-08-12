using SchoolApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Interfaces
{
    public interface ITeacherGradeService
    {
        IEnumerable<TeacherGradeDTO> GetAll();
        void RemoveTG(TeacherGradeDTO teacherGrade);
        void CreateTG(TeacherGradeDTO subject);
        void Dispose();
    }
}
