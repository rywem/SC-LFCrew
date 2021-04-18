using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SCLFCrew.Application.AppUsers;
using SCLFCrew.Application.Helpers;
using SCLFCrew.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace SCLFCrew.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddMediatR(typeof(Login.Handler).Assembly);
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            return services;
        }
    }
}