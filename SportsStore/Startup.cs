
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportsStore.Models;

namespace SportsStore {

    // See Chapter 14 for more Information about the Startup Class
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) { 

            // This extension method displays details of exceptions that
            // occur in the application, which is useful during the
            // development process. It should not be enabled in deployed
            // applications, and I disable this feature in Chapter 12.
            app.UseDeveloperExceptionPage();

            // This extension method adds a simple message to HTTP
            // responses that would not otherwise have a body, such as
            // 404 - Not Found responses.
            app.UseStatusCodePages();

            // This extension method enables support for serving static
            // content from the wwwroot folder.
            app.UseStaticFiles();

            // This extension method enables ASP.NET Core MVC with a
            // default configuration (which I will change later in the
            // development process).
            app.UseMvcWithDefaultRoute();

        }
    }
}
