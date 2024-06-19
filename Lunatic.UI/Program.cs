using Blazored.LocalStorage;
using Lunatic.UI;
using Lunatic.UI.Contracts;
using Lunatic.UI.Services;
using GloboTicket.TicketManagement.App.Services;
using Lunatic.UI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Lunatic.UI.Auth;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage(config =>
{
	config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
	config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
	config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
	config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
	config.JsonSerializerOptions.WriteIndented = false;
});
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddScoped<CustomStateProvider>();

builder.Services.AddHttpClient<IBookDataService, BookDataService>(client =>
{
	client.BaseAddress = new Uri("http://localhost:5012/");
});


builder.Services.AddHttpClient<IUserDataService, UserDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5012/");
});

builder.Services.AddHttpClient<IRatingDataService, RatingDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5012/");
});

builder.Services.AddHttpClient<IReaderDataService, ReaderDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5012/");
});

builder.Services.AddHttpClient<IBookClubDataService, BookClubDataService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5012/");
});

builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
{
	client.BaseAddress = new Uri("http://localhost:5012/");
});


await builder.Build().RunAsync();
