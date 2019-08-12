using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.DAL.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherGrade> TeacherGrades { get; set; }
        public DbSet<User> Users { get; set; }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherGrade>()
                .HasKey(t => new { t.TeacherId, t.GradeId });

            modelBuilder.Entity<TeacherGrade>()
                .HasOne(sc => sc.teacher)
                .WithMany(s => s.TeacherGrades)
                .HasForeignKey(sc => sc.TeacherId);

            modelBuilder.Entity<TeacherGrade>()
                .HasOne(sc => sc.grade)
                .WithMany(c => c.TeacherGrades)
                .HasForeignKey(sc => sc.GradeId);

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User{Id=1, Name="admin", Password="admin"},
                    new User{Id=2, Name="учитель", Password="учитель"},
                    new User{Id=3, Name="администратор", Password="администратор"}
                });

            Subject[] SubjInit = new Subject[]{
                    new Subject{Id=1,Name="Математика"},
                    new Subject{Id=2,Name="Физика"},
                    new Subject{Id=3,Name="Химия"},
                    new Subject{Id=4,Name="Русский язык"},
                    new Subject{Id=5,Name="Информатика"},
                    new Subject{Id=6,Name="Ин. язык"},
                    new Subject{Id=7,Name="Биология"},
                    new Subject{Id=8,Name="История"},
                    new Subject{Id=9,Name="Трудовое воспитание"},
                    new Subject{Id=10,Name="Физкультура"}

                };
            Teacher[] TeachInit = new Teacher[]
                {
                    new Teacher{Id=1, Surname="Константинова", Name="Дарья", SecondName="Артуровна", Post="Директор", SubjectId=1},
                    new Teacher{Id=2, Surname="Николаева", Name="Людмила", SecondName="Владиславовна", Post="Завуч", SubjectId=2},
                    new Teacher{Id=3, Surname="Павлов", Name="Алексей", SecondName="Вячеславович", Post="Учитель", SubjectId=3},
                    new Teacher{Id=4, Surname="Кузьмин", Name="Игорь", SecondName="Валерьевич", Post="Учитель", SubjectId=4},
                    new Teacher{Id=5, Surname="Максимов", Name="Дмитрий", SecondName="Григорьевич", Post="Учитель", SubjectId=5},
                    new Teacher{Id=6, Surname="Осанов", Name="Сергей", SecondName="Александрович", Post="Учитель", SubjectId=6},
                    new Teacher{Id=7, Surname="Филиппова", Name="Виктория", SecondName="Витальевна", Post="Учитель", SubjectId=7},
                    new Teacher{Id=8, Surname="Козлова", Name="Анастасия", SecondName="Ивановна", Post="Учитель", SubjectId=8},
                    new Teacher{Id=9, Surname="Максимова", Name="Елена", SecondName="Сергеевна", Post="Учитель", SubjectId=9},
                    new Teacher{Id=10, Surname="Николаева", Name="Евгения", SecondName="Игоревна", Post="Учитель", SubjectId=10}

                };


            //Pupil[] PupilInit = new Pupil[]
            //    {
            //        new Pupil{Id=1, Name="Арина", SecondName="Юрьевна", Surname="Агатьева", Birthday=DateTime.Parse("20.01.2006"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=2, Name="Пальмира", SecondName="Гурьевна", Surname="Алексеева", Birthday=DateTime.Parse("15.02.2007"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=3, Name="Феликс", SecondName="Александрович", Surname="Алексеев", Birthday=DateTime.Parse("17.03.2008"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=4, Surname="Григорьева", Name="Елена", SecondName="Андреевна", Birthday=DateTime.Parse("02.04.2006"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=5, Surname="Васильев", Name="Иван", SecondName="Юрьевич", Birthday=DateTime.Parse("18.05.2007"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=6, Surname="Борисова", Name="Екатерина", SecondName="Юрьевна", Birthday=DateTime.Parse("13.06.2008"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=7, Surname="Исаков", Name="Константин", SecondName="Сергеевич", Birthday=DateTime.Parse("22.07.2006"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=8, Surname="Жидова", Name="Анастасия", SecondName="Анатольевна", Birthday=DateTime.Parse("14.08.2007"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=9, Surname="Данилов", Name="Александр", SecondName="Леонидович", Birthday=DateTime.Parse("16.09.2008"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=10, Surname="Николаева", Name="Анжелика", SecondName="Леонидовна", Birthday=DateTime.Parse("07.10.2006"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=11, Surname="Клементьева", Name="Екатерина", SecondName="Николаевна", Birthday=DateTime.Parse("09.11.2007"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=12, Surname="Иванов", Name="Иван", SecondName="Александрович", Birthday=DateTime.Parse("15.12.2008"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=13, Surname="Родионова", Name="Елена", SecondName="Васильевна", Birthday=DateTime.Parse("18.01.2006"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=14, Surname="Николаев", Name="Кирилл", SecondName="Андреевич", Birthday=DateTime.Parse("28.02.2007"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=15, Surname="Николаева", Name="Анна", SecondName="Игоревна", Birthday=DateTime.Parse("26.03.2008"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=16, Surname="Фёдоров", Name="Владимир", SecondName="Николаевич", Birthday=DateTime.Parse("17.04.2006"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=17, Surname="Терентьев", Name="Юрий", SecondName="Александрович", Birthday=DateTime.Parse("18.05.2007"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=18, Surname="Семёнова", Name="Анна", SecondName="Александровна", Birthday=DateTime.Parse("19.06.2008"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=19, Surname="Гурьев", Name="Дмитрий", SecondName="Михайлович", Birthday=DateTime.Parse("20.07.2005"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=20, Surname="Александров", Name="Станислав", SecondName="Витальевич", Birthday=DateTime.Parse("01.08.2009"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=21, Surname="Александрова", Name="Ассоль", SecondName="Львовна", Birthday=DateTime.Parse("02.09.2007"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=22, Surname="Исаев", Name="Андрей", SecondName="Игоревич", Birthday=DateTime.Parse("03.10.2007"), Gender="Мужской", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=23, Surname="Иванова", Name="Ксения", SecondName="Сергеевна", Birthday=DateTime.Parse("09.11.2010"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=24, Surname="Данилова", Name="Анастасия", SecondName="Юрьевна", Birthday=DateTime.Parse("11.12.2011"), Gender="Женский", GradeProp=null, GradePropId=null },
            //        new Pupil{Id=25, Surname="Илларионов", Name="Кирилл", SecondName="Владимирович", Birthday=DateTime.Parse("12.11.2012"), Gender="Мужской", GradeProp=null, GradePropId=null }
                    
            //    };

            Grade[] GradeInit = new Grade[]
            {
                new Grade{Id=1, ClassTeacherId=3, Name="1А" },
                new Grade{Id=2, ClassTeacherId=4, Name="2А" },
                new Grade{Id=3, ClassTeacherId=5, Name="3А" },

            };


            modelBuilder.Entity<Subject>().HasData(SubjInit);

            //modelBuilder.Entity<Pupil>().HasData(PupilInit);

            modelBuilder.Entity<Teacher>().HasData(TeachInit);

            modelBuilder.Entity<Grade>().HasData(GradeInit);


        }
    }
}
