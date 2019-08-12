using SchoolApp.BLL.DTO;
using SchoolApp.BLL.Interfaces;
using SchoolApp.DAL.Interfaces;
using SchoolApp.DAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Services
{
    public class PupilService:IPupilService
    {
        IUnitOfWork Database { get; set; }

        public PupilService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<PupilDTO> GetAll()
        {
            IEnumerable<Pupil> _pupils = Database.Pupils.GetAll();
            List<PupilDTO> pupils = new List<PupilDTO>();
            foreach (var pupil in _pupils)
            {
                pupils.Add(Map(pupil));
            }
            return pupils;
        }
        public PupilDTO GetById(int id)
        {
            Pupil _pupil = Database.Pupils.Get(id);
            return Map(_pupil);
        }
        public void PatchPupil(int id, int? GradeId)
        {
            Pupil pupil = Database.Pupils.Find(x=>x.Id==id).FirstOrDefault(x=>x.Id==id);
            pupil.GradePropId = GradeId;
            Database.Pupils.Update(pupil);
        }
        public void UpdatePupil(PupilDTO pupil)
        {
            Database.Pupils.Update(Map(pupil));
        }
        public void RemovePupil(int Id)
        {
            Database.Pupils.Delete(Id);
        }
        public void CreatePupil(PupilDTO pupil)
        {
            Database.Pupils.Create(Map(pupil));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public PupilDTO Map(Pupil pupil)
        {
            return new PupilDTO {
                Id = pupil.Id,
                Surname = pupil.Surname,
                Name = pupil.Name,
                SecondName = pupil.SecondName,
                Birthday = pupil.Birthday,
                Gender= pupil.Gender,
                //new GradeProp = pupil.GradeProp,
                GradePropId = pupil.GradePropId
            };
        }
        public Pupil Map(PupilDTO pupil)
        {
            return new Pupil
            {
                Id = pupil.Id,
                Surname = pupil.Surname,
                Name = pupil.Name,
                SecondName = pupil.SecondName,
                Birthday = pupil.Birthday,
                Gender = pupil.Gender,
                //new GradeProp = pupil.GradeProp,
                GradePropId = pupil.GradePropId
            };
        }
    }
}
