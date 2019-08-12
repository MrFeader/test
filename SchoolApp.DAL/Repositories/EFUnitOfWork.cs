using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Interfaces;
using SchoolApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.DAL.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private SchoolContext db;
        private EFGenericRepository<Grade> gradesRepository;
        private EFGenericRepository<Pupil> pupilsRepository;
        private EFGenericRepository<Subject> subjectsRepository;
        private EFGenericRepository<Teacher> teachersRepository;
        private EFGenericRepository<TeacherGrade> teacherGradesRepository;
        private EFGenericRepository<User> usersRepository;
        public EFUnitOfWork(DbContextOptions<SchoolContext> options)
        {
            db = new SchoolContext(options);
        }
        public IRepository<Grade> Grades
        {
            get
            {
                if (gradesRepository == null)
                    gradesRepository = new EFGenericRepository<Grade>(db);
                return gradesRepository;
            }
        }
        public IRepository<Pupil> Pupils
        {
            get
            {
                if (pupilsRepository == null)
                    pupilsRepository = new EFGenericRepository<Pupil>(db);
                return pupilsRepository;
            }
        }
        public IRepository<Teacher> Teachers
        {
            get
            {
                if (teachersRepository == null)
                    teachersRepository = new EFGenericRepository<Teacher>(db);
                return teachersRepository;
            }
        }
        public IRepository<Subject> Subjects
        {
            get
            {
                if (subjectsRepository == null)
                    subjectsRepository = new EFGenericRepository<Subject>(db);
                return subjectsRepository;
            }
        }
        public IRepository<TeacherGrade> TeacherGrades
        {
            get
            {
                if (teacherGradesRepository == null)
                    teacherGradesRepository = new EFGenericRepository<TeacherGrade>(db);
                return teacherGradesRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new EFGenericRepository<User>(db);
                return usersRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
