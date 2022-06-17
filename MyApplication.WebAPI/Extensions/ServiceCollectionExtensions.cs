using MyApplication.DAL.Extensions;

namespace MyApplication.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddSwaggerGen();
        }
    }
}
