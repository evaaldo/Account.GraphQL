# Account GraphQL

Account GraphQL is a .NET 10 GraphQL API for a fictional account service. It demonstrates the N+1 query problem and how to batch related PostgreSQL lookups with Hot Chocolate and GreenDonut DataLoaders.

The API exposes accounts, people, and account statuses. When a GraphQL request asks for an account's person or status, DataLoaders batch those related IDs so the API can fetch them together rather than issuing one database query per account.

## Requirements

- Docker with Docker Compose

Running the application with Docker Compose does not require a local .NET SDK.

## Start the application

From the repository root, run:

```sh
docker compose up --build
```

This starts PostgreSQL and the API. The database schema and sample records are initialized from `database/init.sql` when PostgreSQL creates its data directory for the first time.

The GraphQL endpoint is available at:

```text
http://localhost:8080/graphql
```

For local development without Docker, install the .NET 10 SDK, start PostgreSQL separately, configure the `ConnectionStrings:AccountDatabase` setting for that database, and run:

```sh
dotnet run --project src/Account.GraphQL.Api
```

## Example query

Fetch accounts with their related person and status:

```graphql
query {
  accounts {
    id
    person {
      id
      name
      email
      birthdate
    }
    status {
      id
      status
    }
    createdAt
    updatedAt
  }
}
```

`AccountResolvers` loads the related records by their foreign-key IDs. The person and status DataLoaders collect those IDs and use batch repository queries to avoid the N+1 pattern.

## Stop the application

Stop the containers with:

```sh
docker compose down
```

PostgreSQL data is stored in a named Docker volume and is retained when the containers stop. The initialization script runs when the database volume is first created.

## Author

Evaldo Rodrigues | evaaldormj@gmail.com | https://www.linkedin.com/in/evaldorodrigues
