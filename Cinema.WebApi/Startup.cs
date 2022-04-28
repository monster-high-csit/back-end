using AutoMapper;
using Cinema.Entities;
using Cinema.IRepositories;
using Cinema.IServices;
using Cinema.Repositories;
using Cinema.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Cinema.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var mappingConfig = new MapperConfiguration(ms => {
                ms.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(new DbOptions() { ConnectionString = connectionString });
            services.AddSingleton(mapper);

            services.AddTransient<IFilmService, FilmService>();
            
            services.AddTransient<IFilmRepository, FilmRepository>();

            services.AddTransient<IActorService, ActorService>();
            services.AddTransient<IActorRepository, ActorRepository>();

            services.AddTransient<IFilmMakersService, FilmMakerService>();
            services.AddTransient<IFilmMakersRepository, FilmMakersRepository>();

            services.AddTransient<IFilmStudioService, FilmStudioService>();
            services.AddTransient<IFilmStudioRepository, FilmStudioRepository>();

            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IGenreRepository, GenreRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IHallService, HallService>();
            services.AddTransient<IHallRepository, HallRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
