using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using Hoff.Application.Common;
using Hoff.WebAPI.WebAPI.Common.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Hoff.WebAPI.WebAPI.Common.Installers
{
    public class MvcWithParamsInstaller : IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options=>ConfigureMvcOptions(options,configuration))
             .AddFluentValidation(options =>
             {
                 options.RegisterValidatorsFromAssemblyContaining<Startup>();
             });

            services.AddApiVersioning();

            services.AddCors(options =>
            {
                options.AddPolicy(WebApiConstants.CorsPolicyName,
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Hoff.WebAPI", Version = "v1.0" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        private MvcOptions ConfigureMvcOptions(MvcOptions options, IConfiguration configuration)
        {
            options.Filters.Add(new ApiExceptionFilter(configuration));

            return options;
        }

    }
}
