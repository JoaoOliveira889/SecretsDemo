namespace SecretsDemo.Configuration;

public class ExternalLoggerOptions
{
    // Define a constant for the section name to avoid magic strings
    public const string ExternalLogger = "ExternalLogger";
        
    public string BaseUrl { get; init; } = string.Empty;
        
    // This is the sensitive property that will be stored in User Secrets
    public string? ApiKey { get; init; } 
        
    public string MinimumLevel { get; init; } = "Warning";
}