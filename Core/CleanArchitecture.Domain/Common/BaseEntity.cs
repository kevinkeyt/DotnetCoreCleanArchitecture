using CleanArchitecture.Domain.Common.Interfaces;

namespace CleanArchitecture.Domain.Common;

public abstract class BaseEntity: IEntity
{
    public int Id { get; set; }
}