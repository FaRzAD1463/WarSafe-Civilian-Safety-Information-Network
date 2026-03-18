using WarSafe.Domain.Entities;

public class UserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public List<User> GetAll()
    {
        return _db.Users.ToList();
    }

    public async Task<User> GetByEmail(string email)
    {
        return _db.Users.FirstOrDefault(x => x.Email == email);
    }
}
