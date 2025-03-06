namespace WebApi.Data
{
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<PizzaContext>();
                    context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
            }
        }
    }
}

/*
If a database doesn't exist, EnsureCreated creates a new database. 
    The new database isn't configured for migrations, 
so use this method with caution.

Puedes experimentar con la aplicación. Siempre que quieras empezar 
con una base de datos nueva, detén la aplicación y elimina los 
archivos ContosoPizza.db , .db-shm y .db-wal . 
Luego, vuelve a ejecutar la aplicación.

*/


