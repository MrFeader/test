using SchoolApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Grade> Grades { get; }
        IRepository<Pupil> Pupils { get; }
        IRepository<Subject> Subjects{ get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<TeacherGrade> TeacherGrades { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
