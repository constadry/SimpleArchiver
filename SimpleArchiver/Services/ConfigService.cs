using Newtonsoft.Json;
using SimpleArchiver.Models;

namespace SimpleArchiver.Services;

public class ConfigService
{
    private readonly string _configPath = "./config.json";
    public ConfigService()
    {
        Config = GetConfig();
    }

    public Config Config { get; }

    private Config GetConfig()
    {
        var jsonConfig = File.ReadAllText(_configPath);
        var configModel = JsonConvert.DeserializeObject<Config>(jsonConfig);

        return configModel;
    }
}