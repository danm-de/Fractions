using System;
using System.Runtime.Serialization;

namespace Fractions {
    /// <summary>
    /// Exception that will be thrown if an argument contains not a number (NaN) or is infinite.
    /// </summary>
    [Serializable]
    public class InvalidNumberException : ArithmeticException {
#pragma warning disable 1591
        public InvalidNumberException() {}
        public InvalidNumberException(string message) : base(message) {}
        public InvalidNumberException(string message, Exception inner_exception) : base(message, inner_exception) {}
        protected InvalidNumberException(SerializationInfo info, StreamingContext context) : base(info, context) {}
#pragma warning restore 1591
    }
}