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

Comando para estructurar el codigo de la ingenieria inversa en visual studio code:
dotnet ef dbcontext scaffold "Data Source=Promotions/Promotions.db" Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models

Comando para trabajar con Code first en visual studio code:
git clone https://github.com/MicrosoftDocs/mslearn-persist-data-ef-core
cd mslearn-persist-data-ef-core
code .

dotnet build
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate --context PizzaContext
dotnet ef database update --context PizzaContext

*/
