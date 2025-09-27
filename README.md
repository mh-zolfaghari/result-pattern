﻿## Result Pattern in C# / .NET

This repository demonstrates the implementation of the **Result Pattern** in C# and .NET.  
The purpose of this project is **educational**, to show how to design a clean and structured way of handling results, errors, and success responses in applications, especially in **ASP.NET Core Web APIs**.

![dotnet-version](https://img.shields.io/badge/dotnet%20version-net8.0-blue)

---

## 📌 What is the Result Pattern?
The **Result Pattern** is a common design approach to encapsulate both:
- **Successful results** (with or without data), and  
- **Failure results** (with detailed error information).

It provides a **clean, unified way** to handle outcomes in your application, improving readability, error-handling, and consistency.

---

## 📂 Project Structure
The main components in this project are:

1. **ErrorType (Enum)**  
   Defines a set of error types mapped to standard HTTP status codes.  
   Examples: `Validation`, `Unauthorized`, `Forbidden`, `NotFound`, `Conflict`, `Failure`, etc.

2. **Error (Record)**  
   A model that holds error details, including:
   - `Code` (string)  
   - `Message` (string)  
   - `Type` (ErrorType enum)  
   - `MetaData` (optional, additional information)  

   It also provides static helper methods such as:
   - `Error.Validation(...)`
   - `Error.Unauthorized(...)`
   - `Error.NotFound(...)`
   - `Error.Conflict(...)`
   - `Error.Failure(...)`
   - etc.

3. **Result / Result<T> (Record)**  
   The base class that represents the outcome of an operation.  
   - `IsSuccess` → indicates success or failure  
   - `Error` → contains error details if failed  
   - `Data` → holds success data when available  

   Static methods for creating results:
   - `Result.Success()`  
   - `Result.Success<T>(T data)`  
   - `Result.Failure(Error error)`  
   - `Result.Failure<T>(Error error)`

4. **SampleService**  
   A demo service with in-memory data (`Person` list) that demonstrates usage of the Result Pattern:
   - `GetAllPersons()`
   - `GetPersonByName(string name)`
   - `AddPerson(Person newPerson)`

5. **ProblemExtensions**  
   An extension method that maps a `Result` object to `ProblemDetails`, making it easy to return standardized error responses in **ASP.NET Core** APIs.

6. **BaseController**  
   An abstract controller that centralizes the handling of Result objects.  
   - Provides `OkResult(Result result)` and `OkResult(Result<T> result)` methods.  
   - Converts `Result` to `IActionResult` automatically.  

7. **HomeController**  
   A sample controller that demonstrates how to use the Result Pattern in API endpoints.

---

## 🚀 Example Usage

### SampleService
```csharp
var service = new SampleService();

// Success
var personsResult = service.GetAllPersons();
if (personsResult.IsSuccess)
{
    var persons = personsResult.Data;
}

// Failure
var personResult = service.GetPersonByName("Unknown");
if (personResult.IsFailure)
{
    var error = personResult.Error;
    Console.WriteLine($"{error.Code}: {error.Message}");
}
```

### HomeController (ASP.NET Core)
```csharp
[HttpGet]
[ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
public IActionResult GetSuccess()
{
    var result = Result.Success();
    return OkResult(result);
}

[HttpGet]
[ProducesResponseType(typeof(Result<Person>), StatusCodes.Status200OK)]
public IActionResult GetPerson([FromQuery] string name)
{
    return OkResult(sampleService.GetPersonByName(name));
}

[HttpGet]
[ProducesResponseType(typeof(Result<IEnumerable<Person>>), StatusCodes.Status200OK)]
public IActionResult GetPersons()
{
    return OkResult(sampleService.GetAllPersons());
}
```

---

## ✅ Benefits of Using Result Pattern
- Consistent **success and error handling** across the application  
- Cleaner **controller code** with centralized error mapping  
- Easy to extend with **custom error codes and metadata**  
- Integrates naturally with **ASP.NET Core ProblemDetails**  

---

## 📜 License
This project is licensed under the [MIT License](./LICENSE).  
See the LICENSE file for details.

---

## 🩷 Follow Me!

[![LinkedIn][linkedin-shield]][linkedin-url]  [![Telegram][telegram-shield]][telegram-url]  [![WhatsApp][whatsapp-shield]][whatsapp-url]  [![Gmail][gmail-shield]][gmail-url]  ![GitHub followers](https://img.shields.io/github/followers/mh-zolfaghari)

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?logo=linkedin&color=555
[linkedin-url]: https://www.linkedin.com/in/ronixa/

[telegram-shield]: https://img.shields.io/badge/-Telegram-black.svg?logo=telegram&color=fff
[telegram-url]: https://t.me/DanialDotNet

[whatsapp-shield]: https://img.shields.io/badge/-WhatsApp-black.svg?logo=whatsapp&color=fff
[whatsapp-url]: https://wa.me/989389043224

[gmail-shield]: https://img.shields.io/badge/-Gmail-black.svg?logo=gmail&color=fff
[gmail-url]: mailto:personal.mhz@gmail.com