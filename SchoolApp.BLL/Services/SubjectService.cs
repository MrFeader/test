using SchoolApp.BLL.DTO;
using SchoolApp.BLL.Interfaces;
using SchoolApp.DAL.Interfaces;
using SchoolApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Services
{
    public class SubjectService : ISubjectService
    {
        IUnitOfWork Database { get; set; }

        public SubjectService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<SubjectDTO> GetAll()
        {
            IEnumerable<Subject> _subjects = Database.Subjects.GetAll();
            List<SubjectDTO> subjects = new List<SubjectDTO>();
            foreach (var subject in _subjects)
            {
                subjects.Add(Map(subject));
            }
            return subjects;
        }
        public SubjectDTO GetById(int id)
        {
            Subject _subject = Database.Subjects.Get(id);
            return Map(_subject);
        }
        public void UpdateSubject(SubjectDTO subject)
        {
            Database.Subjects.Update(Map(subject));
        }
        public void RemoveSubject(int Id)
        {
            Database.Subjects.Delete(Id);
        }
        public void CreateSubject(SubjectDTO subject)
        {
            Database.Subjects.Create(Map(subject));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public SubjectDTO Map(Subject subject)
        {
            return new SubjectDTO { Id = subject.Id, Name = subject.Name };
        }
        public Subject Map(SubjectDTO subject)
        {
            return new Subject { Id = subject.Id, Name = subject.Name };
        }
    }
}
