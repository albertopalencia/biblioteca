using Biblioteca.WebApi.Models;
using Biblioteca.WebApi.Models.IRepositorios;
using Biblioteca.WebApi.Models.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Biblioteca.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddEnvironmentVariables()
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //logRepo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            //XmlConfigurator.Configure(logRepo, new FileInfo("log4net.config"));



            Configuration = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Web Api",
                    Description = "Servicio Biblioteca"
                });
            });

            /*
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            var secret = Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            */
            services.AddSingleton<IRepositorioUsuario, RepositorioUsuario>();
            services.AddSingleton<IRepositorioCategoria, RepositorioCategoria>();
            services.AddSingleton<IRepositorioAutor, RepositorioAutor>();
            services.AddSingleton<IRepositorioLibro, RepositorioLibro>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<BibliotecaContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Biblioteca")));

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api Biblioteca");
                c.DocumentTitle = "Web Api";

            });

            app.UseMvc();
        }
    }
}
