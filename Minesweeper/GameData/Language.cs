namespace Minesweeper.GameData
{
    /// <summary>
    /// Class with all text outputs of the application
    /// </summary>
    public static class Language
    {
        public static string ExplanationStart { get; } = "Um das Spiel zu starten, geben Sie zuerst die Anzahl der Reihen des Feldes ein (Zahl zwischen {0} - {1}).";
        public static string ExplanationInputSizeColumns { get; } = "Als nächstes geben Sie die Anzahl der Zeilen des Feldes ein.";
        public static string ExplanationMines { get; } = "Es sind insgesamt {0} Mienen auf dem Feld vorhanden.";
        public static string ExplanationPositionRow { get; } = "Geben sie eine Zahl ein für die Reihe die Sie wählen wollen.";
        public static string ExplanationPositionColumn { get; } = "Geben sie eine Zahl ein für die Zeile die Sie wählen wollen.";
        public static string WrongSizeInput { get; } = "Der eingegebene Wert ist Fehlerhaft. Bitte geben Sie eine Zahl zwischen {0} und {1} ein.";
        public static string WrongPositionInput { get; } = "Der eingegebene Wert ist Fehlerhaft. Bitte geben Sie einen passenden Wert ein.";
        public static string WinMessage { get; } = "Sie haben gewonnen!!";
        public static string LoseMessage { get; } = "Sie haben verloren...";
    }
}
