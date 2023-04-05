using BlazorServerTailwindTemplate.DataAccess.EntityFramework.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorServerTailwindTemplate.DataAccess.EntityFramework;

public sealed class BlazorServerTailwindTemplateDbContext : DbContext
{
    public BlazorServerTailwindTemplateDbContext(DbContextOptions<BlazorServerTailwindTemplateDbContext> options)
    : base(options)
    {

    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();

        IEnumerable<EntityEntry> entities =
            ChangeTracker
                .Entries()
                .Where(t => t.Entity is IEntityBase);

        if (entities.Any())
        {
            foreach (EntityEntry entry in entities)
            {
                IEntityBase entity = (IEntityBase)entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            entity.CreatedOn = DateTimeOffset.UtcNow;
                            entity.UpdatedOn = DateTimeOffset.UtcNow;
                        }
                        break;
                    case EntityState.Modified:
                        {
                            entity.UpdatedOn = DateTimeOffset.UtcNow;
                        }
                        break;
                    case EntityState.Deleted:
                        {
                            entity.IsDeleted = true;
                            entity.UpdatedOn = DateTimeOffset.UtcNow;
                            entry.State = EntityState.Modified;
                        }
                        break;
                }
            }
        }

        return base.SaveChanges();
    }
}