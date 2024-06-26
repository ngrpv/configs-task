using Configurations.Parsers;

namespace Configurations.Sources;

public abstract class ConfigurationSource : IConfigurationSource
{
    private static readonly IConfigurationParser[] Parsers =
    {
        new CsvConfigurationParser(),
        new XmlConfigurationParser()
    };

    private readonly ConfigurationFormat configurationFormat;

    protected ConfigurationSource(ConfigurationFormat configurationFormat)
    {
        this.configurationFormat = configurationFormat;
    }

    public Configuration Get()
    {
        var content = Read();
        return Parsers.Single(x => x.Accept(configurationFormat)).Parse(content);
    }

    protected abstract string Read();
}