using System.Runtime.Serialization;

namespace Fractions.Tests.Serialization;

[DataContract]
public class TestDto {
    [DataMember]
    public Fraction Value { get; set; }

    [DataMember]
    public string Unit { get; set; }

    public TestDto() { }

    public TestDto(Fraction value, string unit) {
        Value = value;
        Unit = unit;
    }

    public override string ToString() => $"{Value} {Unit}";
}
