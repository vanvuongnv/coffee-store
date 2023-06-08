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
- Setup local database
- In appsettings.json of CoffeShop.WebUI.Server Project, change the database connection to your server
- Migration database: 
```
dotnet ef database update
```
- Run project
```
cd /CoffeShop.WebUI/Server
dotnet watch
```
- Open your browser, now you can access the websites via https://localhost:5070/

## You might also want to explore:
- https://localhost:5070/swagger for all the REST API document of the service.
- http://localhost:5070/categories list all categories
- http://localhost:5070/categories/create-category create category
- http://localhost:5070/categories/edit-category/{id} edit category