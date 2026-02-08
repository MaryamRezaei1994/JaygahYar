using JaygahYar.Application;
using JaygahYar.Infrastructure;
using JaygahYar.Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using JaygahYar.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// Configuration (pattern copied from Survey)
// --------------------------------------------------
ConfigurationData.Config(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.Configure<FormOptions>(options =>
{
    // UI allows up to 128MB uploads
    options.MultipartBodyLengthLimit = 134_217_728;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
