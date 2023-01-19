# enzotlucas.DevKit

The library that helps you not to repeat code or worry about standard things

## Topics
- [First steps](#first-steps)
- [Api versioning](#api-versioning)
    - Mandatory step
        - With route version defined 
        - Without route version defined 
    - Description
    - Individual use
- [Api documentation](#api-documentation)
    - Mandatory step
    - Description
    - Individual use
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
Bellow you can read everything you need to know about the library to use it, to use the library at full potential, is important to read about the **Mandatory steps**

--------------------------

## **Api versioning**

### **Mandatory step**
To use this feature of the library at full potential, you have to mark you controller with this attributes:

- With route version defined
```csharp
[Route("api/v{version:apiVersion}/restaurants")]
public class RestaurantsController : ControllerBase
{
    //Some code...
}
```
Results:

<img src="https://github.com/enzotlucas/enzotlucas-dotnet-devkit-lib/blob/main/imgs/api-with-version.png?raw=true" alt="api-with-version">    

The version controll is made using this dropdown:

<img src="https://github.com/enzotlucas/enzotlucas-dotnet-devkit-lib/blob/main/imgs/version-control.png?raw=true" alt="api-with-version">    

- Without route version defined

```csharp
[Route("api/restaurants")] 
public class RestaurantsController : ControllerBase
{
    //Some code...
}
```
Results:

<img src="https://github.com/enzotlucas/enzotlucas-dotnet-devkit-lib/blob/main/imgs/api-without-version.png?raw=true" alt="api-without-version">    

### **Description** 
With this feature, your api versioning can be visible on the organization of your code, to use it at full potential, you need only these two attributes:

```csharp
[ApiVersion("1.0")] // This attribute defines the api version, the default of the library is one
[Route("api/v{version:apiVersion}/routes")]   // this type of route with the "v{version:apiVersion}" parameter makes the version
                                              // part of the route, so you don't need to pass as a parameter

```

Your code organization can use folders to match the api versioning, as examples shows:
```
Features +
         |_ 
         | V1  +
         |     |_
         |       Controllers +
         |                   |_ 
         |                     RoutesController.cs
         |
         |_
           V2  +
               |_
                 Controllers +
                             |_ 
                               RoutesController.cs
```

```csharp
//Features/V1/Controllers/RoutesController.cs
[ApiVersion("1.0")] 
[Route("api/v{version:apiVersion}/routes")]   
[ApiController]
[Produces("application/json")]
public class RoutesController : BaseController
{
    //Some code...
}
```

```csharp
//Features/V2/Controllers/RoutesController.cs
[ApiVersion("2.0")] 
[Route("api/v{version:apiVersion}/routes")]   
[ApiController]
[Produces("application/json")]
public class RoutesController : BaseController
{
    //Some code...
}
```

### **Individual use**
To use only this feature, you need to use this method:
```csharp
public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
{
    builder.Services.AddDevKitApiVersioningConfiguration();

    //Some code...
}
```

--------------------------

## **Api documentation**

### **Mandatory step**
Before start, you have to add this line to your API project csproj configuration, to use this feature:
```xml
<!-- API.csproj -->
<PropertyGroup>
	<GenerateDocumentationFile>True</GenerateDocumentationFile>
</PropertyGroup>
```

### **Description**

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

### **Individual use**
To use only this feature, you need to use these methods:
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

## **Request validation**
```bash
# under development
```

--------------------------

## **Logging**
```bash
# under development
```

## **Middlewares**
### **Error handler middleware**
```bash
# under development
```

### **Logging middleware**
```bash
# under development
```

### **Correlation id middleware**
```bash
# under development
```
