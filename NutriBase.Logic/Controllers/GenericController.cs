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

    //Implement Include 
    // internal virtual IEnumerable<string> Includes => Array.Empty<string>();

    public virtual async Task<int> SaveChangesAsync()
    {
        if (Context == null)
            throw new Exception("Invalid context");

        int res = 0;

        try
        {
            res = await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return res;
    }

    public virtual async Task<TEntity> InsertAsync(TEntity entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity));
        if (Context == null)
            throw new Exception("Invalid context");

        await EntitySet.AddAsync(entity).ConfigureAwait(false);

        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity));
        if (Context == null)
            throw new Exception("Invalid context");

        return await Task.Run(() =>
        {
            EntitySet.Update(entity);
            return entity;
        }).ConfigureAwait(false);
    }

    public virtual async Task<TEntity?> DeleteAsync(int id)
    {
        if(Context == null)
            throw new Exception("Invalid context");

        return await Task.Run(() =>
        {
            TEntity? entity = EntitySet.Find(id);

            if(entity != null)
                EntitySet.Remove(entity);

            return entity == null? null : entity;      //eventually wrong to return something and await Task <Test it!>
        }).ConfigureAwait(false);
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        if (Context == null)
            throw new Exception("Invalid context");

        return await EntitySet.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
    }

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        if (Context == null)
            throw new Exception("Invalid context");

        return await EntitySet.ToListAsync().ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<TEntity>> InsertMultipleAsync(List<TEntity> entities)
    {
        if(Context == null)
            throw new Exception("Invalid context");

        await EntitySet.AddRangeAsync(entities).ConfigureAwait(false);

        return entities;
    }
}
