using AutoMapper;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.API.Filters;
using Hahn.ApplicatonProcess.December2020.Business.Services;
using Hahn.ApplicatonProcess.December2020.Core.Repositories;
using Hahn.ApplicatonProcess.December2020.Core.UnitOfWorks;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Data.Repositories;
using Hahn.ApplicatonProcess.December2020.Data.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace Hahn.ApplicatonProcess.December2020.API
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
            services.AddSingleton<HttpClient>(); //for country validation via external api

            services.AddScoped<NotFoundFilter>(); //not found filter for actions
            services.AddAutoMapper(typeof(Startup)); //for AutoMapper

            services.AddControllers();

            //for adding swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.ApplicatonProcess.December2020.API", Version = "v1" });

                //to give extra informations for usage of API  
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.ExampleFilters();
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();

            //ef core in-memory database
            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseInMemoryDatabase("HagnHR");
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Business.Services.Service<>));

            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //Unit of Work for transaction management...


            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;

                    /*if we don't want to add validationfilter to each controller or method 
                    and if we want to add globally this option could set.*/

                    options.Filters.Add<ValidationFilter>();
                    options.Filters.Add(new InterceptionAttribute());

                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        if (!context.ModelState.IsValid)
                        {
                            LogAutomaticBadRequest(context);
                        }

                        return new BadRequestObjectResult(context.ModelState);
                    };
                    
                })
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>()); //for using fluentValidator

                //enable to access from front-end
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
                });

        }

        //for logging http 400 bad request. (fluent validation return messages)
        private void LogAutomaticBadRequest(ActionContext context)
        {
            // Setup logger from DI - as explained in https://github.com/dotnet/AspNetCore.Docs/issues/12157
            var loggerFactory = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger(context.ActionDescriptor.DisplayName);

            // Get error messages
            var errorMessages = string.Join(" | ", context.ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));

            var request = context.HttpContext.Request;

            // Use whatever logging information you want
            logger.LogError("HTTP 400 : " +
                            $"{System.Environment.NewLine}Error(s): {errorMessages}");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicatonProcess.December2020.API v1"));

            }


            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }
    }
}
