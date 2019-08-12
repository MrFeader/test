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
    public class TeacherGradeService:ITeacherGradeService
    {
        IUnitOfWork Database { get; set; }

        public TeacherGradeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<TeacherGradeDTO> GetAll()
        {
            IEnumerable<TeacherGrade> tg = Database.TeacherGrades.GetAll();
            List<TeacherGradeDTO> tgList = new List<TeacherGradeDTO>();
            foreach (var _tg in tg)
            {
                tgList.Add(Map(_tg));
            }
            return tgList;
        }

        public TeacherGradeDTO GetById(int id)
        {
            return Map(Database.TeacherGrades.Get(id));
        }
        public void UpdateTG(TeacherGradeDTO tg)
        {
            Database.TeacherGrades.Update(Map(tg));
        }
        public void RemoveTG(TeacherGradeDTO tg)
        {
            Database.TeacherGrades.Delete(Map(tg));
        }
        public void CreateTG(TeacherGradeDTO tg)
        {
            Database.TeacherGrades.Create(Map(tg));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public TeacherGradeDTO Map(TeacherGrade tg)
        {
            Teacher teacher = Database.Teachers.Get(tg.TeacherId);
            teacher.SubjectName = teacher.SubjectId != null ? Database.Subjects.Get(teacher.SubjectId.Value) : null;
            return new TeacherGradeDTO
            {
                GradeId = tg.GradeId,
                TeacherId = tg.TeacherId,
                teacher = new TeacherDTO
                {
                    Id = teacher.Id,
                    Surname = teacher.Surname,
                    Name = teacher.Name,
                    SecondName = teacher.SecondName,
                    Post = teacher.Post,
                    SubjectId = teacher.SubjectId,
                    SubjectName = new SubjectDTO { Name = teacher?.SubjectName.Name }
                }

            };
        }
        public TeacherGrade Map(TeacherGradeDTO tg)
        {
            return new TeacherGrade
            {
                GradeId = tg.GradeId,
                TeacherId = tg.TeacherId
            };
        }
    }
}
