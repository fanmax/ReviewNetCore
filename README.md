# ReviewNetCore
Review of .Net Core

#### Tasks
- [x] EntityFrameworkCore Scaffold using MySql
- [ ] EntityFrameworkCore CodeFirst using MySql


##### Scaffold (ReviewNetCore.ConsoleApplicationEFCoreScaffold)
List of commands executed
```
dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=???;database=libraryscaffold" Pomelo.EntityFrameworkCore.Mysql -o Entities -f -c LibraryDbContext
```
