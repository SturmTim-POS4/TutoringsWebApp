using TutoringsWebApp.DTOs;
using TutoringsWebApp.Service;

namespace TutoringsWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClazzController : ControllerBase
{
        
    private readonly ClazzService _clazzService;

    public ClazzController(ClazzService clazzService)
    {
        _clazzService = clazzService;
    }
        
    // GET: api/Clazzes
    [HttpGet]
    public IEnumerable<ClazzDto> Get()
    {
        return _clazzService.GetAll().Select(x => new ClazzDto()
        {
            ClazzId = x.Id,
            Name = x.Name
        }).ToList();
    }
}