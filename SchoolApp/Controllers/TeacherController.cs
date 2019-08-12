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
    public class TeacherController : Controller
    {
        ITeacherService teacherService;
        ISubjectService subjectService;
        public TeacherController(ITeacherService service, ISubjectService _service)
        {
            teacherService = service;
            subjectService = _service;
        }
        // GET: api/Teacher
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TeacherDTO> teacherDTO = teacherService.GetAll();
            List<TeacherViewModel> teacherList = new List<TeacherViewModel>();
            IEnumerable<SubjectDTO> subjectDTO = subjectService.GetAll();
            List<SubjectViewModel> subjectList = new List<SubjectViewModel>();
            foreach (var teacher in teacherDTO)
            {
                teacherList.Add(Map(teacher));
            }
            foreach (var subj in subjectDTO)
            {
                subjectList.Add(new SubjectViewModel
                {
                    Id = subj.Id,
                    Name = subj.Name
                });
            }
            ViewBag.SubjectList = subjectList;
            
            return View("index", teacherList);
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public IActionResult Get(int? Id)
        {
            if (Id != null)
            {
                TeacherDTO _teacher = teacherService.GetById(Id.Value);
                TeacherViewModel teacher = Map(_teacher);
                List<TeacherViewModel> teachers = new List<TeacherViewModel> { teacher };
                return View("index", teachers);
            }

            return NotFound();
        }

        // POST: api/Teacher
        [HttpPost]
        public void Post([FromBody] TeacherViewModel teacher)
        {
            teacherService.CreateTeacher(Map(teacher));
        }

        // PUT: api/Teacher/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TeacherViewModel teacher)
        {
            teacherService.UpdateTeacher(Map(teacher));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            teacherService.RemoveTeacher(id);
        }

        public TeacherDTO Map(TeacherViewModel teacher)
        {
            return new TeacherDTO
            {
                Id = teacher.Id,
                Surname = teacher.Surname,
                SecondName = teacher.SecondName,
                Name = teacher.Name,
                Post = teacher.Post,
                SubjectId = teacher.SubjectId,
                //SubjectName = teacher.SubjectName != null ? new SubjectDTO { Id = teacher.SubjectName.Id, Name = teacher.SubjectName.Name }:null
            };
        }
        public TeacherViewModel Map(TeacherDTO teacher)
        {
            SubjectDTO _subj = teacher.SubjectId!=null?subjectService.GetById(teacher.SubjectId.Value):null;
            SubjectViewModel subj=_subj!=null?new SubjectViewModel{ Id = _subj.Id, Name = _subj.Name }:null;
            return new TeacherViewModel
            {
                Id = teacher.Id,
                Surname = teacher.Surname,
                SecondName = teacher.SecondName,
                Name = teacher.Name,
                Post = teacher.Post,
                SubjectId = teacher.SubjectId,
                SubjectName = subj
            };
        }
    }
}
