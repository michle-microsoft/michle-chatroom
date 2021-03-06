using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chat_Room_Tutorial
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR()
                .AddAzureSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use web pages added in wwwroot folder.
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Use routing.
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Use the /chat endpoint so clients can access the hub using this URL.
                endpoints.MapHub<Chat>("/chat");
            });
        }
    }
}
