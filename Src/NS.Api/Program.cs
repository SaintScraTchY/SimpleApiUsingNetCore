using Microsoft.OpenApi.Models;
using NS.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",new OpenApiInfo()
    {
        Version = "v1",
        Title = "نادین سافت کارآموزی Task"
    });
    //https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/2771   
    options.MapType<DateOnly>(() => new OpenApiSchema
        {
            Type = "string",
            Format = "date"
        }
    );
});

var app = builder.ConfigureServices();

await app.CreateDataBase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
