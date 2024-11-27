using Microsoft.EntityFrameworkCore;

namespace NutriBase.Logic.DataContext;

/// <summary>
/// Entity Framework data-context for the application.
/// </summary>
internal class ProjectDbContext : DbContext
{
    private static readonly string ConnectionString = "Data source= ../Database/nutriBase.db";

    public ProjectDbContext()
    {
        BeforeClassInitialize();
        AfterClassInitialize();
    }
    private void BeforeClassInitialize(){}
    private void AfterClassInitialize(){}

    public DbSet<Entities.Account.User>? UserSet { get; set; }
    public DbSet<Entities.App.Recipe>? RecipeSet { get; set; }
    public DbSet<Entities.App.ShoppingList>? ShoppingListSet { get; set; }
    public DbSet<Entities.Base.Grocery>? GrocerieSet { get; set; }
    public DbSet<Entities.Base.HouseholdItem>? HouseholdItemSet { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var handled = false;

        BeforeOnConfiguring(optionsBuilder, ref handled);
        if (handled == false)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
        AfterOnConfiguring(optionsBuilder);
        base.OnConfiguring(optionsBuilder);
    }
    static  void BeforeOnConfiguring(DbContextOptionsBuilder optionsBuilder, ref bool handled){}
    static  void AfterOnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    public DbSet<E> GetDbSet<E>() where E : Entities.IdentityEntity
    {
        var handled = false;
        var dbSet = default(DbSet<E>);

        if(handled == false || dbSet == null)
        {
            if(typeof(E) == typeof(Entities.Account.User))
            {
                dbSet = UserSet as DbSet<E>;
                handled = true;
            }
            if(typeof(E) == typeof(Entities.App.Recipe))
            {
                dbSet = RecipeSet as DbSet<E>;
                handled = true;
            }
            if(typeof(E) == typeof(Entities.App.ShoppingList))
            {
                dbSet = ShoppingListSet as DbSet<E>;
                handled = true;
            }
            if(typeof(E) == typeof(Entities.Base.Grocery))
            {
                dbSet = GrocerieSet as DbSet<E>;
                handled = true;
            }
            if(typeof(E) == typeof(Entities.Base.HouseholdItem))
            {
                dbSet = HouseholdItemSet as DbSet<E>;
                handled = true;
            }
        }
        return dbSet ?? Set<E>();
    }
}
