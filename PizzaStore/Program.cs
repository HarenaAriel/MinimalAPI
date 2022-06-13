using Microsoft.OpenApi.Models;
using PizzaStore.Data;
using PizzaStore.Models;

var data = new PizzaData();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Test pizza", Version = "v1" });
});

var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API v1");
});

// List data
app.MapGet("/pizza", () => data.GetPizzas());
app.MapGet("/pizza/{id}", (int id) => data.GetPizza(id));

// Add Data
app.MapPost("/pizza/Add", (Pizza pizza) => data.AddPizza(pizza));

// Edit Data
app.MapPut("/pizza/{id}/Edit", (int id, Pizza pizza) => data.UpdatePizza(id, pizza));

// Delete Data
app.MapDelete("/pizza/{id}/Delete", (int id) => data.DeletePizza(id));

app.Run();
