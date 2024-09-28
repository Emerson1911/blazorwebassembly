using ENAEBLazor;
using ENAEBLazor.ProductService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Cambia la base URL para que apunte a tu servidor Node.js
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:3000") });

// Registrar ProductService
builder.Services.AddScoped<ProductService>();

await builder.Build().RunAsync();
