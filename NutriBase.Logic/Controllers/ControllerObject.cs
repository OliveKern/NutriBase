using System;
using NutriBase.Logic.DataContext;

namespace NutriBase.Logic.Controllers;

public abstract class ControllerObject : IDisposable
{
    public readonly bool contextOwner;

    internal ProjectDbContext? Context { get; private set; }

    internal ControllerObject(ProjectDbContext context)
    {
        this.Context = context ?? new ProjectDbContext();
        contextOwner = true;
    }

    protected ControllerObject(ControllerObject other)
    {
        this.Context = other.Context ?? throw new ArgumentNullException(nameof(other.Context));
        contextOwner = false;
    }

    #region Dispose pattern
    public bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if(!disposedValue)
        {
            if(disposing)
            {
                if(contextOwner)
                {
                    Context?.Dispose();
                }
                Context = null;
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
#endregion Dispose pattern
}
