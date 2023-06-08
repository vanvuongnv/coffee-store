# coffee-store
We'll build a simple coffee store application using the blazor framework
## technologies
- .NET 7 Web API
- Entity Framework Core
- Database: Postgresql

## project structure
```
CoffeShop.WebUI
--Client
-----Components: Blazor Component
-----Pages: Blazor Page
-----Services: Implement bussiness logic, interact with api
--Server
-----Controllers
-----Data: Setup Entity, Entity Configuration, Database Context
-----Infrastructure: Implement bussiness logic
--Share
-----Commands: Define api body request
-----Common: Define model class, ...
-----Dtos: data transfer object are objects that carry data between Server and Client
```
## how to run
- setup local database
- In appsettings.json of CoffeShop.WebUI.Server Project, change the database connection to your server
- migration database: 
```
dotnet ef database update
```
- run project
- Open your browser, now you can access the websites via https://localhost:7248/

## You might also want to explore:
- https://localhost:7248/swagger for all the REST API document of the service.