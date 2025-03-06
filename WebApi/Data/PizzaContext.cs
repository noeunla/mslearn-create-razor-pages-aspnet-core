using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class PizzaContext : DbContext 
    {
        public PizzaContext(DbContextOptions<PizzaContext> options)
        : base(options)
        {
        }

        public DbSet<Pizza> Pizzas => Set<Pizza>();
        public DbSet<Topping> Toppings => Set<Topping>();
        public DbSet<Sauce> Sauces => Set<Sauce>();

        //https://learn.microsoft.com/en-us/training/modules/persist-data-ef-core

    }
}

/*
 * Manage database schemas
EF Core provides two primary ways of keeping your EF Core model 
and database schema in sync:

- Migrations (model as source of truth) Code First -> ContosoPizza.db
- Reverse engineering (database as source of truth) -> Promotions.db

To choose between these options, decide whether your EF Core model 
or the database schema is the source of truth.

Migrations o Code First, crea la bd a partir del modelo
Reverse engineering, crea el modelo a partir de una bd ya existente


*/
