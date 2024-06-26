namespace Configurations.Parsers;

public class CsvConfigurationParser : IConfigurationParser
{
    public bool Accept(ConfigurationFormat configurationFormat)
    {
        return configurationFormat == ConfigurationFormat.Csv;
    }

    // Для более сложны данных следовало бы использовать библиотеку для парсинга,
    // но тут это излишне
    public Configuration Parse(string content)
    {
        var data = content.Split(';');
        return new Configuration
        {
            Name = data[0].Trim(),
            Description = data[1].Trim()
        };
    }
}