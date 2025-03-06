using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebApi.Data;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<PizzaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers()
//            .AddNewtonsoftJson(options =>
//            {
//                //para el metodo patch
//                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//            });

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

//Defines a SQLite connection string that points to a local file, ContosoPizza.db
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//This code calls the extension method that you defined earlier each time the app runs.
app.CreateDbIfNotExists();

app.MapGet("/", () => @"Contoso Pizza management API. Navigate to /swagger to open the Swagger test UI.");


app.Run();


//https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core
//dotnet new webapi - controllers - f net8.0
//dotnet dev-certs https --trust


