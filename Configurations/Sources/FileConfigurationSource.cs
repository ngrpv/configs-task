namespace Configurations.Sources;

public class FileConfigurationSource : ConfigurationSource
{
    private readonly string filePath;

    public FileConfigurationSource(string filePath, ConfigurationFormat configurationFormat) : base(configurationFormat)
    {
        this.filePath = filePath;
    }

    protected override string Read()
    {
        return File.ReadAllText(filePath);
    }
}