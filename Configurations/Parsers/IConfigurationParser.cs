namespace Configurations.Parsers;

public interface IConfigurationParser
{
    bool Accept(ConfigurationFormat configurationFormat);
    Configuration Parse(string content);
}