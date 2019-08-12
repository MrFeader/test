using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class PupilController : Controller
    {
        IPupilService pupilService;
        IGradeService gradeService;
        public PupilController(IPupilService service, IGradeService gservice)
        {
            pupilService = service;
            gradeService = gservice;
        }
        //GET: api/Pupil

        [HttpGet]
        public IActionResult Index(string Surname, int? Age, string GradeName)
        {
            GradeViewModel grade = String.IsNullOrEmpty(GradeName)==false? Map(gradeService.GetAll().Where(x => x.Name == GradeName).FirstOrDefault()):null;
            IEnumerable<PupilDTO> PupilDTO = pupilService.GetAll();
            List<PupilViewModel> pupilList = new List<PupilViewModel>();
            foreach (var pupil in PupilDTO)
            {
                bool ok = true;
                if (!String.IsNullOrEmpty(Surname))
                {
                    if(!pupil.Surname.ToLower().Contains(Surname.ToLower()))
                    ok =  false;
                }
                if (Age != null)
                {
                    if(pupil.Age != Age)
                    ok =  false;
                }
                if (grade != null)
                {
                    if(pupil.GradePropId != grade.Id)
                    ok =  false;
                }
                if (ok) pupilList.Add(Map(pupil));
            }
            return View("View", pupilList);
        }

        // GET: api/Pupil/5
        [HttpGet("{id}")]
        public IActionResult Get(int? Id)
        {
            if (Id != null)
            {
                PupilDTO _pupil = pupilService.GetById(Id.Value);
                PupilViewModel pupil = Map(_pupil);
                List<PupilViewModel> pupils = new List<PupilViewModel> { pupil };
                return View("View", pupils);
            }

            return NotFound();
        }

        // POST: api/Pupil
        [HttpPost]
        public void Post([FromBody] PupilViewModel pupil)
        {
            pupilService.CreatePupil(Map(pupil));
        }

        // PUT: api/Pupil/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PupilViewModel pupil)
        {
            pupilService.UpdatePupil(Map(pupil));
        }
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] int? GradeId)
        {
            GradeId = GradeId == 0 ? null : GradeId;
            pupilService.PatchPupil(id, GradeId);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pupilService.RemovePupil(id);
        }
        public PupilViewModel Map(PupilDTO pupil)
        {
            return new PupilViewModel
            {
                Id = pupil.Id,
                Surname = pupil.Surname,
                Name = pupil.Name,
                SecondName = pupil.SecondName,
                Birthday = pupil.Birthday,
                Gender = pupil.Gender,
                //new GradeProp = pupil.GradeProp,
                GradePropId = pupil.GradePropId
            };
        }
        public PupilDTO Map(PupilViewModel pupil)
        {
            return new PupilDTO
            {
                Id = pupil.Id,
                Surname = pupil.Surname,
                Name = pupil.Name,
                SecondName = pupil.SecondName,
                Birthday = pupil.Birthday,
                Gender = pupil.Gender,
                //new GradeProp = pupil.GradeProp,
                GradePropId = pupil.GradePropId
            };
        }
        public GradeViewModel Map(GradeDTO grade)
        {
            return new GradeViewModel { Id = grade.Id };
        }
    }
}
