namespace Fractions;

/// <summary>
/// The fraction's state.
/// </summary>
public enum FractionState
{
    /// <summary>
    /// Unknown state.
    /// </summary>
    Unknown = 0x0,

    /// <summary>
    /// A reduced/simplified fraction.
    /// </summary>
    IsNormalized = 0x1
}
