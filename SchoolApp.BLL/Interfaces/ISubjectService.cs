using SchoolApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDTO> GetAll();
        SubjectDTO GetById(int id);
        void UpdateSubject(SubjectDTO subject);
        void RemoveSubject(int id);
        void CreateSubject(SubjectDTO subject);
        void Dispose();
    }
}
