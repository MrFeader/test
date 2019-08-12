using SchoolApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Interfaces
{
    public interface IPupilService
    {
        IEnumerable<PupilDTO> GetAll();
        PupilDTO GetById(int id);
        void UpdatePupil(PupilDTO subject);
        void PatchPupil(int id, int? GradeId);
        void RemovePupil(int id);
        void CreatePupil(PupilDTO subject);
        void Dispose();
    }
}
