using System;

namespace Fractions;

/// <summary>
/// Exception that will be thrown if an argument contains not a number (NaN) or is infinite.
/// </summary>
[Obsolete(message: "The data type now supports NaN and Infinity, so this exception type is no longer needed.",
    error: false)]
public class InvalidNumberException : ArithmeticException {
#pragma warning disable 1591
    public InvalidNumberException() { }
    public InvalidNumberException(string message) : base(message) { }
    public InvalidNumberException(string message, Exception innerException) : base(message, innerException) { }
#pragma warning restore 1591
}
