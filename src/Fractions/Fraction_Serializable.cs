#if false
using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.Serialization;

namespace Fractions;

[Serializable]
public partial struct Fraction : ISerializable {
    private Fraction(SerializationInfo info, StreamingContext context) {
        if (info == null) {
            throw new ArgumentNullException(nameof(info));
        }

        var numerator = BigInteger.Parse(info.GetString(nameof(Numerator)) ?? "0", CultureInfo.InvariantCulture);
        var denominator = BigInteger.Parse(info.GetString(nameof(Denominator)) ?? "0", CultureInfo.InvariantCulture);
        var normalizationNotApplied = info.GetBoolean("NormalizationNotApplied");
        this = new Fraction(normalizationNotApplied, numerator, denominator);
    }

    #if NETSTANDARD
    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
    #endif
    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) {
        if (info == null) {
            throw new ArgumentNullException(nameof(info));
        }

        info.AddValue(nameof(Numerator), Numerator.ToString(CultureInfo.InvariantCulture));
        info.AddValue(nameof(Denominator), Denominator.ToString(CultureInfo.InvariantCulture));
        info.AddValue("NormalizationNotApplied", _normalizationNotApplied);
    }
}
#endif
