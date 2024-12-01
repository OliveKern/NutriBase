using System;
using NutriBase.Logic.Entities.App;

namespace NutriBase.Logic.Controllers.App;

public class RecipesController : GenericController<Entities.App.Recipe>
{
    public RecipesController() : base()
    {
        
    }

    public async ValueTask<Recipe?> GetWithProductsByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        return entity;
    }

}
