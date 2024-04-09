using Presupuestos.Filters;
using Presupuestos.Infraestructure;
using Presupuestos.Services;
using Presupuestos.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<TipoCuenta>()
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.SetMinimumLevel(LogLevel.Debug);
});

 
builder.Services.AddScoped<GlobalExceptionFilter>();


builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});


builder.Services.AddTransient<ITiposCuentasServices, TiposCuentasServices>();
builder.Services.AddTransient<IUsuariosServices, ServiciosUsuarios>();



























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
