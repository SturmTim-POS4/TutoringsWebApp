namespace TutoringsWebApp.Service;

public class SubjectService
{
    private readonly TutoringsContext _db;

    public SubjectService(TutoringsContext db)
    {
        _db = db;
    }

    public IEnumerable<Subject> GetAll()
    {
        return _db.Subjects.AsEnumerable();
    }
}