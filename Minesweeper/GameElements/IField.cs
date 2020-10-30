namespace Minesweeper.GameElements
{
    /// <summary>
    /// Interface for all game fields
    /// </summary>
    public interface IField
    {
        /// <summary>
        /// Determine if a field is revealed
        /// </summary>
        public bool IsRevealed { get; set; }

        /// <summary>
        /// Get the current value of the field
        /// </summary>
        /// <returns>Displayed value</returns>
        public string GetDisplayesValue();
    }
}
