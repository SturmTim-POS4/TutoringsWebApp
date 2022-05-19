using TutoringsWebApp.DTOs;
using TutoringsWebApp.Service;

namespace TutoringsWebApp.Controllers;

[Route("[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }
        
    // GET: api/Students?clazzname={clazzname}
    [HttpGet("/Students/{clazzName}")]
    public IEnumerable<StudentDto> GetClazzes(string clazzName)
    {
        return _studentService.GetAll().Where(x => x.Clazz.Name.ToLower() == clazzName.ToLower()).Select(x => new StudentDto()
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Mail,
            Phone = x.Phone,
            ClazzName = x.Clazz.Name,
        }).ToList();
    }
    
    // GET: api//Students/{id}/Tutorings
    [HttpGet("/Students/{id}/Tutorings")]
    public IEnumerable<TutoringDto> GetTutorings(int id)
    {
        return _studentService.GetAll().Where(x => x.Id == id).First().Tutorings.Select(x => new TutoringDto()
        {
            Id = x.Id,
            Schulstufe = x.Schulstufe,
            SubjectName = x.Subject.Name
        }).ToList();
    }
    
    [HttpPost("/Students/Tutoring")]
    public ActionResult<Tutoring> Post([FromBody] TutoringPostDTO tutoringPostDto)
    {
        var tutoring = _studentService.InsertTutoring(new Tutoring().CopyPropertiesFrom(tutoringPostDto));
        string actionName = nameof(Post);
        var routeValues = new {id = tutoring.Id};

        return CreatedAtAction(actionName, routeValues, tutoring);
    }
}