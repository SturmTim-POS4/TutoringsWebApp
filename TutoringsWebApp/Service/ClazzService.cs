namespace TutoringsWebApp.Service;

public class ClazzService
{
    private readonly TutoringsContext _db;

    public ClazzService(TutoringsContext db)
    {
        _db = db;
    }

    public IEnumerable<Clazz> GetAll()
    {
        return _db.Clazzs.AsEnumerable();
    }
}