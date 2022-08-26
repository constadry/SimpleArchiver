// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using SimpleArchiver.Models;

CopyFiles();

void CopyFiles()
{
    var config = GetConfig();
    var sourceFiles = Directory.GetFiles(config.SourceFolder);
    foreach (var sourceFile in sourceFiles)
    {
        File.Copy(config.SourceFolder + sourceFile, config.TargetFolder + sourceFile);
    }
}

Config GetConfig()
{
    var jsonConfig = File.ReadAllText("./config.json");
    var configModel = JsonConvert.DeserializeObject<Config>(jsonConfig);

    return configModel;
}