using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Fractions.Tests.Serialization.Xml;

internal static class Extensions {
    public static string Serialize<TModel>(this XmlSerializer xmlSerializer, TModel value) {
        var sb = new StringBuilder();
        var settings = new XmlWriterSettings {
            Indent = false,
            NewLineHandling = NewLineHandling.None
        };
        using var writer = XmlWriter.Create(sb, settings);
        xmlSerializer.Serialize(writer, value);
        writer.Flush();
        return sb.ToString();
    }

    public static TModel Deserialize<TModel>(this XmlSerializer xmlSerializer, string xml) {
        using var reader = new StringReader(xml);
        return (TModel)xmlSerializer.Deserialize(reader)!;
    }
}
