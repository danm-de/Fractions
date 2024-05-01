using System.Globalization;
using System.Numerics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Fractions;

public partial struct Fraction : IXmlSerializable  {
    readonly XmlSchema IXmlSerializable.GetSchema() => null;

    void IXmlSerializable.ReadXml(XmlReader reader) {
        var numerator = reader.MoveToAttribute(nameof(Numerator))
            ? BigInteger.Parse(reader.Value, CultureInfo.InvariantCulture)
            : BigInteger.Zero;

        var denominator = reader.MoveToAttribute(nameof(Denominator))
            ? BigInteger.Parse(reader.Value, CultureInfo.InvariantCulture)
            : BigInteger.Zero;

        var normalizationNotApplied = reader.MoveToAttribute("NormalizationNotApplied") &&
                                      bool.Parse(reader.Value);

        this = new Fraction(normalizationNotApplied, numerator, denominator);
    }

    void IXmlSerializable.WriteXml(XmlWriter writer) {
        writer.WriteAttributeString(nameof(Numerator), Numerator.ToString(CultureInfo.InvariantCulture)!);
        writer.WriteAttributeString(nameof(Denominator), Denominator.ToString(CultureInfo.InvariantCulture)!);
        if (_normalizationNotApplied) {
            writer.WriteAttributeString("NormalizationNotApplied", bool.TrueString);
        }
    }
}
