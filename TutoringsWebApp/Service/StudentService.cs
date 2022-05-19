namespace TutoringsWebApp.Service;

public class StudentService
{
    private readonly TutoringsContext _db;

    public StudentService(TutoringsContext db)
    {
        _db = db;
    }

    public IEnumerable<Student> GetAll()
    {
        return _db.Students
            .Include(x => x.Tutorings)
            .ThenInclude(x => x.Subject)
            .Include(x => x.Clazz)
            .AsEnumerable();
    }

    public Tutoring InsertTutoring(Tutoring newTutoring)
    {
        _db.Tutorings.Add(newTutoring);
        _db.SaveChanges();
        return newTutoring;
    }
}