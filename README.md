# CollegeManagement

CollegeManagement in dot net core 3.1 MVC project that helps add, edit or delete students, teachers, courses and departments.

## Installation

Clone the project in your hard-drive.

## Database Setup

Change the DefaultConnection server in appsettings.json file
```c#
Server=YOUR_DB_SERVER;
```
## Adding Migration
Open the "Package Manager Console" from Tools->NuGet Package Manager and run the following code.  
```c#
add-migration "YOUR_MIGRATION_NAME"
update-database
```

## Running Project
From your Visual Studio open the project solution then press CTRL+F5 


## License
