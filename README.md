# BookInfo ASP.NET Core MVC Web App
This web app was written to demonstrate key concepts in development of ASP.NET Core MVC web apps. The current version targets .NET Core 2.2.
Each of the following branches represents a development step:

1. StartCode: Copied from [a .NET Core 1.1 project](https://github.com/LCC-CIT/CS296N-BookInfo-Core), updated for VS 2017. Already had basic models, controlelrs, views.
1. AddEF: Added Repositories, Entity Framework, BookInfo2 database, SeedData, and unit tests.
1. FKAuthorID: Added AuthorID to the Book model as a foreign key
2. AddBook: Added an input form for adding books
3. AddAuthor: Added an input form for adding authors
5. Edit+Delete: Can now edit and delete authors and books
7. AddBootstrap: Bower configured for bootstrap and bootstrap styling added to app
8. AddIdentity: Added Administrative features for user account management with Identity
9. AddLogin: Added Login and logout
0. UserRoles: Added user role management and authorization
1. Claims: Added claims based authorization
2. SelfContainedDeployment: Added a publish profile for deployment
3. JMeter: Added a JMeter script for load testing
4. Docker: Added a Dockerfile for running in a Docker container

----

This demo was written by [Brian Bird](https://profbird.online) for [CS296N, Web Development 2: ASP.NET](http://lcc-cit.github.io/CS296N-CourseMaterials/), in the [Computer Information Technology Department](https://www.lanecc.edu/cit) at Lane Community College.
