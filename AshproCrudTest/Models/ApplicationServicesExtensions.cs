namespace AshproCrudTest.Models
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<Account>, Repository<Account>>();
            return services;
        }
    }
}
