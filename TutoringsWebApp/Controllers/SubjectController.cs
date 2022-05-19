using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringsWebApp.DTOs;
using TutoringsWebApp.Service;

namespace TutoringsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        
        private readonly SubjectService _subjectService;

        public SubjectController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        
        // GET: api/Subjects
        [HttpGet]
        public IEnumerable<SubjectDto> Get()
        {
            return _subjectService.GetAll().Select(x => new SubjectDto()
            {
                SubjectId = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}