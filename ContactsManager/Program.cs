using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Design;
using ContactsManager.Repositories.ContactRepository.Contract;
using ContactsManager.Repositories.ContactRepository.Interface;
using ContactsManager.Repositories.UserRepository.Contract;
using ContactsManager.Repositories.UserRepository.Interface;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("StrCon");

builder.Services.AddDbContext<ContactContext>(options =>
{
    options.UseSqlServer(connection);
});
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IContactRepo, ContactRepo>();




builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
