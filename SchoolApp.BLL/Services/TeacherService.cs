using SchoolApp.BLL.DTO;
using SchoolApp.BLL.Interfaces;
using SchoolApp.DAL.Interfaces;
using SchoolApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Services
{
    public class TeacherService:ITeacherService
    {
        IUnitOfWork Database { get; set; }

        public TeacherService(IUnitOfWork uow)
        {
            Database = uow;
        }
        

        public IEnumerable<TeacherDTO> GetAll()
        {
            IEnumerable<Teacher> _teachers = Database.Teachers.GetAll();
            List<TeacherDTO> teachers = new List<TeacherDTO>();
            foreach (var teacher in _teachers)
            {
                teachers.Add(Map(teacher));
            }
            return teachers;
        }

        public TeacherDTO GetById(int id)
        {
            Teacher teacher = Database.Teachers.Get(id);
            return Map(teacher);
        }
        public void UpdateTeacher(TeacherDTO teacher)
        {
            Database.Teachers.Update(Map(teacher));
        }
        public void RemoveTeacher(int Id)
        {
            Database.Teachers.Delete(Id);
        }
        public void CreateTeacher(TeacherDTO teacher)
        {
            Database.Teachers.Create(Map(teacher));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public TeacherDTO Map(Teacher teacher)
        {
            return new TeacherDTO
            {
                Id = teacher.Id,
                Surname = teacher.Surname,
                SecondName = teacher.SecondName,
                Name = teacher.Name,
                Post = teacher.Post,
                SubjectId = teacher.SubjectId,
                SubjectName = teacher.SubjectName != null ? new SubjectDTO { Id = teacher.SubjectName.Id, Name = teacher.SubjectName.Name } : null
                
                
            };
        }
        public Teacher Map(TeacherDTO teacher)
        {
            return new Teacher
            {
                Id = teacher.Id,
                Surname = teacher.Surname,
                SecondName = teacher.SecondName,
                Name = teacher.Name,
                Post = teacher.Post,
                SubjectId = teacher.SubjectId,
                //SubjectName = new Subject { Id = teacher.SubjectName.Id, Name = teacher.SubjectName.Name }
            };
        }
    }
}
