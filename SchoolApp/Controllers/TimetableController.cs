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

namespace SchoolApp.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : Controller
    {
        IPupilService pupilService;
        ITeacherGradeService tgService;
        IGradeService gradeService;
        ITeacherService teacherService;
        public TimetableController(IPupilService pservice, ITeacherGradeService service, IGradeService gservice, ITeacherService tservice)
        {
            pupilService = pservice;
            tgService = service;
            gradeService = gservice;
            teacherService = tservice;
        }
        // GET: api/Timetable
        [HttpGet]
        public IActionResult Get()
        {
            ViewBag.Teachers = Map(teacherService.GetAll().ToList());

            return View("Index");
        }

        // GET: api/Timetable/5
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            ViewBag.Teachers = Map(teacherService.GetAll().ToList());
            ViewBag.Teacher = Map(teacherService.GetById(Id));
            List<TeacherGradeViewModel> TGList = Map(tgService.GetAll().Where(x => x.TeacherId == Id).ToList());
            List<GradeViewModel> GradeList = new List<GradeViewModel>();
            foreach (var item in TGList)
            {
                GradeViewModel grade = Map(gradeService.GetById(item.GradeId));
                grade.Pupils = Map(pupilService.GetAll().Where(x => x.GradePropId == item.GradeId).ToList());
                GradeList.Add(grade);
            }
            return View("Index", GradeList);
        }

        
        internal TeacherGradeViewModel Map(TeacherGradeDTO tg)
        {
            return new TeacherGradeViewModel { GradeId = tg.GradeId, TeacherId = tg.TeacherId };
        }
        internal List<TeacherGradeViewModel> Map(IEnumerable<TeacherGradeDTO> tg)
        {
            List<TeacherGradeViewModel> TGList = new List<TeacherGradeViewModel>();
            foreach (var item in tg)
            {
                TGList.Add(Map(item));
            }
            return TGList;
        }

        internal PupilViewModel Map(PupilDTO pupil)
        {
            return new PupilViewModel
            {
                Id = pupil.Id,
                Name = pupil.Name,
                SecondName = pupil.SecondName,
                Surname = pupil.Surname
            };

        }
        
        internal List<PupilViewModel> Map(List<PupilDTO> pupils)
        {
            List<PupilViewModel> PupilList = new List<PupilViewModel>();
            foreach(var item in pupils)
            {
                PupilList.Add(Map(item));
            }
            return PupilList;
        }
        internal GradeViewModel Map(GradeDTO grade)
        {
            return new GradeViewModel { Name = grade.Name };
        }
        internal TeacherViewModel Map(TeacherDTO teacher)
        {
            return new TeacherViewModel { Id = teacher.Id, Name = teacher.Name, SecondName = teacher.SecondName, Surname = teacher.Surname };
        }
        internal List<TeacherViewModel> Map(List<TeacherDTO> teachers)
        {
            List<TeacherViewModel> TList=new List<TeacherViewModel>();
            foreach(var item in teachers)
            {
                TList.Add(Map(item));
            }
            return TList;
        }
    }
    
}
