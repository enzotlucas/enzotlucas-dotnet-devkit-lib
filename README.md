# enzotlucas.DevKit

The library that helps you not to repeat code or worry about standard things

## Topics
- [First steps](#first-steps)
- [Api versioning](#api-versioning)
- [Api documentation](#api-documentation)
    - Mandatory step
    - Description
    - Single use
- [Request validation](#request-validation)
- [Logging](#logging)
- [Middlewares](#middlewares)

----------------------------------------------------

## First steps

To begin using the full library, you have to use thi command:
```bash
dotnet add package enzotlucas.DevKit
```

After that, to apply the library into your project, you have to add this methods:
```csharp
//This adds api versioning, api documentation, request validation (MediatR) and custom logging (optional)
public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
{
    builder.Services.AddDevKit(); // This version don't have custom log managment

    builder.Services.AddDevKit(LoggerProvider.Console); // This version have custom log managment

    //Some code...
}

//This adds all midlewares and apply the api documentation
public static WebApplication ConfigureApp(this WebApplication app)
{
    app.UseDevKit();

    //Some code...
}
```
Bellow you can read everything you need to know to use the library, the only mandatory thing you have to use in your project is the [Api documentation mandatory step](#mandatory-step)

--------------------------

## Api versioning
```bash
# under development
```

--------------------------

## Api documentation

### Mandatory step
Before start, you have to add this line to your API project csproj configuration, to use this feature:
```xml
<!-- API.csproj -->
<PropertyGroup>
	<GenerateDocumentationFile>True</GenerateDocumentationFile>
</PropertyGroup>
```

### Description

This feature makes your comments in the controller shows on the swagger, example:
```csharp
/// <summary>
/// get all restaurants with no filters 
/// </summary>
/// <param name="page">page number</param>
/// <param name="rows">number of restaurants per page</param>
/// <param name="cancellationToken"></param>
/// <returns>list of restaurants</returns>
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RestaurantViewModel[]))]
[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponseViewModel))]
public async Task<IActionResult> Get(int page, int rows, CancellationToken cancellationToken)
{
    var response = await _mediator.Send(new GetRestaurantsQuery(page, rows, Request.GetCorrelationId()), cancellationToken);

    return Ok(response);
}
```
The messages are displayed like this:
<img src="https://github.com/enzotlucas/enzotlucas-dotnet-devkit-lib/blob/main/imgs/swagger.png?raw=true" alt="swagger">    

### Single use
To use only this feature, you can use the method:
```csharp
public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
{
    builder.Services.AddDevKitSwaggerConfiguration();

    //Some code...
}

public static WebApplication ConfigureApp(this WebApplication app)
{
    app.UseDevKitSwaggerConfiguration();

    //Some code...
}
```

--------------------------

## Request validation
```bash
# under development
```

--------------------------

## Logging
```bash
# under development
```
