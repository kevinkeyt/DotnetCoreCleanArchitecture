using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces;


public interface IUserRepository
{
    Task<List<User>> GetUserByEmail(string email);
}