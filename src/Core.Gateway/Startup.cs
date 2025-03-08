using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Core.Gateway
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
            services.AddOcelot(Configuration);
            services.AddSwaggerForOcelot(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwaggerForOcelotUI(opt => {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });         
            app.UseOcelot().Wait();
        }
    }
}