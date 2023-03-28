using Microsoft.Extensions.Configuration;

namespace ImpostorHelp;

public static class ConfigurationHelper
{
    public static string GetStringFromConfigurationFile(string key)
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
        IConfiguration config = builder.Build();

        return config[key] ?? throw new Exception();
    }
}