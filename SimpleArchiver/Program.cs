using Newtonsoft.Json;
using SimpleArchiver.Models;

var config = GetConfig();
var sourceFiles = GetFiles(config.SourceFolders);

//folder name can't contain ":"
var targetFolderTimeStamp = config.TargetFolder + $"\\{DateTime.Now:G}".Replace(":", "_");
Directory.CreateDirectory(targetFolderTimeStamp);

foreach (var sourceFile in sourceFiles)
{
    var sourceFolder = Path.GetDirectoryName(sourceFile);
    var targetFileName = sourceFile.Replace(sourceFolder, targetFolderTimeStamp);
    if (!File.Exists(targetFileName))
    {
        File.Copy(sourceFile, targetFileName);
    }
}

Config GetConfig()
{
    //this config is located in same directory with SimpleArchiver.exe
    var jsonConfig = File.ReadAllText("config.json");
    var configModel = JsonConvert.DeserializeObject<Config>(jsonConfig);

    return configModel;
}

List<string> GetFiles(List<string> paths)
{
    var resultFiles = new List<string>();
    foreach (var path in paths)
    {
        try
        {
            var currentFiles = Directory.GetFiles(path);
            resultFiles.AddRange(currentFiles);
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    return resultFiles;
}