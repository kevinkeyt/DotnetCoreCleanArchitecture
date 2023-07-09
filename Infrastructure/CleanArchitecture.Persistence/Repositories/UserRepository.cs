
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<User> _repository;

    public UserRepository(IGenericRepository<User> repository) 
    {
        _repository = repository;
    }

    public async Task<List<User>> GetUserByEmail(string email)
    {
        return await _repository.Entities.Where(x => x.Email == email).ToListAsync();
    }
}