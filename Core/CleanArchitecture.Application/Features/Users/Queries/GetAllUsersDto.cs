
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Common.Mappings;

namespace CleanArchitecture.Application.Features.Users.Queries;
public class GetAllUsersDto : IMapFrom<User>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
}