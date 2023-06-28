
using Microsoft.OpenApi.Models;


namespace LOGIN
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // ...otros servicios y configuraciones...

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Login", Version = "v1" });
            });

            // ...otros servicios y configuraciones...
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...otros middleware...

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Login v1");
            });

            // ...otros middleware...
        }

    }
}
