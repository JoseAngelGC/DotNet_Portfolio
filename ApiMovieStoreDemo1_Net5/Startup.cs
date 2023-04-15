using ApiMovieStoreDemo1_Net5.Data;
using ApiMovieStoreDemo1_Net5.Helpers;
using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models.Mappers;
using ApiMovieStoreDemo1_Net5.Repository;
using ApiMovieStoreDemo1_Net5.Repository.IRepository;
using ApiMovieStoreDemo1_Net5.Services;
using ApiMovieStoreDemo1_Net5.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ApiMovieStoreDemo1_Net5
{
    public class Startup
    {
        readonly string ApiCorsPolicy = "ApiCorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //dbContext
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            //HttpContextAccessor
            services.AddHttpContextAccessor();

            //Services
            services.AddScoped<ICommonServiceHelpers, CommonServiceHelpers>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserAuthService, UserAuthService>();

            //Repositories
            services.AddScoped<ICategoryRepositoryHelpers, CategoryRepositoryHelpers>();
            services.AddScoped<IMovieRepositoryHelpers, MovieRepositoryHelpers>();
            services.AddScoped<IUserAuthRepositoryHelpers, UserAuthRepositoryHelpers>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserAuthRepository, UserAuthRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(ModelsMapper));

            //Token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            //Cors Configuration
            services.AddCors(options => {
                options.AddPolicy(name: ApiCorsPolicy, builder =>
                {
                    builder.WithHeaders("*");
                    builder.WithOrigins("*");
                    builder.WithMethods("*");
                });
            });

            //Api Versioning configuration
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            //Controllers
            services.AddControllers();

            //Swagger Configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("ApiCategories_v1", new OpenApiInfo
                {
                    Title = "Api Categories (MovieStoreDemo1)",
                    Version = "v1",
                    Description = "Backend Api Categories de MovieStore_Demo1 en .Net Core 5",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "joangl007@hotmail.com",
                        Name = "José Angel Contreras González"
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://es.wikipedia.org/wiki/Licencia_MIT")
                    }
                });


                c.SwaggerDoc("ApiMovies_v1", new OpenApiInfo
                {
                    Title = "Api Movies (MovieStoreDemo1)",
                    Version = "v1",
                    Description = "Backend Api Movies de MovieStoreDemo1 en .Net Core 5",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "joangl007@hotmail.com",
                        Name = "José Angel Contreras González"
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://es.wikipedia.org/wiki/Licencia_MIT")
                    }
                });

                c.SwaggerDoc("ApiUsers_v1", new OpenApiInfo
                {
                    Title = "Api Users (MovieStoreDemo1)",
                    Version = "v1",
                    Description = "Backend Api Users de MovieStoreDemo1 en .Net Core 5",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "joangl007@hotmail.com",
                        Name = "José Angel Contreras González"
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://es.wikipedia.org/wiki/Licencia_MIT")
                    }
                });

                var xmlFileSwaggerDoc = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var pathXmlFileSwaggerDoc = Path.Combine(AppContext.BaseDirectory, xmlFileSwaggerDoc);
                c.IncludeXmlComments(pathXmlFileSwaggerDoc);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authentication JWT (Bearer)",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id="Bearer",
                                Type=ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/ApiCategories_v1/swagger.json", "ApiCategories v1");
                    c.SwaggerEndpoint("/swagger/ApiMovies_v1/swagger.json", "ApiMovies v1");
                    c.SwaggerEndpoint("/swagger/ApiUsers_v1/swagger.json", "ApiUsers v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(ApiCorsPolicy);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
