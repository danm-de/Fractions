namespace Fractions {
    public partial struct Fraction
    {
        /// <summary>
        /// The fraction's state.
        /// </summary>
        public enum FractionState
        {
            /// <summary>
            /// Unknown state.
            /// </summary>
            Unknown,

            /// <summary>
            /// A reduced/simplified fraction.
            /// </summary>
            IsNormalized
        }
    }
}