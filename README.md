# colegium-of-help
DnD assistant application made as a project for university.

# Configuration
## Database
First, you have to build the database for the app. Use `schema.sql` file to create the database.

In `Collegium of Help` project directory, add `connections.config` file. The file contents should be:
```
<connectionStrings>
	<add name="CollegiumOfHelpConnection"
	 providerName="MySql.EntityFrameworkCore "
	 connectionString="Server=<server address>;Port=<port>;Database=colegiumofhelpdb;Uid=<user id>;Pwd=<password>;" />
</connectionStrings>
```

Replace <server address> with your database server address, e.g. 127.0.0.1.

Replace <port> with the port your database is available on.

Replace <uid> and <password> with your database credentials.