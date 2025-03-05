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
