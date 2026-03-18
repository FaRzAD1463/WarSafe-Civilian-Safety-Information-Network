using WarSafe.Domain.Entities;

public interface IShelterService
{
    Task<List<Shelter>> GetShelters();
}
