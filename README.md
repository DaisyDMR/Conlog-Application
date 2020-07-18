# Introduction

Welcome to Simple Todo, a simple web application used to create a manage todo's lists.

This solution contains two folders in the root directory:

- angular
- aspnet-core

## Angular Application

#### Requirements

The Angular application needs the following tools installed:

-   [nodejs](https://nodejs.org/en/download/) 6.9+ with npm 3.10+
-   Typescript 2.0+


#### Restore Packages

Open a command prompt, navigate to the **angular** folder which contains
the \*.sln file and run the following command to **restore the npm packages**:

    npm install

Note that the npm install may show some warning messages. This is not
related to our solution and generally it's not a problem. The solution
can also configured to work with [**yarn**](https://yarnpkg.com/) and we
recommend you use it if it is available on your computer.

#### Run The Application

In your opened command prompt, run the following command:

    npm start

Once the application has compiled, you can go to <http://localhost:4200> in
your browser. Be sure that the Web.Host application is running at the same
time. When you open the application, you will see the **login page**:

## ASP.NET Core Application

- Open your solution in Visual Studio 2017 v15.3.5+ (Or above) and build the solution.
- Select the 'Web.Host' project as the startup project.
- Check the connection string in the appsettings.json file of the Web.Host project, change it if you need to.
- Open the Package Manager Console and run an Update-Database command to create your database (ensure that the Default project is selected as .EntityFrameworkCore in the Package Manager Console window).
- Run the Migrator Project to seed database with data.
- Run the application. It will show swagger-ui if it is successful:


# Dev Items to Complete.

Currently we need your help in fixing the solution!! #pleasehelp

- Fix the "Open Tasks" Card on the home page. It should show the count of Open tasks.
- Change the "Open Tasks" Colour from Yellow/Gold to Blue
- Implement the "Create" Button to save a new Todo to the database.
- Add a button to mark a Todo Task as Completed (Info: Call and implement the UpdateTask in TaskAppService)
- Bonus Points: Update Unit Tests


Please fork the repo "https://github.com/Conlog-hub/Simple.Todo.git" to your Github account

Implemet the above changes and commit it to your Github Repo, and send us the link to your changes.

# Additional Reading Documentation

* [ASP.NET Core & Angular  version.](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Angular)

# License

[MIT](LICENSE).
