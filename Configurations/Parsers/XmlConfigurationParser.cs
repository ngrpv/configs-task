using System.Xml.Linq;

namespace Configurations.Parsers;

public class XmlConfigurationParser : IConfigurationParser
{
    private const string ConfigRoot = "config";
    private const string NameNode = "name";
    private const string DescriptionNode = "description";

    public bool Accept(ConfigurationFormat configurationFormat)
    {
        return configurationFormat == ConfigurationFormat.Xml;
    }

    public Configuration Parse(string content)
    {
        var xDocument = XDocument.Parse(content);

        var configElement = GetElement(xDocument, ConfigRoot);
        var name = GetElement(configElement, NameNode);
        var description = GetElement(configElement, DescriptionNode);

        return new Configuration
        {
            Name = name.Value,
            Description = description.Value
        };
    }

    private XElement GetElement(XContainer xContainer, string elementName)
    {
        var element = xContainer.Element(elementName);

        if (element is null)
            throw new InvalidOperationException(
                $"Expected {elementName} element in xml. Actual content is: {xContainer}");

        return element;
    }
}