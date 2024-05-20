﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using Tests.Fractions;

namespace Fractions.Tests.FractionSpecs.FromString;

[TestFixture]
// German: Wenn versucht wird, aus einem Leerstring einen Bruch zu erzeugen
public class When_trying_to_create_a_fraction_from_an_empty_string : Spec {
    [Test]
    // German: Dies sollte nicht funktionieren
    public void This_should_not_work([Values("", " ")] string invalidString) {
        // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
        Invoking(() => Fraction.FromString(invalidString))
            .Should()
            .Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus 999999999999999999999 ein Bruch erzeugt wird
public class When_creating_a_fraction_from_999999999999999999999 : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.FromString("999999999999999999999");
    }

    [Test]
    // German: Der Zähler des Bruches sollte 999999999999999999999 sein
    public void The_numerator_of_the_fraction_should_be_999999999999999999999() {
        _result.Numerator.ToString()
            .Should().Be("999999999999999999999");
    }

    [Test]
    // German: Der Nenner des Bruches sollte 1 sein
    public void The_denominator_of_the_fraction_should_be_1() {
        _result.Denominator
            .Should().Be(1);
    }
}

[TestFixture]
[Culture("de-DE")]
// German: Wenn aus minus 999999999999999999999 mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_minus_999999999999999999999_with_German_culture : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.FromString("-999999999999999999999");
    }

    [Test]
    // German: Der Zähler des Bruches sollte minus 999999999999999999999 sein
    public void The_numerator_of_the_fraction_should_be_minus_999999999999999999999() {
        _result.Numerator.ToString()
            .Should().Be("-999999999999999999999");
    }

    [Test]
    // German: Der Nenner des Bruches sollte 1 sein
    public void The_denominator_of_the_fraction_should_be_1() {
        _result.Denominator
            .Should().Be(1);
    }
}

