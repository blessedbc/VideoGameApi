# VideoGameApi

A small ASP.NET Core Web API for managing a collection of video games.  
Implements basic CRUD endpoints backed by Entity Framework Core and a `VideoGameDbContext`.

Key details
- C# version: 13.0
- .NET target: .NET 9
- Project folder: `VideoGameApi`
- Primary controller: `VideoGameApi\Controllers\VideoGameController.cs`

## Features
- List all video games
- Retrieve a game by id
- Create a new game
- Update an existing game
- Delete a game
- EF Core migrations and optional seed data (see `VideoGameApi\Migrations`)

## Prerequisites
- .NET 9 SDK installed (dotnet)
- Optional: Visual Studio 2022 / 2022+ with .NET 9 support
- If you plan to apply migrations from the CLI: `dotnet-ef` tools (`dotnet tool install --global dotnet-ef`) and the EF Core design package in the project

## Getting started (CLI)
1. Clone the repository
2. Restore and build
3. 3. Apply EF Core migrations to create the database
   - If `dotnet-ef` is not installed:
     ```
     dotnet tool install --global dotnet-ef
     ```
   - Update the database
     ```
     dotnet ef database update
     ```
   Migrations live in `VideoGameApi\Migrations`. There is a seeding migration if you want sample data.

4. Run the API
5. By default the app will bind to the URLs configured in `VideoGameApi\Properties\launchSettings.json` (typically `https://localhost:5001` and `http://localhost:5000`).

## Running from Visual Studio
- Open the solution in Visual Studio.
- To build: use __Build__.
- To run/debug: use __Debug > Start Debugging__ (or press __F5__).
- The same launch profiles in `launchSettings.json` are used when launching from the IDE.

## Database & Migrations
- DbContext: `VideoGameApi\Data\VideoGameDbContext.cs`
- To add a migration:
- To apply migrations:
- 
## API Endpoints
Base route: `api/videogame` (controller route: `api/[controller]`)

- GET `api/videogame`
- Returns: 200 OK with JSON array of video games
- Example:
  ```
  curl https://localhost:5001/api/videogame
  ```

- GET `api/videogame/{id}`
- Returns: 200 OK with JSON object, or 404 Not Found if id does not exist
- Example:
  ```
  curl https://localhost:5001/api/videogame/1
  ```

- POST `api/videogame`
- Body: JSON representation of a `VideoGame`
- Returns: 201 Created with Location header pointing to the created resource
- Example:
  ```
  curl -X POST https://localhost:5001/api/videogame \
    -H "Content-Type: application/json" \
    -d '{"title":"Elden Ring","platform":"PC","developer":"FromSoftware","publisher":"Bandai Namco"}'
  ```

- PUT `api/videogame/{id}`
- Body: JSON with updated fields for the game
- Returns: 204 No Content on success, 404 Not Found if id not found
- Example:
  ```
  curl -X PUT https://localhost:5001/api/videogame/1 \
    -H "Content-Type: application/json" \
    -d '{"id":1,"title":"Elden Ring","platform":"PC","developer":"FromSoftware","publisher":"Bandai Namco"}'
  ```

- DELETE `api/videogame/{id}`
- Returns: 204 No Content on success, 404 Not Found if id not found
- Example:
  ```
  curl -X DELETE https://localhost:5001/api/videogame/1
  ```

Model shape (server-side)
- `VideoGame` properties:
- `Id` (int)
- `Title` (string?)
- `Platform` (string?)
- `Developer` (string?)
- `Publisher` (string?)

## Notes & recommendations
- The project uses EF Core and migrations for schema management. Confirm the connection string in the project's configuration before applying migrations.
- If you expose this API beyond localhost, secure it (HTTPS, authentication, authorization) and validate inputs.
- Consider adding model validation attributes and DTOs for public-facing requests.

## Testing
- You can use Postman, curl, or any REST client to exercise the endpoints.
- Add unit tests or integration tests in a separate test project to cover controller behavior and database interactions.

## Contributing
- Fork, create a feature branch, and open a PR against `master`.
- Keep changes small and focused. Run __Build__ and tests locally before opening a PR.

## License
- Add a license file to the repository (e.g., `LICENSE`) if you want to make the project open-source.

If you want, I can:
- Generate example Postman collection
- Add a simple integration test project
- Create a minimal OpenAPI/Swagger description and startup wiring for Swagger UI
