using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;
using Microsoft.AspNet.Cors.Core;

namespace Mashup.Api.Quality
{

    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // ------------------------------------------------------------------------------------
            // Setup configuration sources.
            // I discovered ConfigurationBuilder at this link.
            // https://github.com/aspnet/Announcements/issues/25
            // Excellent article on configuration.
            // http://trondjun.com/custom-configuration-mvc-6-and-asp-net-5-microsoft-framework-configuration/
            // ------------------------------------------------------------------------------------

            var configurationBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile($"config.{appEnv.Configuration}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = configurationBuilder.Build();

            // Just testing
            var connectionString = Configuration.Get("connections:testEnv");

        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();

            // -------------------------------------------------------------------------------------
            // Cors policy documentation
            // http://mvc.readthedocs.org/en/latest/security/cors-policy.html
            // http://docs.asp.net/en/latest/security/cors.html
            // -------------------------------------------------------------------------------------

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));

            });

            services.ConfigureCors(options =>
            {
                // Define one or more CORS policies
                options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("*")
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .AllowAnyHeader()
                           .AllowAnyOrigin()
                           .AllowCredentials();
                });
            });

            // ------------------------------------------------------------
            // DEPENDENCY INJECTION
            // Add the Configuration to Dependency Injection.
            services.AddSingleton(_ => Configuration);
            // ------------------------------------------------------------
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            app.Use((context, next) =>
            {
                if (context.Request.Headers.Any(k => k.Key.Contains("Origin")) && context.Request.Method == "OPTIONS")
                {
                    context.Response.StatusCode = 200;
                    return context.Response.WriteAsync("handled");
                }

                return next.Invoke();
            });

            // Enables cors for all requests.
            app.UseCors("allowall");
            
            // Add MVC to the request pipeline.
            app.UseMvc();
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");

            // custom middleware to checked each call as it comes in.
            //app.Use(async (httpContext, next) =>
            //{
            //    httpContext.Response.OnSendingHeaders((state) =>
            //    {

            //        if (httpContext.Request.Path.Value.Contains("api/") && httpContext.Request.Method == "OPTIONS")
            //        {
            //            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { httpContext.Request.Headers["Origin"] });
            //            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            //            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
            //            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
            //            return;
            //        }
            //    }, null);

            //    await next();

            //});


            //app.Use(async (HttpContext httpcontext, Func<Task> next) =>
            //{
            //    //var sw = Stopwatch.StartNew();

            //    httpcontext.Response.OnSendingHeaders((state) =>
            //    {
            //        // sw.Stop();
            //        httpcontext.Response.Headers.Add("X-Response-Time", new string[] { "ms" });
            //    }, null);
            //    await next.Invoke();
            //});




        }




    }
}

