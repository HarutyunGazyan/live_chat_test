This is a test project  for job interview application.
Steps to start the prjects:

1) Make sure SQL server is installed and running on localhost, add a new DB called "Support". 
If you have a password and username on your localhost DB you need to update this "DatabaseUrl" connection string at all appsettings.json files.
(In a real world example when hostring on a cloud environment variable should be used insread.)

2) Open PowerShell at live_chat_test\SessionCoordinatorService folder, and run "dotnet ef database update", it should create the basic DB structure.

3) Open Docker Desktop, wait untill Docker Daemon start up, open the root, and run "docker-compose up -d".
This will start RabbitMQ and MongoDB container instances.

4) Open Support.System.sln, open properties of that solution, select "Multiple startup projects", 
select Start Action for Support.API, Support.Monitor, Support.SessionCoordinatorService projects.