# 🔒 Securely Managing API Keys (User Secrets Manager) in C#

## Overview

This repository contains the demonstration code for a **.NET Web API** project focused on using the **User Secrets Manager**.

The main goal of this tool is to store sensitive configuration data, such as API keys (`ApiKey`) and access tokens, **during the development phase**. This ensures that this sensitive information is never accidentally **committed** to source control (Git/GitHub), preventing security leaks.

The project simulates an API that requires a secret key to communicate with an external logging service (`ExternalLogger`).

---

## Project Structure

The `SecretsDemo` project demonstrates best practices in .NET for handling configuration:

| File/Folder | Purpose |
| :--- | :--- |
| `appsettings.json` | Defines the base configuration structure (`BaseUrl` and `MinimumLevel`), without including the secret itself. |
| `Configuration/` | Contains the `ExternalLoggerOptions.cs` class, which maps the configuration section to a typed C# class, making access easier. |
| `Services/` | Contains the `LoggerService.cs` class, the service that consumes the configuration (`IOptions<T>`) and includes the crucial validation logic to check for the secret's presence. |
| `Program.cs` | Responsible for setting up the **binding** of the configuration section with the `ExternalLoggerOptions` class and registering the `LoggerService` in the **Dependency Injection (DI)** container. |

---

## How to Set Up and Test

### Prerequisites

Ensure you have the **.NET SDK** installed on your machine.

### Quick Steps (CLI)

1.  **Clone the Repository** and navigate to the project directory.
2.  **Enable User Secrets:**
    ```bash
    dotnet user-secrets init
    ```
3.  **Add the Secret Key:**
    ```bash
    dotnet user-secrets set "ExternalLogger:ApiKey" "your-development-secret-key"
    ```
4.  **Run the Project:**
    ```bash
    dotnet run
    ```
5.  Access the `/log` endpoint (e.g., `https://localhost:7000/log`) to see the service in action.

---

## 📚 Full Tutorial

For a detailed explanation of the setup, creating `Options` classes, using Dependency Injection, and managing all the CLI commands (`set`, `list`, `remove`, `clear`), check out the complete article:

[**Read the Tutorial: User Secrets: The Right Way to Protect API Keys in .NET**](https://dev.to/joaooliveiratech/user-secrets-the-right-way-to-protect-api-keys-in-net-93a)

---

## ⚠️ Important Note on Production

Remember: the **User Secrets Manager** is strictly for the **development** environment. In production, you must use a dedicated **Secret Store Service**, such as **Azure Key Vault** or **AWS Secrets Manager**.
