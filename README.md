# enzotlucas.DevKit
The library that helps you not to repeat code or worry about standard things.

## Give a star 🌟
If you like and support the project, give it a [star](https://github.com/enzotlucas/enzotlucas-dotnet-devkit-lib)!

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
    - Error handler middleware 
        - Description
        - Individual use
    - Logging middleware 
        - Description
        - Individual use
    - Correlation middleware 
        - Description
        - Individual use

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
Bellow you can read everything you need to know about the library to use it, to use the library at full potential, is important to read about the **Mandatory steps**.

--------------------------

## **Api versioning**
Custom API versioning configuration to match with the folder organization of the system.
### **Mandatory step**
To use this feature of the library at full potential, you have to mark you controller with this attributes:

#### **With route version defined:**
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

#### **Without route version defined**

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
API documentation (Swagger) custom generator feature.
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
    var query = new GetRestaurantsQuery(page, rows, Request.GetCorrelationId());

    var response = await _mediator.Send(query, cancellationToken);

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

public static IApplicationBuilder ConfigureApp(this IApplicationBuilder app)
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

--------------------------

## **Middlewares**
Custom middlewares that are common on most applications.
### **Error handler middleware**
Middleware responsable for handling application exceptions.
#### **Description**
Every error response using this middleware is a *ErrorResponseViewModel* object, as shows bellow:
```json
// ErrorResponseViewModel
{
  "message": "string",
  "errors": {
    "additionalProp1": [
      "string"
    ],
    "additionalProp2": [
      "string"
    ],
    "additionalProp3": [
      "string"
    ]
  },
  "correlationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

The exceptions returns differents HTTP status code:

- If the exception is a *BusinessException*, the status code will be 400.
- If the exception is a *NotFoundException*, the status code will be 404.
- If the exception is a *InfrastructureException* or a *Exception*, the status code will be 500.

#### **Individual use**
To use only this feature, you need to use this method:
```csharp
public static IApplicationBuilder ConfigureApp(this IApplicationBuilder app)
{
    app.UseMiddleware<DevKitErrorHandlerMiddleware>();

    //Some code...
}
```
### **Logging middleware**
Middleware responsable for application exceptions.
#### **Description**
This middleware is responsable for tracking every API request and saving logs of it, if is authorized or anonymous. It saves the route, body and user.

#### **Individual use**
To use only this feature, you need to use this method:
```csharp
public static IApplicationBuilder ConfigureApp(this IApplicationBuilder app)
{
    app.UseMiddleware<DevKitLoggerMiddleware>();

    //Some code...
}
```

### **Correlation id middleware**
Middleware responsable for application exceptions.
#### **Description**
The correlation id is important for microservices and error tracking. The id is captured by the HTTP header named *x-correlation-id*, this middleware captures it and, if is not filled, it creates a new correlation id.

The middleware can be used at the API controller using the RequestExtensions, like showns bellow:
```csharp
[HttpGet]
public Task<IActionResult> Get(CancellationToken cancellationToken)
{
    var correlationId = Request.GetCorrelationId();

    //Some code...
}
```
#### **Individual use**
To use only this feature, you need to use this method:
```csharp
public static IApplicationBuilder ConfigureApp(this IApplicationBuilder app)
{
    app.UseMiddleware<DevKitCorrelationIdMiddleware>();

    //Some code...
}
```