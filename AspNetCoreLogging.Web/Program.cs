var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// .Net 7 ile Logging s�n�f�n� built-in olarak �a��rabiliyoruz.
// ClearProviders ile b�t�n providerlar kalk�yor.Debug-Console-Event Source ve di�erleri kalm�� oluyor.
//builder.Logging.ClearProviders();

var app = builder.Build();

// DI kullan�lamayacak durumlarda a�a��daki gibi logger servisine ula�abilir ve loglama yapabiliriz.�rnek(Program)
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
