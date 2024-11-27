using System;

namespace NutriBase.Logic.Controllers;

public abstract class GenericController<TEntity> : ControllerObject
    where TEntity : Entities.IdentityEntity
{}
