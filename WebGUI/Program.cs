using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<TowerDbContext>( 
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(8,0,28))
    )
);

builder.Services.AddScoped<IRepository<SavedGame>,GameRepository>();
builder.Services.AddScoped<IMapRepository, MapRepository>();
builder.Services.AddScoped<ISavedGameRepository, SavedGameRepository>();


var app = builder.Build();
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
