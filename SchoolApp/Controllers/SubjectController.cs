using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.BLL.Services;
using SchoolApp.BLL.Interfaces;
using SchoolApp.BLL.DTO;
using SchoolApp.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolApp.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        ISubjectService subjectService;
        public SubjectController(ISubjectService service)
        {
            subjectService = service;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<SubjectDTO> subjectDTO = subjectService.GetAll();
            List<SubjectViewModel> subjectList = new List<SubjectViewModel>();
            foreach(var subject in subjectDTO)
            {
                subjectList.Add(Map(subject));
            }
            return View("index",subjectList);
        }

        // GET api/values/5
        [HttpGet("{Id}")]
        public ActionResult Get(int? Id)
        {
            if (Id != null)
            {
                SubjectDTO _subject=subjectService.GetById(Id.Value);
                SubjectViewModel subject = Map(_subject);
                return PartialView("Modify", subject);
            }           
                
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] SubjectViewModel subject)
        {
            if (subject != null)
            {
                subjectService.CreateSubject(Map(subject));
            }
            //
        }

        // PUT api/values/5
        [HttpPut("{Id}")]
        public void EditSubject(int? Id, [FromBody] SubjectViewModel subject)
        {
            if ((Id != null)&(subject != null))
            {
                    subjectService.UpdateSubject(Map(subject));
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            subjectService.RemoveSubject(id);
        }
        public SubjectDTO Map(SubjectViewModel subject)
        {
            return new SubjectDTO { Id = subject.Id, Name = subject.Name };
        }
        public SubjectViewModel Map(SubjectDTO subject)
        {
            return new SubjectViewModel { Id = subject.Id, Name = subject.Name };
        }
    }
}
