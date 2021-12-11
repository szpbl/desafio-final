using biblioteca.Data.Repositories;
using biblioteca.Data.Repositories.Interfaces;
using bibliotecaAPI.Configuracao;
using bibliotecaAPI.Configuration;
using bibliotecaAPI.Context;
using bibliotecaAPI.Dados.Repositorios;
using bibliotecaAPI.Dados.Repositorios.Interfaces;
using bibliotecaAPI.Services.Auth.Jwt;
using bibliotecaAPI.Services.Auth.Jwt.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace bibliotecaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region JwtConfigurations

            var section = Configuration.GetSection("JwtConfigurations");
            services.Configure<JwtConfigurations>(section);

            #endregion

            #region JwtManagement
            services.AddScoped<IJwtAuthManager, JwtAuthManager>();
            #endregion

            #region Authentication
            services.AddAuthConfiguration(Configuration);
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            #endregion

            #region Versioning
            services.AddVersionApi();
            #endregion

            #region Swagger
            services.AddSwaggerConfiguration();
            #endregion

            #region Context
            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Cors
            services.AddCors(options =>
            {
                options.AddPolicy("Development", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            #endregion

            #region Controllers
            services.AddControllers();
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();

            app.UseCors("Development");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
