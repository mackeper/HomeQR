# HomeQR
Link your stuff to their manual and receipt

# EF Core Cheat Sheet
Command | Description
--- | ---
`dotnet ef migrations add InitialCreate` | Create a migration
`dotnet ef database update` | Apply migrations
`dotnet ef migrations remove` | Remove last migration
`dotnet ef migrations script` | Generate SQL script from migrations
`dotnet ef dbcontext info` | Show information about migrations
`dotnet ef dbcontext list` | List all contexts
`dotnet ef dbcontext scaffold` | Scaffold a DbContext and entity types for a database
`dotnet tool update --global dotnet-ef` | Update EF tool