[TestFixture]
// German: Wenn aus 3,5 mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_5_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2_by_default(
        [Values("3,5", " 3,5", "3,5 "," 3,5 ",
            "+3,5", " +3,5", "+3,5 ", " +3,5 ",
            "3,5+"," 3,5+", "3,5+ ", " 3,5+ ",
            "3,5 +"," 3,5 +", "3,5 + ", " 3,5 + "  // any spaces before or after the trailing sign are ok
            )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, germanCulture)
            .Should().Be(new Fraction(7, 2));
    }
    
    [Test]
    public void The_result_should_be_35_over_10_when_not_normalized(
        [Values("3,5", " 3,5", "3,5 "," 3,5 ",
            "+3,5", " +3,5", "+3,5 ", " +3,5 ",
            "3,5+"," 3,5+", "3,5+ ", " 3,5+ ",
            "3,5 +"," 3,5 +", "3,5 + ", " 3,5 + "  // any spaces before or after the trailing sign are ok
            )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, germanCulture, false)
            .Should().Be(new Fraction(35, 10, false));
    }
    
    [Test]
    public void A_FormatException_should_be_thrown_when_invalid_spaces_are_detected(
        [Values("3 ,5", " 3, 5",
            "+3 ,5", "+3, 5",
            "+ 3,5"  // this one is peculiar: any spaces after the leading sign are rejected
            )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_multiple_sings_are_detected(
        [Values("+3,5+", "+3,5-", "+(3,5)")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, NumberStyles.Any, germanCulture))
            .Should().Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus 3,50 mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_50_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2_by_default(
        [Values("3,50", " 3,50", "3,50 "," 3,50 ",
            "+3,50", " +3,50", "+3,50 ", " +3,50 ",
            "3,50+"," 3,50+", "3,50+ ", " 3,50+ ",
            "3,50 +"," 3,50 +", "3,50 + ", " 3,50 + "  // any spaces before or after the trailing sign are ok
            )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, germanCulture)
            .Should().Be(new Fraction(7, 2));
    }
    
    [Test]
    public void The_result_should_be_350_over_100_when_not_normalized(
        [Values("3,50", " 3,50", "3,50 "," 3,50 ",
            "+3,50", " +3,50", "+3,50 ", " +3,50 ",
            "3,50+"," 3,50+", "3,50+ ", " 3,50+ ",
            "3,50 +"," 3,50 +", "3,50 + ", " 3,50 + "  // any spaces before or after the trailing sign are ok
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, germanCulture, false)
            .Should().Be(new Fraction(350, 100, false));
    }
    

    [Test]
    public void A_FormatException_should_be_thrown_when_invalid_spaces_are_detected(
        [Values("3 ,50", " 3, 50",
            "+3 ,50", "+3, 50",
            "+ 3,50"  // this one is peculiar: any spaces after the leading sign are rejected
            )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_multiple_sings_are_detected(
        [Values("+3,50+", "+3,50-", "+(3,50)")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, NumberStyles.Any, germanCulture))
            .Should().Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus minus 3,5 mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_minus_3_5_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte minus 7 durch 2 sein
    public void The_result_should_be_minus_7_over_2_by_default(
        [Values("-3,5", " -3,5", "-3,5 ", " -3,5 ",
        "3,5-"," 3,5-", "3,5- ", " 3,5- ",
        "3,5 -"," 3,5 -", "3,5 - ", " 3,5 - "  // any spaces before or after the trailing sign are ok
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, germanCulture)
            .Should().Be(new Fraction(-7, 2));
    }

    [Test]
    public void The_result_should_be_minus_35_over_10_when_not_normalized(
        [Values("-3,5", " -3,5", "-3,5 ", " -3,5 ",
        "3,5-"," 3,5-", "3,5- ", " 3,5- ",
        "3,5 -"," 3,5 -", "3,5 - ", " 3,5 - "  // any spaces before or after the trailing sign are ok
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, germanCulture, false)
            .Should().Be(new Fraction(-35, 10, false));
    }
    
    [Test]
    public void The_result_should_be_minus_7_over_2_when_the_parentheses_are_allowed(
        [Values("(3,5)", " (3,5)", "(3,5) ", " (3,5) ")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture)
            .Should().Be(new Fraction(-7, 2));
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_parentheses_are_detected_but_not_allowed(
        [Values("-3,5+", "-3,5-", "-(3,5)", "(3,5)-")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value,  germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_invalid_spaces_are_detected(
        [Values("-3 ,5", "-3, 5", " -3, 5",
            "- 3,5"  // this one is peculiar: any spaces after the leading sign are rejected
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_multiple_sings_are_detected(
        [Values("-3,5+", "-3,5-", "-(3,5)", "(3,5)-")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, NumberStyles.Any, germanCulture))
            .Should().Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus minus 3,50 mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_minus_3_50_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte minus 7 durch 2 sein
    public void The_result_should_be_minus_7_over_2_by_default(
        [Values("-3,50", " -3,50", "-3,50 ", " -3,50 ",
        "3,50-"," 3,50-", "3,50- ", " 3,50- ",
        "3,50 -"," 3,50 -", "3,50 - ", " 3,50 - "  // any spaces before or after the trailing sign are ok
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, germanCulture)
            .Should().Be(new Fraction(-7, 2));
    }
    [Test]
    public void The_result_should_be_minus_350_over_100_when_not_normalized(
        [Values("-3,50", " -3,50", "-3,50 ", " -3,50 ",
        "3,50-"," 3,50-", "3,50- ", " 3,50- ",
        "3,50 -"," 3,50 -", "3,50 - ", " 3,50 - "  // any spaces before or after the trailing sign are ok
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, germanCulture, false)
            .Should().Be(new Fraction(-350, 100, false));
    }
    
    [Test]
    public void The_result_should_be_minus_7_over_2_when_the_parentheses_are_allowed(
        [Values("(3,50)", " (3,50)", "(3,50) ", " (3,50) ")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture)
            .Should().Be(new Fraction(-7, 2));
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_parentheses_are_detected_but_not_allowed(
        [Values("-3,50+", "-3,50-", "-(3,50)", "(3,50)-")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value,  germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_invalid_spaces_are_detected(
        [Values("-3 ,50", "-3, 50", " -3, 50",
            "- 3,5"  // this one is peculiar: any spaces after the leading sign are rejected
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_multiple_sings_are_detected(
        [Values("-3,50+", "-3,50-", "-(3,50)", "(3,50)-")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, NumberStyles.Any, germanCulture))
            .Should().Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus 3,5 € mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_5_eur_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2_by_default(
        [Values("€3,5", "€ 3,5", "€3,5 ", "€+3,5", "€ +3,5", "€+3,5 ",
            "+€3,5",
            "€3,5+", "€3,5+ ", "€3,5 + ", " €3,5 + ", "€ 3,5+", " € 3,5+", " € 3,5 +", " € 3,5 + ",
            "3,5€", " 3,5€", "3,5 € ", "+3,5€", " +3,5€", "+3,5 €", " +3,5 €", " +3,5 € ",
            "3,5€+", " 3,5€+", "3,5 €+ ", "3,5 € + "," 3,5 € + ", // any spaces before or after the trailing symbols are ok
            "3,5 €+", " 3,5€ +", " 3,5+ €", " 3,5 + € ",
            // this one is extra peculiar: as long as there is a currency symbol directly before or after the sign, any spaces are ok (note that "+ 3,5" is rejected)
            "€+ 3,5", "+€ 3,5", " € + 3,5", " +€ 3,5"  
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture)
            .Should().Be(new Fraction(7, 2));
    }
    [Test]
    public void The_result_should_be_35_over_10_when_not_normalized(
        [Values("€3,5", "€ 3,5", "€3,5 ", "€+3,5", "€ +3,5", "€+3,5 ",
            "+€3,5",
            "€3,5+", "€3,5+ ", "€3,5 + ", " €3,5 + ", "€ 3,5+", " € 3,5+", " € 3,5 +", " € 3,5 + ",
            "3,5€", " 3,5€", "3,5 € ", "+3,5€", " +3,5€", "+3,5 €", " +3,5 €", " +3,5 € ",
            "3,5€+", " 3,5€+", "3,5 €+ ", "3,5 € + "," 3,5 € + ", // any spaces before or after the trailing symbols are ok
            "3,5 €+", " 3,5€ +", " 3,5+ €", " 3,5 + € ",
            // this one is extra peculiar: as long as there is a currency symbol directly before or after the sign, any spaces are ok (note that "+ 3,5" is rejected)
            "€+ 3,5", "+€ 3,5", " € + 3,5", " +€ 3,5"  
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture, false)
            .Should().Be(new Fraction(35, 10, false));
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_invalid_spaces_are_detected(
        [Values("+ 3,5€", "+ €3,5", "+ € 3,5"   // this one is peculiar: any spaces after the leading sign are rejected (as long as there isn't a currency symbol preceding it)
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, NumberStyles.Any, germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_multiple_currencies_are_detected(
        [Values("€3,5€", "€+3,5€", "+€3,5€", "€3,5€+", "€3,5+€")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, germanCulture))
            .Should().Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus 3,50 € mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_50_eur_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2_by_default(
        [Values("€3,50", "€ 3,50", "€3,50 ", "€+3,50", "€ +3,50", "€+3,50 ",
            "+€3,50",
            "€3,50+", "€3,50+ ", "€3,50 + ", " €3,50 + ", "€ 3,50+", " € 3,50+", " € 3,50 +", " € 3,50 + ",
            "3,50€", " 3,50€", "3,50 € ", "+3,50€", " +3,50€", "+3,50 €", " +3,50 €", " +3,50 € ",
            "3,50€+", " 3,50€+", "3,50 €+ ", "3,50 € + "," 3,50 € + ", // any spaces before or after the trailing symbols are ok
            "3,50 €+", " 3,50€ +", " 3,50+ €", " 3,50 + € ",
            // this one is extra peculiar: as long as there is a currency symbol directly before or after the sign, any spaces are ok (note that "+ 3,5" is rejected)
            "€+ 3,50", "+€ 3,50", " € + 3,50", " +€ 3,50"  
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture)
            .Should().Be(new Fraction(7, 2));
    }
    
    [Test]
    public void The_result_should_be_350_over_100_when_not_normalized(
        [Values("€3,50", "€ 3,50", "€3,50 ", "€+3,50", "€ +3,50", "€+3,50 ",
            "+€3,50",
            "€3,50+", "€3,50+ ", "€3,50 + ", " €3,50 + ", "€ 3,50+", " € 3,50+", " € 3,50 +", " € 3,50 + ",
            "3,50€", " 3,50€", "3,50 € ", "+3,50€", " +3,50€", "+3,50 €", " +3,50 €", " +3,50 € ",
            "3,50€+", " 3,50€+", "3,50 €+ ", "3,50 € + "," 3,50 € + ", // any spaces before or after the trailing symbols are ok
            "3,50 €+", " 3,50€ +", " 3,50+ €", " 3,50 + € ",
            // this one is extra peculiar: as long as there is a currency symbol directly before or after the sign, any spaces are ok (note that "+ 3,5" is rejected)
            "€+ 3,50", "+€ 3,50", " € + 3,50", " +€ 3,50"  
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture, false)
            .Should().Be(new Fraction(350, 100, false));
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_invalid_spaces_are_detected(
        [Values("+ 3,50€", "+ €3,50", "+ € 3,50"   // this one is peculiar: any spaces after the leading sign are rejected (as long as there isn't a currency symbol preceding it)
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, NumberStyles.Any, germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_multiple_currencies_are_detected(
        [Values("€3,50€", "€+3,50€", "+€3,50€", "€3,50€+", "€3,50+€")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, germanCulture))
            .Should().Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus -3,5 € mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_minus_3_5_eur_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte minus 7 durch 2 sein
    public void The_result_should_be_minus_7_over_2_by_default(
        [Values("-€3,5", 
            "€3,5-", "€3,5- ", "€3,5 - ", " €3,5 - ", "€ 3,5-", " € 3,5-", " € 3,5 -", " € 3,5 - ", 
            "-3,5€", " -3,5€", "-3,5 €", " -3,5 €", " -3,5 € ",
            "3,5€-", " 3,5€-", "3,5 €- ", "3,5 € - "," 3,5 € - ", // any spaces before or after the trailing symbols are ok
            "3,5 €-", " 3,5€ -", " 3,5- €", " 3,5 - € ",
            // this one is extra peculiar: as long as there is a currency symbol directly before or after the sign, any spaces are ok (note that "+ 3,5" is rejected)
            "€- 3,5", "-€ 3,5", " € - 3,5", " -€ 3,5"  
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture)
            .Should().Be(new Fraction(-7, 2));
    }
    
    [Test]
    public void The_result_should_be_minus_35_over_10_when_not_normalized(
        [Values("-€3,5", 
            "€3,5-", "€3,5- ", "€3,5 - ", " €3,5 - ", "€ 3,5-", " € 3,5-", " € 3,5 -", " € 3,5 - ", 
            "-3,5€", " -3,5€", "-3,5 €", " -3,5 €", " -3,5 € ",
            "3,5€-", " 3,5€-", "3,5 €- ", "3,5 € - "," 3,5 € - ", // any spaces before or after the trailing symbols are ok
            "3,5 €-", " 3,5€ -", " 3,5- €", " 3,5 - € ",
            // this one is extra peculiar: as long as there is a currency symbol directly before or after the sign, any spaces are ok (note that "+ 3,5" is rejected)
            "€- 3,5", "-€ 3,5", " € - 3,5", " -€ 3,5"  
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture, false)
            .Should().Be(new Fraction(-35, 10, false));
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_invalid_spaces_are_detected(
        [Values("- 3,5€", "- €3,5", "- € 3,5"   // this one is peculiar: any spaces after the leading sign are rejected (as long as there isn't a currency symbol preceding it)
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, NumberStyles.Any, germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_multiple_currencies_are_detected(
        [Values("€-3,5€", "-€3,5€", "€3,5€-", "€3,5-€")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, germanCulture))
            .Should().Throw<FormatException>();
    }
}

[TestFixture]
// German: Wenn aus -3,50 € mit deutscher Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_minus_3_50_eur_with_German_culture : Spec {
    [Test]
    // German: Das Ergebnis sollte minus 7 durch 2 sein
    public void The_result_should_be_minus_7_over_2_by_default(
        [Values("-€3,50", 
            "€3,50-", "€3,50- ", "€3,50 - ", " €3,50 - ", "€ 3,50-", " € 3,50-", " € 3,50 -", " € 3,50 - ", 
            "-3,50€", " -3,50€", "-3,50 €", " -3,50 €", " -3,50 € ",
            "3,50€-", " 3,50€-", "3,50 €- ", "3,50 € - "," 3,50 € - ", // any spaces before or after the trailing symbols are ok
            "3,50 €-", " 3,50€ -", " 3,50- €", " 3,50 - € ",
            // this one is extra peculiar: as long as there is a currency symbol directly before or after the sign, any spaces are ok (note that "+ 3,50" is rejected)
            "€- 3,50", "-€ 3,50", " € - 3,50", " -€ 3,50"  
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture)
            .Should().Be(new Fraction(-7, 2));
    }
    
    [Test]
    public void The_result_should_be_minus_350_over_100_when_not_normalized(
        [Values("-€3,50", 
            "€3,50-", "€3,50- ", "€3,50 - ", " €3,50 - ", "€ 3,50-", " € 3,50-", " € 3,50 -", " € 3,50 - ", 
            "-3,50€", " -3,50€", "-3,50 €", " -3,50 €", " -3,50 € ",
            "3,50€-", " 3,50€-", "3,50 €- ", "3,50 € - "," 3,50 € - ", // any spaces before or after the trailing symbols are ok
            "3,50 €-", " 3,50€ -", " 3,50- €", " 3,50 - € ",
            // this one is extra peculiar: as long as there is a currency symbol directly before or after the sign, any spaces are ok (note that "+ 3,50" is rejected)
            "€- 3,50", "-€ 3,50", " € - 3,50", " -€ 3,50"  
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeTrue("making sure the format is also recognized by double.TryParse");
        
        Fraction.FromString(value, NumberStyles.Any, germanCulture, false)
            .Should().Be(new Fraction(-350, 100, false));
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_invalid_spaces_are_detected(
        [Values("- 3,50€", "- €3,50", "- € 3,50"   // this one is peculiar: any spaces after the leading sign are rejected (as long as there isn't a currency symbol preceding it)
        )]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Any, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, NumberStyles.Any, germanCulture))
            .Should().Throw<FormatException>();
    }

    [Test]
    public void A_FormatException_should_be_thrown_when_multiple_currencies_are_detected(
        [Values("€-3,50€", "-€3,50€", "€3,50€-", "€3,50-€")]
        string value) {
        var germanCulture = CultureInfo.GetCultureInfo("de-DE");
        
        double.TryParse(value, NumberStyles.Number, germanCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");
        
        Invoking(() => Fraction.FromString(value, germanCulture))
            .Should().Throw<FormatException>();
    }
}

[TestFixture]
[Culture("de-DE")]
// German: Wenn aus 3,5 ohne explizite Angabe der Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_5_without_explicit_culture_specification : Spec {
    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2_by_default(
        [Values("3,5", " 3,5", "3,5 ", "+3,5", " +3,5", "+3,5 ", "+3,50 ")]
        string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(7, 2));
    }
    
    [Test]
    public void The_result_should_be_35_over_10_when_not_normalized(
        [Values("3,5", " 3,5", "3,5 ", "+3,5", " +3,5", "+3,5 ")]
        string value) {
        Fraction.FromString(value, normalize: false)
            .Should().Be(new Fraction(35, 10, false));
    }

    [Test]
    public void The_result_should_be_350_over_100_when_not_normalized(
        [Values("3,50", " 3,50", "3,50 ", "+3,50", " +3,50", "+3,50 ")]
        string value) {
        Fraction.FromString(value, normalize: false)
            .Should().Be(new Fraction(350, 100, false));
    }
}

[TestFixture]
// German: Wenn aus 3.5 mit US-amerikanischer Kultur ein Bruch erzeugt wird
public class When_creating_a_fraction_from_3_5_with_American_culture : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.FromString("3.5", CultureInfo.GetCultureInfo("en-US"));
    }

    [Test]
    // German: Das Ergebnis sollte 7 durch 2 sein
    public void The_result_should_be_7_over_2() {
        _result.Should().Be(new Fraction(7, 2));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette 1/5 ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_1_over_5 : Spec {
    [Test]
    // German: Das Ergebnis sollte 1 durch 5 sein
    public void The_result_should_be_1_over_5([Values("1/5", "-1/-5", "+1/5", "+1/+5", "1/+5")] string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(1, 5));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette minus 1/5 ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_minus_1_over_5 : Spec {
    [Test]
    // German: Das Ergebnis sollte minus 1 durch 5 sein
    public void The_result_should_be_minus_1_over_5([Values("-1/5", "1/-5")] string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(-1, 5));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette 64/40 mit beliebigen Leerzeichen ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_64_over_40_with_any_spaces : Spec {
    [Test]
    // German: Das Ergebnis sollte 64 durch 40 sein
    public void The_result_should_be_64_over_40(
        [Values("64/40 ", " 64/40", "64/ 40", "64 /40", "64 / 40")]
        string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(8, 5));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette minus 64/40 mit beliebigen Leerzeichen ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_minus_64_over_40_with_any_spaces : Spec {
    [Test]
    // German: Das Ergebnis sollte 64 durch 40 sein
    public void The_result_should_be_64_over_40(
        [Values("-64/40", " -64/40", "-64/ 40", "64 /-40", "64 / -40")]
        string value) {
        Fraction.FromString(value)
            .Should().Be(new Fraction(-8, 5));
    }
}

[TestFixture]
// German: Wenn aus der Zeichenkette minus 64/40 durch explizite Umwandlung ein Bruch erzeugt wird
public class When_creating_a_fraction_from_the_string_minus_64_over_40_by_explicit_conversion : Spec {
    private Fraction _result;

    public override void Act() {
        _result = (Fraction)"-64/40";
    }

    [Test]
    // German: Das Ergebnis sollte korrekt sein
    public void The_result_should_be_correct() {
        _result.Should().Be(new Fraction(-64, 40));
    }
}

[TestFixture]
public class When_creating_a_fraction_from_a_very_long_decimal_string : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.FromString("123456789987654321.1234567899876543210", CultureInfo.GetCultureInfo("en-US"));
    }

    [Test]
    public void The_number_is_parsed_without_any_loss_of_precision() {
        _result.Should().Be(new Fraction(
            BigInteger.Parse("123456789987654321123456789987654321"),
            BigInteger.Pow(10, 18))
        );
    }
}

[TestFixture]
public class When_creating_a_fraction_from_a_very_long_decimal_string_without_normalization : Spec {
    private Fraction _result;

    public override void Act() {
        _result = Fraction.FromString("123456789987654321.1234567899876543210", CultureInfo.GetCultureInfo("en-US"), false);
    }

    [Test]
    public void The_number_is_parsed_without_any_loss_of_precision() {
        _result.Should().Be(new Fraction(
            BigInteger.Parse("1234567899876543211234567899876543210"),
            BigInteger.Pow(10, 19), false)
        );
    }
}

[TestFixture]
public class Parsing_a_fraction_from_a_long_decimal_string_with_specific_number_style : Spec {
    public static IEnumerable<TestCaseData> ValidTestCases {
        get {
            var invariantCulture = CultureInfo.InvariantCulture;
            // zero with normalization
            var expectedResult = Fraction.Zero;
            yield return new TestCaseData("000000000000000000.0000000000000000000", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("-000000000000000000.0000000000000000000", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            // zero without normalization
            expectedResult = new Fraction(
                BigInteger.Zero,
                BigInteger.Pow(10, 19),
                    false);
            yield return new TestCaseData("000000000000000000.0000000000000000000", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("-000000000000000000.0000000000000000000", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            // negative decimals with normalization
            expectedResult = new Fraction(
                BigInteger.Parse("-123456789987654321123456789987654321"),
                BigInteger.Pow(10, 18));
            yield return new TestCaseData("-123456789987654321.1234567899876543210", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("123456789987654321.1234567899876543210-", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("-123456789987654321.1234567899876543210", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("1234,56789987654321.1234567899876543210-", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("(1234,56789987654321.1234567899876543210)", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.1234567899876543210)", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.1234567899876543210) ", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.1234567899876543210 ) ", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            // negative decimals without normalization
            expectedResult = new Fraction(
                BigInteger.Parse("-1234567899876543211234567899876543210"),
                BigInteger.Pow(10, 19),
                false);
            yield return new TestCaseData("-123456789987654321.1234567899876543210", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("123456789987654321.1234567899876543210-", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("-123456789987654321.1234567899876543210", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("1234,56789987654321.1234567899876543210-", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("(1234,56789987654321.1234567899876543210)", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.1234567899876543210)", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.1234567899876543210) ", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.1234567899876543210 ) ", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            // negative decimals with nothing after the radix (reduced)
            expectedResult = new Fraction(BigInteger.Parse("-123456789987654321"));
            yield return new TestCaseData("-123456789987654321.0", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("123456789987654321.0-", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("-123456789987654321.0", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("1234,56789987654321.0-", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("-123456789987654321.", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("123456789987654321.-", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("-123456789987654321.", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("1234,56789987654321.-", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData("(1234,56789987654321.)", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.)", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.) ", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321. ) ", NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            // negative decimals with one trailing zero after the radix (non-reduced)
            expectedResult = new Fraction(BigInteger.Parse("-1234567899876543210"), 10, false);
            yield return new TestCaseData("-123456789987654321.0", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("123456789987654321.0-", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("-123456789987654321.0", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("1234,56789987654321.0-", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("-123456789987654321.0", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("123456789987654321.0-", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("-123456789987654321.0", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("1234,56789987654321.0-", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData("(1234,56789987654321.0)", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.0)", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.0) ", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            yield return new TestCaseData(" (1234,56789987654321.0 ) ", NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            // negative decimals with nothing before the radix (reduced)
            expectedResult = new Fraction(-1, 10);
            foreach (var minusPointOne in new[] { "-.10", ".10-", " -.10", ".10- ", "(.10)", " (.10)", " (.10) " }) {
                yield return new TestCaseData(minusPointOne, NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            }
            // negative decimals with one trailing zero after the radix (non-reduced)
            expectedResult = new Fraction(-10, 100, false);
            foreach (var minusPointOne in new[] { "-.10", ".10-", " -.10", ".10- ", "(.10)", " (.10)", " (.10) " }) {
                yield return new TestCaseData(minusPointOne, NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            }

            expectedResult = new Fraction(1, 10);
            // positive decimals with nothing before the radix (reduced)
            foreach (var plusPointOne in new[] { ".10", " .10", ".10 ", "+.10", ".10+", " +.10", ".10+ " }) {
                yield return new TestCaseData(plusPointOne, NumberStyles.Any, invariantCulture, true).Returns(expectedResult);
            }

            expectedResult = new Fraction(10, 100, false);
            // positive decimals with nothing before the radix and one trailing zero (non-reduced)
            foreach (var plusPointOne in new[] { ".10", " .10", ".10 ", "+.10", ".10+", " +.10", ".10+ " }) {
                yield return new TestCaseData(plusPointOne, NumberStyles.Any, invariantCulture, false).Returns(expectedResult);
            }
        }
    }

    [Test]
    [TestCaseSource(nameof(ValidTestCases))]
    public Fraction Should_return_the_expected_value_when_the_string_is_valid(string valueToParse, NumberStyles numberStyles, IFormatProvider culture, bool normalize) {
        double.TryParse(valueToParse, numberStyles, culture, out _).Should().BeTrue("the format is also recognized by double.TryParse");
        return Fraction.FromString(valueToParse, numberStyles, culture, normalize);
    }

    [Test]
    public void Should_not_work_with_trailing_signs_when_it_is_not_allowed(
        [Values("123456789987654321.123456789987654321-", "123456789987654321.123456789987654321+")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any & ~NumberStyles.AllowTrailingSign, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_not_work_with_leading_signs_when_it_is_not_allowed(
        [Values("-123456789987654321.123456789987654321", "+123456789987654321.123456789987654321")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_not_work_with_signs_on_both_sides(
        [Values("-123456789987654321.123456789987654321-", "+123456789987654321.123456789987654321+",
            "+123456789987654321.123456789987654321-", "-123456789987654321.123456789987654321+")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_not_work_with_groups_in_the_middle(
        [Values("123456789987654321.123456789,987654321", "123456789987654321.,123456789987654321")]
        string valueToParse) {
        double.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");

        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_not_work_with_signs_in_the_middle(
        [Values("123456789987654321.-123456789987654321", "123456789987654321-.123456789987654321",
            "123456789987654321.+123456789987654321", "123456789987654321+.123456789987654321")]
        string valueToParse) {
        double.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");

        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }
    
    [Test]
    public void Should_not_work_without_digits(
        [Values(" ", " .", ". ", "-", "+", " .-", "+.", "+. ")]
        string valueToParse) {
        double.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _)
            .Should().BeFalse("the format isn't supposed to be recognized by double.TryParse");

        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }
}

[TestFixture]
public class Parsing_a_string_with_scientific_notation_representing_a_large_positive_number : Spec {
    [Test]
    public void Should_not_work_by_default(
        [Values("1.23456789987654321E+41", "1.23456789987654321e+41")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_work_without_loss_of_precision_with_NumberStyle_Any(
        [Values("1.23456789987654321E+41", "1.23456789987654321e+41", "1.234567899876543210E+41", "1.234567899876543210e+41")]
        string valueToParse) {
        // Arrange
        var expectedFraction = new Fraction(new BigInteger(123456789987654321) * BigInteger.Pow(10, 24));
        // Act
        var parsedValue = Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture);
        // Assert
        parsedValue.Should().Be(expectedFraction);
    }

    [Test]
    public void Should_work_without_loss_of_precision_with_NumberStyle_Any_and_without_normalization(
        [Values("1.23456789987654321E+41", "1.23456789987654321e+41", "1.234567899876543210E+41", "1.234567899876543210e+41")]
        string valueToParse) {
        // Arrange
        var expectedFraction = new Fraction(new BigInteger(123456789987654321) * BigInteger.Pow(10, 24), 1, false);
        // Act
        var parsedValue = Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, false);
        // Assert
        parsedValue.Should().Be(expectedFraction);
    }

    [Test]
    public void Should_not_work_for_decimal_exponents(
        [Values("1.23456789987654321E+41.5", "1.23456789987654321e+41.5")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }
}

[TestFixture]
public class Parsing_a_string_with_scientific_notation_representing_a_large_negative_number : Spec {
    [Test]
    public void Should_not_work_by_default(
        [Values("-1.23456789987654321E+41", "-1.23456789987654321e+41")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_work_without_loss_of_precision_with_NumberStyle_Any(
        [Values("-1.23456789987654321E+41", "-1.23456789987654321e+41", "-1.234567899876543210E+41", "-1.234567899876543210e+41")]
        string valueToParse) {
        // Arrange
        var expectedFraction = new Fraction(new BigInteger(-123456789987654321) * BigInteger.Pow(10, 24));
        // Act
        var parsedValue = Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture);
        // Assert
        parsedValue.Should().Be(expectedFraction);
    }

    [Test]
    public void Should_work_without_loss_of_precision_with_NumberStyle_Any_and_without_normalization(
        [Values("-1.23456789987654321E+41", "-1.23456789987654321e+41", "-1.234567899876543210E+41", "-1.234567899876543210e+41")]
        string valueToParse) {
        // Arrange
        var expectedFraction = new Fraction(new BigInteger(-123456789987654321) * BigInteger.Pow(10, 24), 1, false);
        // Act
        var parsedValue = Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, false);
        // Assert
        parsedValue.Should().Be(expectedFraction);
    }

    [Test]
    public void Should_not_work_for_decimal_exponents(
        [Values("-1.23456789987654321E+41.5", "-1.23456789987654321e+41.5")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }
}

[TestFixture]
public class Parsing_a_string_with_scientific_notation_representing_a_small_positive_number : Spec {
    [Test]
    public void Should_not_work_by_default(
        [Values("1.23456789987654321E-24", "1.23456789987654321e-24")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_work_without_loss_of_precision_with_NumberStyle_Any(
        [Values("1.23456789987654321E-24", "1.23456789987654321e-24",
            "1.234567899876543210E-24", "1.234567899876543210e-24",
            "1.23456789987654321E-24+", "1.23456789987654321e-24+",
            "1.234567899876543210E-24+", "1.234567899876543210e-24+",
            "12345.6789987654321E-28", "12345.6789987654321e-28",
            "12345.67899876543210E-28", "12345.67899876543210e-28",
            "12,345.6789987654321E-28", "12,345.6789987654321e-28",
            "12,345.67899876543210E-28", "12,345.67899876543210e-28")]
        string valueToParse) {
        // Arrange
        var cultureInfo = CultureInfo.InvariantCulture;
        var expectedFraction = new Fraction(new BigInteger(123456789987654321), BigInteger.Pow(10, 17 + 24));
        // Act
        var isValidFormat = double.TryParse(valueToParse, NumberStyles.Any, cultureInfo, out _);
        var parsedValue = Fraction.FromString(valueToParse, NumberStyles.Any, cultureInfo);
        // Assert
        isValidFormat.Should().BeTrue("making sure the format is also recognized by double.TryParse");
        parsedValue.Should().Be(expectedFraction);
    }

    [Test]
    public void Should_work_without_loss_of_precision_with_NumberStyle_Any_and_without_normalization(
        [Values("1.23456789987654321E-24", "1.23456789987654321e-24",
            "1.234567899876543210E-24", "1.234567899876543210e-24",
            "1.23456789987654321E-24+", "1.23456789987654321e-24+",
            "1.234567899876543210E-24+", "1.234567899876543210e-24+",
            "12345.6789987654321E-28", "12345.6789987654321e-28",
            "12345.67899876543210E-28", "12345.67899876543210e-28",
            "12,345.6789987654321E-28", "12,345.6789987654321e-28",
            "12,345.67899876543210E-28", "12,345.67899876543210e-28")]
        string valueToParse) {
        // Arrange
        var cultureInfo = CultureInfo.InvariantCulture;
        var expectedFraction = new Fraction(new BigInteger(123456789987654321), BigInteger.Pow(10, 17 + 24), false);
        // Act
        var isValidFormat = double.TryParse(valueToParse, NumberStyles.Any, cultureInfo, out _);
        var parsedValue = Fraction.FromString(valueToParse, NumberStyles.Any, cultureInfo, false);
        // Assert
        isValidFormat.Should().BeTrue("making sure the format is also recognized by double.TryParse");
        parsedValue.Should().Be(expectedFraction);
    }

    [Test]
    public void Should_not_work_for_decimal_exponents(
        [Values("1.23456789987654321E-24.5", "1.23456789987654321e-24.5")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_not_work_with_groups_in_the_middle(
        [Values("1.23456789,987654321E-24", "1.23456789,987654321e-24")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }
}

[TestFixture]
public class Parsing_a_string_with_scientific_notation_representing_a_small_negative_number : Spec {
    [Test]
    public void Should_not_work_by_default(
        [Values("-1.23456789987654321E-24", "-1.23456789987654321e-24")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_work_without_loss_of_precision_with_NumberStyle_Any(
        [Values("-1.23456789987654321E-24", "-1.23456789987654321e-24", "-1.234567899876543210E-24", "-1.234567899876543210e-24")]
        string valueToParse){
        // Arrange
        var expectedValue = new Fraction(new BigInteger(-123456789987654321), BigInteger.Pow(10, 17 + 24));
        // Act
        var parsedValue = Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture);
        // Assert
        parsedValue.Should().Be(expectedValue);
    }

    [Test]
    public void Should_work_without_loss_of_precision_with_NumberStyle_Any_and_trailing_zeros(
        [Values("-1.23456789987654321E-24", "-1.23456789987654321e-24", "-1.234567899876543210E-24", "-1.234567899876543210e-24")] 
        string valueToParse) {
        // Arrange
        var expectedValue = new Fraction(new BigInteger(-123456789987654321), BigInteger.Pow(10, 17 + 24), false);
        // Act
        var parsedValue = Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, false);
        // Assert
        parsedValue.Should().Be(expectedValue);
    }

    [Test]
    public void Should_not_work_for_decimal_exponents(
        [Values("-1.23456789987654321E-24.5", "-1.23456789987654321e-24.5")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void Should_not_work_with_groups_in_the_middle(
        [Values("-1.23456789,987654321E-24", "-1.23456789,987654321e-24")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }
}

[TestFixture]
public class When_creating_a_fraction_from_2A: Spec {
    [Test]
    public void Should_not_work_when_parsing_as_number(
        [Values("2A")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.Number, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }

    [Test]
    public void The_result_should_be_42_when_parsing_as_hex(
        [Values("2A", "2A ", " 2A", " 2A ")]
        string valueToParse) {
        Fraction.FromString(valueToParse, NumberStyles.HexNumber, CultureInfo.InvariantCulture)
            .Should().Be(new Fraction(42));
    }

    [Test]
    public void Should_not_work_with_spaces_in_the_middle(
        [Values("2 A")]
        string valueToParse) {
        Invoking(() => Fraction.FromString(valueToParse, NumberStyles.HexNumber, CultureInfo.InvariantCulture))
            .Should()
            .Throw<FormatException>();
    }
}

[TestFixture]
public class When_creating_a_fraction_with_custom_culture: Spec {
    [Test]
    public void The_result_should_be_the_expected_fraction() {
        // Arrange
        var customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        customCulture.NumberFormat.NegativeSign = "_minus_";
        customCulture.NumberFormat.NumberGroupSeparator = "_group_";
        customCulture.NumberFormat.NumberDecimalSeparator = "_decimal_";
        var valueToParse = "_minus_1_group_234_decimal_56";
        
        // Act
        var fraction = Fraction.FromString(valueToParse, NumberStyles.Number, customCulture);

        // Assert
        fraction.Should().Be(new Fraction(-1234.56m));
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_0_over_0 : Spec {
    [Test]
    public void The_result_should_be_NaN(
        [Values("0/0", "-0/0", " -0/0", "-0/ 0", "0 /-0", "0 / -0")]
        string value) {
        Fraction.FromString(value).IsNaN.Should().BeTrue();
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_0_over_1 : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("0/1", "-0/1", " -0/1", "0 /1", "0 / 1", "+0 / +1")]
        string value) {
        Fraction.FromString(value).Should().Be(Fraction.Zero);
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_0_over_10_with_normalization : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("0/10", "0 /10", "-0 /10", "+0 / +10")]
        string value) {
        Fraction.FromString(value).Should().Be(Fraction.Zero);
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_0_over_10_without_normalization : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("0/10", "0 / 10", "-0 / 10", "+0 / +10")]
        string value) {
        // TODO see about creating an overload for FromString(without normalization)
        Fraction.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, false, out var result).Should()
            .BeTrue();
        result.IsZero.Should().BeTrue(); // this is still considered "a zero"
        result.Should().NotBe(Fraction.Zero); // however it isn't strictly equal to the Zero
        result.Should().Be(new Fraction(0, 10, false)); // rather it's a non-normalized version
        result.Equals(Fraction.Zero).Should().BeTrue(); // which can be reduced to Zero
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_0_over_minus_10_with_normalization : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("0 /-10", "0 / -10")] string value) {
        Fraction.FromString(value).Should().Be(Fraction.Zero);
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_0_over_minus_10_without_normalization : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("0 /-10", "0 / -10")] string value) {
        var result = Fraction.FromString(value, NumberStyles.Any, CultureInfo.InvariantCulture, false);
        result.IsZero.Should().BeTrue(); // this is still considered "a zero"
        result.Should().NotBe(Fraction.Zero); // however it isn't strictly equal to the Zero
        result.Should().Be(new Fraction(0, -10, false)); // rather it's a non-normalized version
        result.Equals(Fraction.Zero).Should().BeTrue(); // which can be reduced to Zero
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_1_over_0 : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("1/0", "1 /-0", "1 / -0")] string value) {
        Fraction.FromString(value).Should().Be(Fraction.PositiveInfinity);
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_10_over_0_with_normalization : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("10/0", "10 /-0", "10 / -0")] string value) {
        Fraction.FromString(value).Should().Be(Fraction.PositiveInfinity);
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_10_over_0_without_normalization : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("10/0", "10 /-0", "10 / -0")] string value) {
        var result = Fraction.FromString(value, NumberStyles.Any, CultureInfo.InvariantCulture, false);
        result.IsPositiveInfinity.Should().BeTrue(); // this is still considered "a positive infinity"
        result.Should().NotBe(Fraction.PositiveInfinity); // however it isn't strictly equal to the PositiveInfinity
        result.Should().Be(new Fraction(10, 0, false)); // rather it's a non-normalized version
        result.Equals(Fraction.PositiveInfinity).Should().BeTrue(); // which can be reduced to PositiveInfinity
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_minus_1_over_0 : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("-1/0", "-1 /-0", "-1 / -0")] string value) {
        Fraction.FromString(value).Should().Be(Fraction.NegativeInfinity);
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_minus_10_over_0_with_normalization : Spec {
    [Test]
    public void The_result_should_be_PositiveInfinity(
        [Values("-10/0", "-10 /-0", "-10 / -0")]
        string value) {
        Fraction.FromString(value).Should().Be(Fraction.NegativeInfinity);
    }
}

[TestFixture]
public class When_creating_a_fraction_from_the_string_minus_10_over_0_without_normalization : Spec {
    [Test]
    public void The_result_should_be_NegativeInfinity(
        [Values("-10/0", "-10 /-0", "-10 / -0")]
        string value) {
        var result = Fraction.FromString(value, NumberStyles.Any, CultureInfo.InvariantCulture, false);
        result.IsNegativeInfinity.Should().BeTrue(); // this is still considered "a negative infinity"
        result.Should().NotBe(Fraction.NegativeInfinity); // however it isn't strictly equal to the NegativeInfinity
        result.Should().Be(new Fraction(-10, 0, false)); // rather it's a non-normalized version
        result.Equals(Fraction.NegativeInfinity).Should().BeTrue(); // which can be reduced to NegativeInfinity
    }
}
