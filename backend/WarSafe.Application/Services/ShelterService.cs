using WarSafe.Domain.Entities;
using WarSafe.Infrastructure;

public class ShelterService : IShelterService
{
    private readonly AppDbContext _db;

    public ShelterService(AppDbContext db)
    {
        _db = db;
    }

   public async Task<List<Shelter>> GetShelters()
{
    return await _db.Shelters.ToListAsync();
}
}
