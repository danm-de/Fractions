// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using System;
using Fractions;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.Fractions.FractionSpecs.Method_ToDataType
{
    [TestFixture]
    public class Wenn_ein_0_Bruch_in_ein_Decimal_konvertiert_wird : Spec
    {
        [Test]
        public void Soll_das_Ergebnis_0_sein() {
            Fraction.Zero.ToDecimal().Should().Be(0);
        }
    }

    [TestFixture]
    public class Wenn_ein_1viertel_in_ein_Decimal_konvertiert_wird : Spec
    {
        [Test]
        public void Soll_das_Ergebnis_0_25_sein() {
            (new Fraction(1,4)).ToDecimal().Should().Be(0.25m);
        }
    }

}