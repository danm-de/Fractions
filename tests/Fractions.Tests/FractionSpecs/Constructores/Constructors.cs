using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.Constructores {
    [TestFixture]
    public class Wenn_ein_Bruch_ohne_Konstruktorparameter_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction();
        }

        [Test]
        public void Soll_der_Zähler_im_resultierenden_Bruch_0L_sein() {
            _fraction.Numerator
                .Should()
                .Be(0L);
        }

        [Test]
        public void Soll_der_Nenner_im_resultierenden_Bruch_0L_sein() {
            _fraction.Denominator
                .Should()
                .Be(0L);
        }

        [Test]
        public void Soll_der_Bruch_0_sein() {
            _fraction.IsZero
                .Should()
                .BeTrue();
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_0L_als_Zähler_und_0L_als_Nenner_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction(0L, 0L, false);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_darstellen() {
            _fraction.IsZero
                .Should()
                .BeTrue();
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_0L_als_Zähler_und_1L_als_Nenner_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction(0L, 1L, false);
        }

        [Test]
        public void Soll_der_Zähler_im_resultierenden_Bruch_0L_sein() {
            _fraction.Numerator
                .Should()
                .Be(0L);
        }

        [Test]
        public void Soll_der_Nenner_im_resultierenden_Bruch_1L_sein() {
            _fraction.Denominator
                .Should()
                .Be(1L);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_0L_als_Zähler_und_0L_als_Nenner_normalisiert_erzeugt_wird_dann : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction(0L, 0L, true);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_Zero_darstellen() {
            _fraction.IsZero
                .Should()
                .BeTrue();
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_4L_als_Zähler_und_4L_als_Nenner_normalisiert_erzeugt_wird_dann : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction(4L, 4L, true);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_im_Zähler_1L_haben() {
            _fraction.Numerator
                .Should()
                .Be(1L);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_im_Nenner_1L_haben() {
            _fraction.Denominator
                .Should()
                .Be(1L);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_4L_als_Zähler_und_12L_als_Nenner_normalisiert_erzeugt_wird_dann : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction(4L, 12L, true);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_im_Zähler_1L_haben() {
            _fraction.Numerator
                .Should()
                .Be(1L);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_im_Nenner_3L_haben() {
            _fraction.Denominator
                .Should()
                .Be(3L);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_12L_als_Zähler_und_4L_als_Nenner_normalisiert_erzeugt_wird_dann : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction(12L, 4L, true);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_im_Zähler_3L_haben() {
            _fraction.Numerator
                .Should()
                .Be(3L);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_im_Nenner_1L_haben() {
            _fraction.Denominator
                .Should()
                .Be(1L);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_0L_als_Zähler_und_4L_als_Nenner_normalisiert_erzeugt_wird_dann : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction(0L, 4L, true);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_im_Zähler_0L_haben() {
            _fraction.Numerator
                .Should()
                .Be(0L);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_im_Nenner_0L_haben() {
            _fraction.Denominator
                .Should()
                .Be(0L);
        }
    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_int_0_als_Zähler_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _fraction.Denominator.Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _fraction.Numerator.Should().Be(0);
        }

    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_uint_0_als_Zähler_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction((uint) 0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _fraction.Denominator.Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _fraction.Numerator.Should().Be(0);
        }

    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_long_0_als_Zähler_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction((long) 0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _fraction.Denominator.Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _fraction.Numerator.Should().Be(0);
        }

    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_ulong_0_als_Zähler_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction((ulong) 0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _fraction.Denominator.Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _fraction.Numerator.Should().Be(0);
        }

    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_double_0_als_Zähler_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction((double) 0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _fraction.Denominator.Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _fraction.Numerator.Should().Be(0);
        }

    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_decimal_0_als_Zähler_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction((decimal) 0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _fraction.Denominator.Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _fraction.Numerator.Should().Be(0);
        }

    }

    [TestFixture]
    public class Wenn_ein_Bruch_mit_BigInteger_0_als_Zähler_erzeugt_wird : Spec {
        private Fraction _fraction;

        public override void Act() {
            _fraction = new Fraction((BigInteger) 0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Nenner_haben() {
            _fraction.Denominator.Should().Be(0);
        }

        [Test]
        public void Soll_der_resultierende_Bruch_0_als_Zähler_haben() {
            _fraction.Numerator.Should().Be(0);
        }

    }
}