namespace Calcify.Math
{
    /// <summary>
    /// Provides mathematical constants used throughout the application.
    /// </summary>
    /// <remarks>This class contains commonly used mathematical constants as static readonly fields for
    /// convenience and consistency. All members are thread-safe and can be accessed without instantiating the
    /// class.</remarks>
    public static class Constants
    {
        /// <summary>
        /// Represents the value of the negative golden ratio constant (approximately -0.618).
        /// </summary>
        /// <remarks>The negative golden ratio, often denoted as Phi, is defined as (1 - √5) / 2. It is
        /// commonly used in mathematics, geometry, and design for its unique properties related to proportions and
        /// aesthetics.</remarks>
        public static readonly double Phi = (1 - System.Math.Sqrt(5)) / 2;
    }
}