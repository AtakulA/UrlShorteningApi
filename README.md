# UrlShorteningApp
Web project to shorten urls;

Before running the project please select both "UrlShortening.WebApi" and "UrlShortening.WebApp" as StartUp Projects.

Main job is in the "UrlShortening.WebApi" project but to make it simple to use I also added "UrlShortening.WebApp" project.

I used database (MSSQL - Auto migration) for this project so before running the project please change the connection string in "UrlShortening.WebApi" > "appsettings.json".
Project will create needed db and table(s)
(Note : User in the connection string must have the authorization to create db and tables)

