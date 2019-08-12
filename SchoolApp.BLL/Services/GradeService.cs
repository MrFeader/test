using SchoolApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolApp.DAL.Models;
using SchoolApp.DAL.Interfaces;
using SchoolApp.BLL.DTO;
using System.Linq;

namespace SchoolApp.BLL.Services
{
    public class GradeService:IGradeService
    {
        IUnitOfWork Database { get; set; }

        public GradeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        /*public IEnumerable<PupilDTO> GetAllPupils()
        {
            IEnumerable<Pupil> pupils = Database.Pupils.GetAll();
            List<PupilDTO> pupilsDTO = new List<PupilDTO>();
            foreach (var pupil in pupils)
            {
                pupilsDTO.Add(new PupilDTO
                {
                    Id = pupil.Id,
                    Name = pupil.Name,
                    SecondName = pupil.SecondName,
                    Surname = pupil.Surname,
                    Birthday = pupil.Birthday,
                    Gender = pupil.Gender
                });
            }
            return pupilsDTO;
        }
        public IEnumerable<PupilDTO> GetPupils(GradeDTO gradeDTO)
        {
            IEnumerable<Pupil> pupils = Database.Pupils.GetAll().Where(p => p.GradePropId == gradeDTO.Id).ToList();
            List<PupilDTO> pupilsDTO = new List<PupilDTO>();
            foreach(var pupil in pupils)
            {
                pupilsDTO.Add(new PupilDTO
                {
                    Id = pupil.Id,
                    Name = pupil.Name,
                    SecondName = pupil.SecondName,
                    Surname = pupil.Surname,
                    Birthday = pupil.Birthday,
                    Gender = pupil.Gender
                });
            }
            return pupilsDTO;
        }
        public TeacherDTO GetTeacher(int? id)
        {
            if (id == null)
                throw new Exception("Не установлен параметр ID учителя");
                Teacher teacher = Database.Teachers.Get(id.Value);
            if (teacher == null)
                throw new Exception("Учитель не найден");
            return new TeacherDTO {Id=teacher.Id, Name=teacher.Name, SecondName=teacher.SecondName, Surname=teacher.Surname, Post=teacher.Post, SubjectId=teacher.SubjectId };
        }*/

        public IEnumerable<GradeDTO> GetAll()
        {
            IEnumerable<Grade> _grades = Database.Grades.GetAll();
            List<GradeDTO> grades = new List<GradeDTO>();
            foreach (var grade in _grades)
            {
                grades.Add(Map(grade));
            }
            return grades;
        }

        public GradeDTO GetById(int id)
        {
            Grade grade = Database.Grades.Get(id);
            return Map(grade);
        }
        public void UpdateGrade(GradeDTO grade)
        {
            Database.Grades.Update(Map(grade));
        }
        public void RemoveGrade(int Id)
        {
            Database.Grades.Delete(Id);
        }
        public void CreateGrade(GradeDTO grade)
        {
            Database.Grades.Create(Map(grade));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public GradeDTO Map(Grade grade)
        {
            Teacher teacher = Database.Teachers.Get(grade.ClassTeacherId.Value);
            return new GradeDTO
            {
                Id = grade.Id,
                Name = grade.Name,
                ClassTeacherId=grade?.ClassTeacherId.Value,
                ClassTeacher=new TeacherDTO { Name=teacher?.Name, SecondName=teacher?.SecondName, Surname=teacher?.Surname}
            };
        }
        public Grade Map(GradeDTO grade)
        {
            return new Grade
            {
                Id = grade.Id,
                Name = grade.Name,
                ClassTeacherId = grade.ClassTeacherId
            };
        }
    }
}
