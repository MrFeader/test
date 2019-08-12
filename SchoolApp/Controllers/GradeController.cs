using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.BLL.DTO;
using SchoolApp.BLL.Interfaces;
using SchoolApp.Web.Models;
using System.Web;

namespace SchoolApp.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : Controller
    {
        IGradeService gradeService;
        IPupilService pupilService;
        ITeacherService teacherService;
        ITeacherGradeService tgService;
        ISubjectService subjectService;
        public GradeController(IGradeService service, IPupilService pservice, ITeacherService tservice, ITeacherGradeService tgservice, ISubjectService sservice)
        {
            gradeService = service;
            pupilService = pservice;
            teacherService = tservice;
            tgService = tgservice;
            subjectService = sservice;
        }
        // GET: api/Grade
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<GradeDTO> gradeDTO = gradeService.GetAll();
            List<GradeViewModel> gradeList = new List<GradeViewModel>();

            ViewBag.Teachers = Map(teacherService.GetAll());
            foreach (var grade in gradeDTO)
            {
                gradeList.Add(Map(grade));
            }
            return View("index", gradeList);

        }

        // GET: api/Grade/5
        [HttpGet("{id}")]
        public IActionResult Get(int? Id)
        {
            if (Id != null)
            {
                ViewBag.PupilsInClass = Map(pupilService.GetAll().Where(x=>x.GradePropId==Id));
                ViewBag.PupilFree = Map(pupilService.GetAll().Where(x => x.GradePropId == null)).OrderBy(x=>x.Age).ThenBy(x=>x.Surname);
                GradeViewModel grade = Map(gradeService.GetById(Id.Value));
                ViewBag.TG = Map(tgService.GetAll().Where(x => x.GradeId == Id));
                ViewBag.Teachers = Map(teacherService.GetAll(), Id.Value);
                ViewBag.TList = Map(teacherService.GetAll());

                return View("Details", grade);
            }

            return NotFound();
        }

        // POST: api/Grade
        [HttpPost]
        public void Post([FromBody] GradeViewModel grade)
        {
            gradeService.CreateGrade(Map(grade));
        }

        // PUT: api/Grade/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GradeViewModel grade)
        {
            gradeService.UpdateGrade(Map(grade));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            gradeService.RemoveGrade(id);
        }

        public GradeDTO Map(GradeViewModel grade)
        {
            return new GradeDTO
            {
                Id = grade.Id,
                Name = grade.Name,
                ClassTeacherId = grade.ClassTeacherId
            };
        }
        public GradeViewModel Map(GradeDTO grade)
        {
            return new GradeViewModel
            {
                Id = grade.Id,
                Name = grade.Name,
                ClassTeacherId = grade?.ClassTeacherId.Value,
                ClassTeacher=new TeacherViewModel { Name = grade?.ClassTeacher?.Name, Surname = grade?.ClassTeacher?.Surname, SecondName = grade?.ClassTeacher?.SecondName }
            };
        }

        public IEnumerable<PupilViewModel> Map(IEnumerable<PupilDTO> pupils)
        {
            List<PupilViewModel> _pupils = new List<PupilViewModel>();
            foreach(var pupil in pupils)
            {
                _pupils.Add(new PupilViewModel
                {
                    Id = pupil.Id,
                    Surname=pupil.Surname,
                    Name= pupil.Name,
                    SecondName= pupil.SecondName,
                    Birthday=pupil.Birthday,
                    Gender= pupil.Gender,
                    GradePropId= pupil.GradePropId

                });
            }
            return _pupils;
        }


        public IEnumerable<TeacherViewModel> Map(IEnumerable<TeacherDTO> teachers)
        {
            List<TeacherViewModel> tlist = new List<TeacherViewModel>();
            foreach(var item in teachers)
            {
                tlist.Add(new TeacherViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    SecondName = item.SecondName,
                    Post = item.Post,
                    Surname = item.Surname
                });
            }
            return tlist;
        }
        public IEnumerable<TeacherViewModel> Map(IEnumerable<TeacherDTO> teachers, int Id)
        {
            IEnumerable<TeacherGradeViewModel> TG = Map(tgService.GetAll());
            List<TeacherViewModel> freeTeachers = new List<TeacherViewModel>();
            foreach(var teacher in teachers)
            {
                bool finded = false;
                foreach(var tg in TG)
                {
                    if (tg.GradeId == Id)
                    {
                        if (tg.TeacherId == teacher.Id)
                        {
                            finded = true;
                            break;
                        }
                    }
                }
                if (!finded)
                {
                    SubjectDTO subj = teacher.SubjectId!=null?subjectService.GetById(teacher.SubjectId.Value):null;
                    freeTeachers.Add(new TeacherViewModel
                    {
                        Id = teacher.Id,
                        Surname = teacher.Surname,
                        Name = teacher.Name,
                        SecondName = teacher.SecondName,
                        SubjectName = new SubjectViewModel { Id = subj?.Id, Name = subj?.Name }
                    });
                }
            }
            return freeTeachers;
        }

        public IEnumerable<TeacherGradeViewModel> Map(IEnumerable<TeacherGradeDTO> tg)
        {
            List<TeacherGradeViewModel> TG = new List<TeacherGradeViewModel>();
            foreach(var _tg in tg)
            {
                TG.Add(new TeacherGradeViewModel
                {
                    GradeId = _tg.GradeId,
                    TeacherId = _tg.TeacherId,
                    teacher = new TeacherViewModel
                    {
                        Id = _tg.teacher.Id,
                        Surname = _tg.teacher.Surname,
                        Name = _tg.teacher.Name,
                        SecondName = _tg.teacher.SecondName,
                        Post = _tg.teacher.Post,
                        SubjectId = _tg.teacher.SubjectId,
                        SubjectName = new SubjectViewModel
                        {
                            Id = _tg.teacher.SubjectName.Id,
                            Name = _tg.teacher.SubjectName.Name
                        }
                    }
                });
            }
            return TG;
        }
    }
}
