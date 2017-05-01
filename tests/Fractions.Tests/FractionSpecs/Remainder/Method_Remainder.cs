using System;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Remainder {
    [TestFixture]
    public class Wenn_1_Mod_3_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(1);
            _b = new Fraction(3);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_1_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(1));
        }
    }

    [TestFixture]
    public class Wenn_0_Mod_3_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(0);
            _b = new Fraction(3);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_0_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(0));
        }
    }

    [TestFixture]
    public class Wenn_4_Mod_3_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(4);
            _b = new Fraction(3);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_1_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(1));
        }
    }

    [TestFixture]
    public class Wenn_5_Mod_3_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(5);
            _b = new Fraction(3);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_2_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(2));
        }
    }

    [TestFixture]
    public class Wenn_minus5_Mod_3_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(-5);
            _b = new Fraction(3);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_minus2_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(-2));
        }
    }

    [TestFixture]
    public class Wenn_minus5_Mod_minus3_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(-5);
            _b = new Fraction(-3);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_minus2_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(-2));
        }
    }

    [TestFixture]
    public class Wenn_5_Mod_minus3_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(5);
            _b = new Fraction(-3);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_2_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(2));
        }
    }

    [TestFixture]
    public class Wenn_6_Mod_3_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(6);
            _b = new Fraction(3);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_0_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(0));
        }
    }

    [TestFixture]
    public class Wenn_6_Mod_0_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Exception _exception;

        public override void SetUp() {
            _a = new Fraction(6);
            _b = new Fraction(0);
        }

        public override void Act() {
            _exception = Catch.Exception(() => _a.Remainder(_b));
        }

        [Test]
        public void Soll_eine_Division_durch_0_Exception_ausgelöst_werden() {
            _exception.Should().BeOfType<DivideByZeroException>();
        }
    }

    [TestFixture]
    public class Wenn_2_komma5_Mod_0_komma5_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(5, 2);
            _b = new Fraction(1, 2);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_0_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(0));
        }
    }

    [TestFixture]
    public class Wenn_2_komma3_Mod_0_komma5_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = new Fraction(23, 10);
            _b = new Fraction(1, 2);
        }

        public override void Act() {
            _result = _a.Remainder(_b);
        }

        [Test]
        public void Soll_0_3_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(3, 10));
        }
    }

    [TestFixture]
    public class Wenn_131_Mod_320_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = 131;
            _b = 320;
        }

        public override void Act() {
            _result = _a % _b;
        }

        [Test]
        public void Soll_131_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(131));
        }
    }

    [TestFixture]
    public class Wenn_60_Mod_100_errechnet_wird : Spec {
        private Fraction _a;
        private Fraction _b;
        private Fraction _result;

        public override void SetUp() {
            _a = 60;
            _b = 100;
        }

        public override void Act() {
            _result = _a % _b;
        }

        [Test]
        public void Soll_60_als_Ergebnis_zurückgeliefert_werden() {
            _result.Should().Be(new Fraction(60));
        }
    }
}