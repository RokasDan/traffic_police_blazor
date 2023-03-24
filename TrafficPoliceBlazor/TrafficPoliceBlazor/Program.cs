using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using TrafficPoliceBlazor;
using TrafficPoliceBlazor.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// MySQL database connection options!
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(
        "server=localhost;" +
        "port=3306;" +
        "database=police;" +
        "user=root;" +
        "password=",
        new MySqlServerVersion(new Version(8, 0, 23))));

await builder.Build().RunAsync();
