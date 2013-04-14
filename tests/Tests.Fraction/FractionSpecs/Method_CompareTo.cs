// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using Fractions;
using FluentAssertions;

using NUnit.Framework;

namespace Tests.Fractions.FractionSpecs.Method_CompareTo {
	[TestFixture]
	public class Wenn_5_mit_4_verglichen_wird : Spec {
		private Fraction _a;
		private Fraction _b;
		private int _result;

		public override void SetUp() {
			_a = new Fraction(5);
			_b = new Fraction(4);
		}

		public override void Act() {
			_result = _a.CompareTo(_b);
		}

		[Test]
		public void Soll_5_größer_als_4_sein() {
			_result.Should().BeGreaterThan(0);
		}
	}

	[TestFixture]
	public class Wenn_4_mit_5_verglichen_wird : Spec {
		private Fraction _a;
		private Fraction _b;
		private int _result;

		public override void SetUp() {
			_a = new Fraction(4);
			_b = new Fraction(5);
		}

		public override void Act() {
			_result = _a.CompareTo(_b);
		}

		[Test]
		public void Soll_4_kleiner_als_5_sein() {
			_result.Should().BeLessThan(0);
		}
	}

	[TestFixture]
	public class Wenn_5_mit_5_verglichen_wird : Spec {
		private Fraction _a;
		private Fraction _b;
		private int _result;

		public override void SetUp() {
			_a = new Fraction(5);
			_b = new Fraction(5);
		}

		public override void Act() {
			_result = _a.CompareTo(_b);
		}

		[Test]
		public void Soll_5_gleich_5_sein() {
			_result.Should().Be(0);
		}
	}

	[Category("")]
	[TestFixture]
	public class Wenn_1_fünftel_mit_1_zehntel_verglichen_wird : Spec {
		private Fraction _a;
		private Fraction _b;
		private int _result;

		public override void SetUp() {
			_a = new Fraction(1,5);
			_b = new Fraction(1,10);
		}

		public override void Act() {
			_result = _a.CompareTo(_b);
		}

		[Test]
		public void Soll_1_fünftel_größer_als_1_zehntel_sein() {
			_result.Should().BeGreaterThan(0);
		}	 
	}

	[Category("")]
	[TestFixture]
	public class Wenn_0_mit_131_verglichen_wird : Spec
	{
		private Fraction _a;
		private Fraction _b;
		private int _compare_to;

		public override void SetUp() {
			_a = new Fraction(0);
			_b = new Fraction(131);
		}

		public override void Act() {
			_compare_to = _a.CompareTo(_b);
		}

		[Test]
		public void Soll_dies_nicht_als_gleich_erachtet_werden() {
			_a.Should().NotBe(_b);
		}

		[Test]
		public void Soll_CompareTo_negativ_sein() {
			(_compare_to == -1).Should().BeTrue();
		}
	}
}
