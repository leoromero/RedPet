using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedPet.API.Infrastructure.Swagger;
using RedPet.Core;
using RedPet.Database;
using RedPet.Database.Repositories;
using RedPet.Core.Base;
using RedPet.Database.Entities;
using Microsoft.AspNetCore.Identity;
using RedPet.Database.Entities.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using RedPet.Core.Auth;
using RedPet.Common.Auth.Models;

namespace RedPetAPI
{
    public class Startup
    {
        private readonly List<string> versions = new List<string> { "1" };
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            services.AddAutoMapper();
            services.AddSwaggerGen(SwaggerGen);
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            var connectionString = Configuration.GetConnectionString("RedPet");
            services.AddDbContext<RedPetContext>(o =>
                o.UseSqlServer(connectionString, x => x.MigrationsAssembly("RedPet.Database.Migrations")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<RedPetContext>();
            
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            services.AddHttpClient<IFacebookClient, FacebookClient>();

            services.Configure<FacebookAuthSettings>(Configuration.GetSection(nameof(FacebookAuthSettings)));

            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterAssemblyTypes(typeof(GenericRepository<>).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(BaseService).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Populate(services);

            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger(c => c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
            {
                if (!env.IsDevelopment())
                {
                    swaggerDoc.BasePath = "/api";
                }
            }));

            app.UseSwaggerUI(UseSwaggerUI)
                .UseMvc()
                .MapWhen(x => x.Request.Path == "/api", RedirectToSwagger);

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
        /// <summary>
        ///     UseSwaggerUI
        /// </summary>
        /// <param name="options"></param>
        private void UseSwaggerUI(SwaggerUIOptions options)
        {
            versions.ForEach(version => options.SwaggerEndpoint($"{version}/swagger.json", $"API v{version}"));
        }

        /// <summary>
        ///     SwaggerGen
        /// </summary>
        /// <param name="options"></param>
        private void SwaggerGen(SwaggerGenOptions options)
        {
            versions.ForEach(version => options.SwaggerDoc(version,
                new Info { Title = "RedPet", Version = $"v{version}" }));

            //Determine base path for the application.
            var basePath = AppContext.BaseDirectory;
            var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            var fileName = System.IO.Path.GetFileName(assemblyName + ".xml");
            var xmlPath = System.IO.Path.Combine(basePath, fileName);

            //Set the comments path for the Swagger JSON and UI.
            options.IncludeXmlComments(xmlPath);
            options.DescribeAllEnumsAsStrings();
            options.DocInclusionPredicate(HasVersion);

            //Setear configuracion para no harcodear el false
            options.OperationFilter<AddAuthorizationHeader>(false);
            options.OperationFilter<AddApiVersionHeader>(versions.Last());
            options.OperationFilter<AddUnprocessibleEntityResponseType>();
            options.OperationFilter<AddInternalServerErrorResponseType>();
            options.OperationFilter<RemoveExtraneousContentTypes>();
            options.OrderActionsBy(x => $"{x.RelativePath} {x.HttpMethod}");
        }

        /// <summary>
        ///     RedirectToSwagger
        /// </summary>
        /// <param name="applicationBuilder"></param>
        private void RedirectToSwagger(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(y =>
            {
                y.Response.Redirect("swagger/");

                return Task.CompletedTask;
            });
        }

        /// <summary>
        ///     HasVersion
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="apiDesc"></param>
        /// <returns></returns>
        private bool HasVersion(string docName, ApiDescription apiDesc)
        {
            if (!apiDesc.TryGetMethodInfo(out var methodInfo)) return false;

            var versions = methodInfo.DeclaringType
                .GetCustomAttributes(true)
            .OfType<ApiVersionAttribute>()
            .SelectMany(attr => attr.Versions)
            .ToList();

            return versions.Any(v => v.ToString() == docName) ||
                   versions.Any();
        }
    }
}
