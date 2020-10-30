using Minesweeper.GameData;

namespace Minesweeper.GameElements
{
    /// <summary>
    /// Mine field of the game field
    /// </summary>
    public class MineField : IField
    {
        public bool IsRevealed { get; set; } = false;
        /// <summary>
        /// Appearance of the field if revealed
        /// </summary>
        public const string RevealedValue = "*";

        public string GetDisplayesValue()
        {
            return IsRevealed ? RevealedValue : Configuration.HiddenFieldValue;
        }
    }
}
