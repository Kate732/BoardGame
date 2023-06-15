using System.Text.Json.Serialization;
using BoardSite.Data;

namespace BoardSite {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services
                   .AddControllers()  // api
                   .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); }); // enums as texts
            builder.Services.AddSwaggerGen(); // swagger
            var app = builder.Build();

            // swagger usually is enabled in dev mode only
            app.UseSwagger();   // swagger
            app.UseSwaggerUI(); // swagger

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            //app.MapBlazorHub();              // comment due to add controllers
            //app.MapFallbackToPage("/_Host"); // comment due to add controllers
            app.UseEndpoints(endpoints =>      // adds api controllers with blazor
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                //endpoints.MapRazorPages();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.Run();
        }
    }
}