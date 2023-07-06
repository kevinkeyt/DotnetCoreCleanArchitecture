using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public decimal Total { get; set; }
    public decimal Shipping { get; set;}
    public decimal Tax { get; set;}
    public decimal SubTotal { get; set; }
}