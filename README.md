# ReviewNetCore
Review of .Net Core

#### Tasks
- [x] EntityFrameworkCore Scaffold using MySql
- [x] EntityFrameworkCore CodeFirst using MySql
- [ ] Project Asp.Net Core using Razor and EntityFrameworkCore and MySql


##### Scaffold (ReviewNetCore.ConsoleApplicationEFCoreScaffold)
List of commands executed
```
dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=???;database=libraryscaffold" Pomelo.EntityFrameworkCore.Mysql -o Entities -f -c LibraryDbContext
```

##### CodeFirst (ReviewNetCore.ConsoleApplicationEFCoreCodeFirst)
List of commands executed
```
dotnet ef migrations add Initial
dotnet ef database update
```
