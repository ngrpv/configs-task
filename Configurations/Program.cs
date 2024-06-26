// See https://aka.ms/new-console-template for more information

using Configurations;
using Configurations.Sources;

var fileSources = new IConfigurationSource[]
{
    new FileConfigurationSource(Path.Combine("ConfigurationExamples", "config1.xml"), ConfigurationFormat.Xml),
    new FileConfigurationSource(Path.Combine("ConfigurationExamples", "config2.csv"), ConfigurationFormat.Csv)
};

var allConfigurations = new List<Configuration>();
foreach (var source in fileSources)
{
    var config = source.Get();
    allConfigurations.Add(config);
    PrintAllConfigurations();
}

void PrintAllConfigurations()
{
    foreach (var config in allConfigurations)
    {
        var message = $"Name: {config.Name}" + Environment.NewLine +
                      $"Description: {config.Description}";
        Console.WriteLine(message);
    }
}