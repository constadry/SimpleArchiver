// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using SimpleArchiver.Models;

var config = GetConfig();
var sourceFiles = Directory.GetFiles(config.SourceFolder);

//folder name can't contain ":" 
var targetFolderTimeStamp = config.TargetFolder + $"\\{DateTime.Now:G}".Replace(":", "_");
Directory.CreateDirectory(targetFolderTimeStamp);
foreach (var sourceFile in sourceFiles)
{
    var targetFileName = sourceFile.Replace(config.SourceFolder, targetFolderTimeStamp);
    File.Copy(sourceFile, targetFileName);
}

Config GetConfig()
{
    var jsonConfig = File.ReadAllText("config.json");
    var configModel = JsonConvert.DeserializeObject<Config>(jsonConfig);

    return configModel;
}