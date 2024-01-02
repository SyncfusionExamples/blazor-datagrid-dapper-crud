using BlazorWebApp.Shared.Data;
using BlazorWebApp.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<BugDataAdaptor>();
builder.Services.AddScoped<ClientServices>();

await builder.Build().RunAsync();
