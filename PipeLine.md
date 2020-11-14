********************** GET DATA ********************

=> dotnet new webApi -n <projectName>
=> install EntityFrameworkCore
=> install EntityFrameworkCore.Design
=> install EntityFrameworkCore.SQL
=> install dotnet tool ef

+) Model ~ Database
    - Create Class as Database

+) Data ~ DbContext
    - Create Interface IRepository
    - Create DataContext : DbContext
    - Create DataRepo(DataContext) : IRepository

+) Controllers
    - Constructor with IRepository
    - REST APIs

=> Configuration Service:
    - Add DbContext
    - Dependency Injection (IRepository)

=> Add ConnectionStrings to SQL Database

=> dotnet ef migrations add <migrationName>
=> dotnet ef database update

----->dotnet run
-----------------> dotnet build






********************** DTO (Data Transfer Object) ********************
/* Map SQL Database to ViewData to hidden some private props before response to client */
***********************************************************************

==> install AutoMapper.Extensions.Microsoft.DependencyInjection

+) Dto ~ ViewDatabase  (Change or hidden the private props)
    - Create DtoClass as ViewDatabase

+) Profile (AutoMapper)
    - Create DataProfile : Profile
    - Map<Database, ViewDatabase>

=> Configuration Service:
    - Add AutoMapper

==> Change controller.cs with IMapper
==> Change REST APIs with mapper to ViewData







**************** CREATE PATCH DELETE ****************
* Map  ViewData to SQL Database before save to SQL */
***********************************************************************

+) Dto ~ CreateDatabase
    - Create DtoClass as CreateDatabase

+) Profile (AutoMapper)
    - Change DataProfile : Profile
    - Map<CreateDatabase, Database>

==> Change controller.cs with IMapper
==> Change REST APIs with mapper to SQLData





[REFERENCES: .NET Core 3.1 MVC REST API - Full Course]