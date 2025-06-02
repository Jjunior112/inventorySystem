using inventorySystem.application.interfaces;
using inventorySystem.application.services.OperationService;
using inventorySystem.application.services.ProductService;
using inventorySystem.domain.models;
using inventorySystem.infrastructure.persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Swagger

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

//Database

builder.Services.AddDbContext<UserDbContext>(options =>
{

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(connectionString);

    options.LogTo(Console.WriteLine, LogLevel.Information);

});

//Services

builder.Services.AddScoped<IService<Operation>,OperationService>();
builder.Services.AddScoped<IService<Product>,ProductService>();

builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<UserDbContext>();


builder.Services.AddControllers();

builder.Services.AddAuthorization();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.MapControllers();


app.Run();