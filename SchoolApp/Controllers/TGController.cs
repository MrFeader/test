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
    public class TGController : ControllerBase
    {
        ITeacherGradeService TGService;
        // GET: api/TG
        public TGController(ITeacherGradeService service)
        {
            TGService = service;
        }
        // POST: api/TG
        [HttpPost]
        public void Post([FromBody] TeacherGradeViewModel item)
        {
            TGService.CreateTG(Map(item));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete([FromBody] TeacherGradeViewModel item)
        {
            TGService.RemoveTG(Map(item));
        }
        public TeacherGradeDTO Map(TeacherGradeViewModel tg)
        {
            return new TeacherGradeDTO { GradeId = tg.GradeId, TeacherId = tg.TeacherId };
        }
    }
}
