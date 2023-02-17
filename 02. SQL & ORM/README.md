Dotnet CLI commands used in the demo:

- Install ef tools (done only once as it's using global option)

dotnet tool install --global dotnet-ef

- Add migration

dotnet ef migrations add [MigrationName] --project [ProjectName]

Example: 

dotnet ef migrations add AddDonationTable --project PetShelter.DataAccessLayer

- Run migration / update database

dotnet ef database update --project [ProjectName]

- Rollback a migration

dotnet ef database update [LastGoodMigrationName] --project [ProjectName]

Example: 

dotnet ef database update InitialCreate --project PetShelter.DataAccessLayer

- Scaffold database (for db first approach)

dotnet ef dbcontext scaffold [ConnectionString] Microsoft.EntityFrameworkCore.SqlServer --project [ProjectName] --output-dir Models --context [ContextName]

Example:

dotnet ef dbcontext scaffold "Server=localhost\SQLEXPRESS;Database=PetShelter-demo;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --project PetShelter.DataAccessLayer --output-dir Models --context PetShelterContext

The commands can have other parameters. Check this link for more info: https://learn.microsoft.com/en-us/ef/core/cli/dotnet
