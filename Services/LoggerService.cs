using Microsoft.Extensions.Options;
using SecretsDemo.Configuration;

namespace SecretsDemo.Services;

public class LoggerService(IOptions<ExternalLoggerOptions> options)
{
    private readonly ExternalLoggerOptions _options = options.Value;
    
    public string LogMessage(string message)
    {
        // Crucial validation logic: is the secret present?
        if (string.IsNullOrEmpty(_options.ApiKey))
            return "ERROR: The ExternalLogger ApiKey is missing. Please configure User Secrets!";
        
        string logDetails = $"Base URL: {_options.BaseUrl} | Level: {_options.MinimumLevel}";
        
        return $"Log of '{message}' sent successfully! Config: {logDetails}";
    }
}