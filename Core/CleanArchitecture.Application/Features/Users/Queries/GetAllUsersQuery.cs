
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.Users.Queries;

public record GetAllUsersQuery : IRequest<List<GetAllUsersDto>>;

internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllUsersDto>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<User>().Entities
            .ProjectTo<GetAllUsersDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}