using Microsoft.OpenApi.Models;

/*
  Ariel
  13-06-2022
  Server configuration
*/

var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "ACSHF API", Description = "ACSHF rfid reader", Version = "v1" });
});
    
var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
     app.UseDeveloperExceptionPage();
}
    
app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "ACSHF API V1");
});

/*
  Ariel
  13-06-2022
  All the API
*/

app.MapGet("/", () => "Hello World!");

/*
  Ariel
  13-06-2022
  Run The Service
*/

app.Run();
