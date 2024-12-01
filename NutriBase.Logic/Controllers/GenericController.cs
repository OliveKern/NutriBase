using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;

namespace NutriBase.Logic.Controllers;

public abstract class GenericController<TEntity> : ControllerObject
    where TEntity : Entities.IdentityEntity, new()
{
    internal GenericController() : base(new DataContext.ProjectDbContext()) 
    {}

    internal GenericController(ControllerObject other) : base(other) 
    {}

    public DbSet<TEntity>? dbSet = null;

    internal DbSet<TEntity> EntitySet
    {
        get
        {
            if(dbSet == null)
            {
                if(Context != null)
                {
                    dbSet = Context.GetDbSet<TEntity>();
                }
                else
                {
                    using var ctx = new DataContext.ProjectDbContext();
                    dbSet = ctx.GetDbSet<TEntity>();
                }
            }
            return dbSet;
        }
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        if (Context == null)
            throw new Exception("Invalid context");

        return await Context.SaveChangesAsync().ConfigureAwait(false);
    }

    public virtual async Task<TEntity> InsertAsync(TEntity entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity));
        if (Context == null)
            throw new Exception("Invalid context");

        var dbSet = Context.GetDbSet<TEntity>();

        await dbSet.AddAsync(entity).ConfigureAwait(false);

        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity));
        if (Context == null)
            throw new Exception("Invalid context");

        var dbSet = Context.GetDbSet<TEntity>();

        return await Task.Run(() =>
        {
            dbSet.Update(entity);
            return entity;
        });
    }

    public virtual async Task<TEntity?> DeleteAsync(int id)
    {
        if(Context == null)
            throw new Exception("Invalid context");

        return await Task.Run(() =>
        {
            var dbSet = Context.GetDbSet<TEntity>();
            TEntity? entity = dbSet.Find(id);

            if(entity != null)
                dbSet.Remove(entity);

            return entity;      //eventually wrong to return something and await Task <Test it!>
        });
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        if (Context == null)
            throw new Exception("Invalid context");

        var entity = await EntitySet.FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }
}
