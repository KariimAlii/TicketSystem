using TicketSystem.Persistance.DependencyInjection;
using TicketSystem.WebApi.DependencyInjection;

namespace TicketSystem.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Ticket System Api", Version = "v1" });
                c.EnableAnnotations();
            });

            #region Cors Service

            var PolicyName = "_PolicyName";
            builder.Services.AddCorsServices(PolicyName);

            #endregion

            builder.Services.AddWebApiLayerDependencyInjection(builder.Configuration);

            builder.Services.AddIdentityServices();

           var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
                context.Response.Headers.Add("Access-Control-Max-Age", "86400");
                await next();
            });

            app.UseCors(PolicyName);

            app.UseHttpsRedirection();


            //app.UseAuthentication(); // First
            app.UseAuthorization(); // Second


            app.MapControllers();

            app.Run();
        }
    }
}