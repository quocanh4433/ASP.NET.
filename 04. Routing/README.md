# ROUTING

### What is Routing?

Routing is a process of matching incoming HTTP requests by checking the HTTP method and url; and then invoking corresponding endpoint

### How Routing works in ASP.NET Core?

In asp.net core it is accomplished with two individual methods that is UseRouting() and UseEndpoints()

### When will you prefer attribute routing over conventional routing?

### What are the important route constraints?

To restrict the type of values right

### What is the purpose of the wwwroot folder?

To place all the static files such as images and javascript files in the web root folder

### How do you change the path of wwwroot folder?

we have to configure it in the web application builder

```tsx
var builder = WebApplication.CreateBuilder(new WebApplicationOptions ()
{
    WebRootPath = "myroot" // Default is wwwroot
});
```
