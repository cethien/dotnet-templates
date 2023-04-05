namespace BlazorServerTailwindTemplate.DataAccess.EntityFramework.Models.Common;

public interface IEntityBase
{
    public int Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
}


public abstract class EntityBase : IEntityBase
{
    public int Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
}