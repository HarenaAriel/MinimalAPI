using Microsoft.OpenApi.Models;
using ApiRFIDSys.Data;
using ApiRFIDSys.Models;
using ApiRFIDSys.Context;

var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "RFIDSys API", Description = "RFIDSys", Version = "v1" });
});
    
var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
     app.UseDeveloperExceptionPage();
}
    
app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "RFIDSys API V1");
});

// All instance and attributes to use
ProductData productData = new ProductData();

// Access to DB
ProductContext pContext = new ProductContext(DBConnection.GetConnection());
MemoryTypeContext mTContext = new MemoryTypeContext(DBConnection.GetConnection());
TagCodeRFIDContext tCRFIDContext = new TagCodeRFIDContext(DBConnection.GetConnection());


// Handling API calls and consums ------------------------- LOCAL
// READ
app.MapGet("/ApiRFIDSys", () => productData.GetAllProducts());
app.MapGet("/ApiRFIDSys/{id}", (int id) => productData.GetProduct(id));
// POST
app.MapPost("/ApiRFIDSys/Create", (Product product) => productData.CreateProduct(product));
// PUT
app.MapPut("/ApiRFIDSys/Edit", (Product product) => productData.EditProduct(product));
// DELETE
app.MapDelete("/ApiRFIDSys/Delete/{id}", (int id) => productData.DeleteProduct(id));

// -------------------------------------------------------- PERSISTANT
// ---------------------------- PRODUCT
// READ
app.MapGet("/ApiRFIDSys/FromDB", () => pContext.GetAllProductFromDB());
app.MapGet("/ApiRFIDSys/FromDB/{id}", (int id) => pContext.GetProductByIDFromDB(id));
app.MapGet("/ApiRFIDSys/CheckFromDB/{message}", (string message) => pContext.GetProductFromDB(message));
// POST
app.MapPost("/ApiRFIDSys/FromDB/Create", (Product product) => pContext.CreateNewProductToDB(product));
// PUT
app.MapPut("/ApiRFIDSys/FromDB/Edit", (Product product) => pContext.EditProductToDB(product));
//DELETE
app.MapDelete("/ApiRFIDSys/FromDB/Delete/{id}", (int id) => pContext.DeleteProductToDB(id));

// ---------------------------- MEMORYTYPE
// READ
app.MapGet("/MemoryType/FromDB", () => mTContext.GetAllMemoryTypes());
app.MapGet("/MemoryType/FromDB/{id}", (int id) => mTContext.GetMemoryTypesByID(id));

// ---------------------------- TAGCODERFID
// READ
app.MapGet("/TagCodeRFID/FromDB", () => tCRFIDContext.GetAllTagCodeRFID());
app.MapGet("/TagCodeRFID/FromDB/{id}", (int id) => tCRFIDContext.GetTagCodeRFIDByID(id));
app.MapGet("/TagCodeRFID/CodeFromDB/{memoryTypeId}", (int memoryTypeId) => tCRFIDContext.GetAllOfMemoryTagCodeRFID(memoryTypeId));

// -------------------------------------------------------- RUN APP
app.Run();
