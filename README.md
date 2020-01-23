# Data modeling

[![Build Status](https://dev.azure.com/SecureDevTeam/SecureDoors/_apis/build/status/securedevteam.Security-Door-Modeling?branchName=master)](https://dev.azure.com/SecureDevTeam/SecureDoors/_build/latest?definitionId=2&branchName=master)

The developed set of applications is necessary for data modeling for the Console App of the SecurityDoors.DoorController application. The main idea is to generate and then send the received data from a file or via the WebAPI of the SecurityDoors.App web application. The main interfaces in the developed complex 3: WPF, WinForms and ConsoleApp.

## Application features
1. Windows Forms (WinFoms) application;
2. Windows Presentation Foundation (WPF) application;
3. Console App on Framework 4.7 application;
4. Configuring connection to the server and web application;
5. Possibility of test connection and data verification;
6. Saving and returning to the standard connection data;
7. Loading data from a file;
8. Ability to receive data from the server via WebAPI;
9. Update received data from the server;
10. Display of received data from the server;
11. Modeling and sending selected data to the server;
12. Multifunctional log for all types of applications;

## Built With
- [N-Layer architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures);
- [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/) (Language-Integrated Query) - uniform query syntax in C#;
- Manual and [xUnit](https://xunit.net/) testing;
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - data access technology;
- [Windows Forms (WinForms)](https://docs.microsoft.com/en-us/dotnet/framework/winforms/);
- [Windows Presentation Foundation (WPF)](https://docs.microsoft.com/en-us/dotnet/framework/wpf/);
- Using data from [Doors WebAPI app](https://github.com/securedevteam/Security-Doors);
- [Git](https://git-scm.com/) - version control system;
- [Trello](https://trello.com/en) - a web-based Kanban-style list-making application;
- [Azure Pipelines](https://azure.microsoft.com/en-us/services/devops/) - continuous integration;

## Authors
- [Mikhail M.](https://mikhailmasny.github.io/) - Architect & .NET Developer;
- [Alexandr G.](https://s207883.github.io/) - Full-stack .NET Developer;

## License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/securedevteam/Security-Door-Modeling/blob/master/LICENSE) file for details.
