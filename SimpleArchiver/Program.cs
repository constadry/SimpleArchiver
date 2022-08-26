// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using SimpleArchiver.Models;

var config = GetConfig();
var sourceFiles = Directory.GetFiles(config.SourceFolder);
foreach (var sourceFile in sourceFiles)
{
    var targetFileName = sourceFile.Replace(config.SourceFolder, config.TargetFolder);
    File.Copy(sourceFile, targetFileName);
}

Config GetConfig()
{
    var jsonConfig = File.ReadAllText("config.json");
    var configModel = JsonConvert.DeserializeObject<Config>(jsonConfig);

    return configModel;
}