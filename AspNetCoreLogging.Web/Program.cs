var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// .Net 7 ile Logging sýnýfýný built-in olarak çaðýrabiliyoruz.
// ClearProviders ile bütün providerlar kalkýyor.Debug-Console-Event Source ve diðerleri kalmýþ oluyor.
//builder.Logging.ClearProviders();

var app = builder.Build();

// DI kullanýlamayacak durumlarda aþaðýdaki gibi logger servisine ulaþabilir ve loglama yapabiliriz.Örnek(Program)
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application starting");


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
