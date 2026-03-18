using WarSafe.Domain.Entities;
using WarSafe.Infrastructure.Repositories;

public class UserService : IUserService
{
    private readonly UserRepository _repo;

    public UserService(UserRepository repo)
    {
        _repo = repo;
    }

    public List<User> GetAll()
    {
        return _repo.GetAll();
    }
}
