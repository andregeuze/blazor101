# JavaScript Component Generation

This sample demonstates how Blazor components can be automatically wrapped as components in JavaScript-based SPA frameworks like React.

## Running the React sample

Clone this repo. Then, in a command prompt, execute:

 * `cd BlazorAppGeneratingJSComponents`
 * `dotnet watch`

Leave that running, and open a second command prompt, and execute:

 * `cd react-app-with-blazor`
 * `yarn install`
 * `yarn start`

Now when you browse to http://localhost:3000/, you'll see a React application that dynamically renders Blazor WebAssembly components, passing parameters to them.

## Converting a Blazor Component to a React component
To indicate to the MSBuild tasks that a React wrapper should be generated for a Blazor component, you can add these attributes to the component:

_MyComponent.razor:_
```razor
@attribute [GenerateReact]   // Generate a React component

// ...
```

In order to use these components from a React app, you need to register them in `Program.Main`:

_Program.cs:_
```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.RegisterForReact<MyComponent>();   // Register for React

// ...
```

A generated JS component will accept parameters correlating with the parameters accepted by the Blazor component. Following are the supported parameter types:
* Built-in types (`bool`, `int`, `string`, etc.)
* Complex types (JSON-serializable)
* `EventCallback` and `EventCallback<T>` types

## Configuring the JS component generation build task
The tasks that generate the React components can be configured in `JSComponentGeneration.Build/build/netstandard2.0/JSComponentGeneration.Build.targets` (via `GenerateReactComponents`). The main property of interest is `JavaScriptComponentOutputDirectory`, which lets you specify the directory where the JS components should be generated.

If you would like to change _how_ the components are generated, you can modify the tasks themselves, located in `JSComponentGeneration.Build/React/GenerateReactComponents`. You may want to do this if, for example, you have a React project built with TypeScript (this sample generates React components in JavaScript).
