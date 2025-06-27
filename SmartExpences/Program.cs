using Microsoft.EntityFrameworkCore;
using SmartExpenses.Models;
using SmartExpenses.Services;
using SmartExpenses.Services.Infrastucture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<SmartExpensesContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddTransient<IExpenseService, ExpenseService>();
builder.Services.AddTransient<IIncomingService, IncomingService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
