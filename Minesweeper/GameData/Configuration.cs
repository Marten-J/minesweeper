namespace Minesweeper.GameData
{
    /// <summary>
    /// Configuration file with all values that can be adjusted to change the game behaviour.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Appearance of the fields when they are not revealed.
        /// </summary>
        public const string HiddenFieldValue = "#";
        /// <summary>
        /// The minimum field size
        /// </summary>
        public const int MinValueFieldSize = 3;
        /// <summary>
        /// The maximum field size
        /// </summary>
        public const int MaxValueFieldSize = 9;
    }
}
