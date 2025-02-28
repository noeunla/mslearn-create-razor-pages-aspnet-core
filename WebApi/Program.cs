using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                //para el metodo patch
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

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

app.Run();


//https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core
//dotnet new webapi - controllers - f net8.0
//dotnet dev-certs https --trust


