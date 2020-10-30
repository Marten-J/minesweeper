using Minesweeper.GameData;
namespace Minesweeper.GameElements
{
    /// <summary>
    /// Number Field of the game field
    /// </summary>
    public class ValueField: IField
    {
        public bool IsRevealed { get; set; } = false;
        /// <summary>
        /// Displayed number value of the field
        /// </summary>
        public int Value { get; set; } = 0;

        public string GetDisplayesValue()
        {
            return IsRevealed ? Value.ToString() : Configuration.HiddenFieldValue;
        }
    }
}
