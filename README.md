This is a test project  for job interview application.
Steps to start the prjects:

1) Make sure SQL server is installed and running on localhost, add a new DB called "Support". 
If you have a password and username on your localhost DB you need to update this "DatabaseUrl" connection string at all appsettings.json files.
(In a real world example when hostring on a cloud environment variable should be used insread.)

2) Open PowerShell at live_chat_test\SessionCoordinatorService folder, and run "dotnet ef database update", it should create the basic DB structure.

3) Open Docker Desktop, wait untill Docker Daemon start up, open the root, and run "docker-compose up -d".
This will start RabbitMQ and MongoDB container instances.

4) Open Support.System.sln, open properties of that solution, select "Multiple startup projects", 
select Start Action for Support.API, Support.Monitor, Support.SessionCoordinatorService, Support.Client projects.

5) Select <Multiple Startup Projects> and click start. The main Client app browser will open. Click F12, to see the poll requets.



The poll requests help to keep the info connection between Support.Client and Back-end Support.API. 
That connection is stored at MongoDB, and monitored via Support.ConnectionMonitor using cronjob 
(this is NOT THE BEST SOLUTION, for this kind of poll messaging it is better to use something like DynamoDB with ttl, and with Lambda triggers
or any other DB which has TTL functionality and ability to raise an event when something got deleted using Debezium,
But in my opinion, the SignalR would've done the best, but I chose this method because of the lack of my time).

The message queues are stored in order at SQL server and are managed by Support.SessionCoordinatorService. 
The Session queue is stored at SessionQueue table. The sessions which are Pop-ed from that queue are being appended to the Agent, 
and being stored at ActiveAgentSessions. Based on ActiveAgentSessions info API can know which customer's message should be sent to which agent, and vice versa.
Chat between Agent and Customer is stored at SessionChats table.

RabbitMQ broker is used to notify about the occurred events, such as AppendSessionsToAgentEvent, SessionCancelledEvent.
Based on that events the event handlers are being triggered. The main logic is stored at SessionManagementService.

There are also 2 more cron jobs, ResetOverflowJob, which makes Overflow team inactive,
at the end of the day, in case if they have been activated.
MonitorSessionsJob, is run every 10 seconds,

because sometimes there are some sessions which are still being kept in queue irregardless of lost connection, YES THIS IS A BUG!
