using SchoolApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<TeacherDTO> GetAll();
        TeacherDTO GetById(int id);
        void UpdateTeacher(TeacherDTO teacher);
        void RemoveTeacher(int id);
        void CreateTeacher(TeacherDTO teacher);
        void Dispose();
    }
}
