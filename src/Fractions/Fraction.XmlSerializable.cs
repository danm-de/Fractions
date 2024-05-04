#if true
using System.Globalization;
using System.Numerics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Fractions;

public partial struct Fraction : IXmlSerializable  {
    readonly XmlSchema IXmlSerializable.GetSchema() => null;

    void IXmlSerializable.ReadXml(XmlReader reader) {
        var numerator = BigInteger.Zero;
        var denominator = BigInteger.One;
        var normalizationNotApplied = false;

        reader.ReadStartElement();

        while (reader.IsStartElement()) {
            switch (reader.Name) {
                case nameof(Numerator):
                    reader.ReadStartElement();
                    numerator = BigInteger.Parse(reader.ReadContentAsString(), CultureInfo.InvariantCulture);
                    reader.ReadEndElement();
                    break;
                case nameof(Denominator):
                    reader.ReadStartElement();
                    denominator = BigInteger.Parse(reader.ReadContentAsString(), CultureInfo.InvariantCulture);
                    reader.ReadEndElement();
                    break;
                case "NormalizationNotApplied":
                    reader.ReadStartElement();
                    normalizationNotApplied = bool.Parse(reader.ReadContentAsString());
                    reader.ReadEndElement();
                    break;
            }
        }

        if (reader.NodeType == XmlNodeType.EndElement) {
            reader.ReadEndElement();
        }

        this = new Fraction(normalizationNotApplied, numerator, denominator);
    }

    void IXmlSerializable.WriteXml(XmlWriter writer) {
        writer.WriteStartElement(nameof(Numerator));
        writer.WriteValue(Numerator.ToString(CultureInfo.InvariantCulture));
        writer.WriteEndElement();

        writer.WriteStartElement(nameof(Denominator));
        writer.WriteValue(Denominator.ToString(CultureInfo.InvariantCulture));
        writer.WriteEndElement();

        if (_normalizationNotApplied) {
            writer.WriteStartElement("NormalizationNotApplied");
            writer.WriteValue(bool.TrueString);
            writer.WriteEndElement();
        }
    }
}
#endif
