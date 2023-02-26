using ContactsManager.Data;
using ContactsManager.Helper;
using ContactsManager.Repositories.ContactRepository.Contract;
using ContactsManager.Repositories.ContactRepository.Interface;
using ContactsManager.Repositories.UserRepository.Contract;
using ContactsManager.Repositories.UserRepository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("StrCon");

builder.Services.AddDbContext<ContactContext>(options =>
{
    options.UseSqlServer(connection);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ContactsManager.Helper.ISession, Session>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IContactRepo, ContactRepo>();
builder.Services.AddSession(x =>
{
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});


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
app.UseSession();   
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
