using SchoolApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Interfaces
{
    public interface IGradeService
    {
        IEnumerable<GradeDTO> GetAll();
        GradeDTO GetById(int id);
        void UpdateGrade(GradeDTO subject);
        void RemoveGrade(int id);
        void CreateGrade(GradeDTO subject);
        void Dispose();
    }
}
