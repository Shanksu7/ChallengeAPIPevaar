# API Challenge Products

This is an ASP **[NET 5](https://devblogs.microsoft.com/dotnet/announcing-net-5-0/)** REST Api version created for Pevaar challenge

# .NET 5 Requirements

- Visual studio 2019 version 16.8.x _(update from VS installer)_
- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

**Note**: in case you work in projects with **.NET Core 2.2 SDK** you will get some errors while building because this SDK version is not longer supported, [Solution here](https://developercommunity.visualstudio.com/content/problem/1251808/build-is-failing-for-microsoftnetsdkrazor-project.html?inRegister=true) 
# You can try it online!
Start by the [Swagger Documentation](http://juan-api-products.azurewebsites.net/swagger/index.html) 
# Or Install it locally!

  - Clone the repo
  - In SQL Express you can execute the [SQL Query](https://github.com/Shanks97/ChallengeAPIPevaar/blob/master/ChallengeDataObjects/ChallengeQuery.sql) in order the generate tables and all the initial data
  - Restore Nuget Packages, Clean and Build the solution
  - Import Postman Local requests collection with the url: https://www.getpostman.com/collections/4a5edb360936251a6e51

In the root directory of the project
Run:
```sh
$ dotnet run
```
