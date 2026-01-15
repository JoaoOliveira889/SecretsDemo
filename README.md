# User Secrets: The Right Way to Protect API Keys in .NET

> **Article:** [User Secrets: The Right Way to Protect API Keys in .NET](https://dev.to/joaooliveiratech/user-secrets-the-right-way-to-protect-api-keys-in-net-93a)

This repository demonstrates the implementation of the User Secrets Manager in a .NET Web API. The project focuses on protecting sensitive configuration data—such as API keys and access tokens—during the development phase to ensure they are never committed to source control.

---

## What This Project Covers

* Safe Secret Storage: Moving sensitive data out of `appsettings.json` and into the machine's local storage.
* IOptions Pattern: Mapping configuration sections to strongly-typed C# classes for easier access and validation.
* Dependency Injection (DI): Registering configuration and services within the .NET container.
* Validation Logic: Ensuring the application gracefully handles missing secrets before attempting to use external services.

---

## Concepts Overview

### Why User Secrets?

In .NET, `appsettings.json` is typically tracked by Git. If you place an API key there, it becomes visible to anyone with access to the repository. The User Secrets Manager stores data in a separate JSON file located in your user profile folder, outside of the project tree.

### The IOptions Pattern

Instead of reading strings directly from the configuration, we use the `IOptions<T>` interface. This allows us to treat our settings as a standard C# object, providing:

Type Safety: No more "magic strings."

Validation: You can check if a secret is null or empty at startup.

---

## Tech Stack

* Framework: .NET 9
* CLI Tools: .NET Secret Manager

### Environment Setup

Ensure you have the **.NET SDK** installed on your machine.

### Setup & Configuration

1. Clone the Repository and navigate to the project directory.
2. Enable User Secrets:

```bash
dotnet user-secrets init
```

3. Set your Development Key:

```bash
dotnet user-secrets set "ExternalLogger:ApiKey" "your-secret-key-here"
```

4. Run the Project

```bash
dotnet run
```

Access the /log endpoint via your browser or Swagger to verify the service is correctly retrieving the secret.

---

## Important Note on Production

The User Secrets Manager is strictly for development. It does not encrypt the secrets; it simply moves them out of the code. For production environments, you must use a secure vault service such as:

* Azure Key Vault
* AWS Secrets Manager
* HashiCorp Vault

---

## About

This repository is part of my technical writing and learning notes.  
If you found it useful, consider starring the repo and sharing feedback.

* Author: Joao Oliveira
* Blog: <https://joaooliveira.net>
* Topics: .NET, Redis, Distributed Systems, Caching Patterns

## Contributing

Issues and pull requests are welcome.  
If you plan a larger change, please open an issue first so we can align on scope.

## License

Licensed under the **MIT License**. See the `LICENSE` file for details.
