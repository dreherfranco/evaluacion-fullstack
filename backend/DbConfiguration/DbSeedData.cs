using backend.Models;

namespace backend.DbConfiguration
{
    public static class DbSeedData
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Clients.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Clients.AddRange(
                    new Client() { Id = 1, Name = "Franco", LastName = "Dreher", Direccion = "Direccion cliente 1" },
                    new Client() { Id = 2, Name = "Agustin", LastName = "Dreher", Direccion = "Direccion cliente 2" },
                    new Client() { Id = 3, Name = "Tomas", LastName = "Zappala", Direccion = "Direccion cliente 3" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
