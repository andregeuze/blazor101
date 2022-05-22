using BlazorAppGeneratingJSComponents;
using JSComponentGeneration.React;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder? builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.RegisterForReact<Counter>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
