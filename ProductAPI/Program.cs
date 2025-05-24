using ProductAPI.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ProductService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
}
app.MapControllers(); 
app.Run();

