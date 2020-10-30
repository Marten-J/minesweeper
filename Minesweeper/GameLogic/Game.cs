using Minesweeper.GameData;
using Minesweeper.GameElements;
using System;
using System.Drawing;

namespace Minesweeper.GameLogic
{
    /// <summary>
    /// Main class with the game behavior/logic
    /// </summary>
    public class Game
    {
        private GameField gameField;
        /// <summary>
        /// Creates the playing field and then starts the game
        /// </summary>
        public void StartGame()
        {
            gameField = CreateGameField();
            Console.WriteLine(String.Format(Language.ExplanationMines, gameField.MinesAmount));
            DisplayField();
            PlayGame();
        }

        /// <summary>
        /// Game Loop: Get user input to select a field until the game is finished.
        /// </summary>
        private void PlayGame()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine(Language.ExplanationPositionRow);
                int xPos = GetPositionInput(FieldSize.Width);
                
                Console.WriteLine(Language.ExplanationPositionColumn);
                int yPos = GetPositionInput(FieldSize.Height);
                
                bool isMine = gameField.RevealeField(xPos, yPos);
                
                DisplayField();
                // Check if the game is over
                if (isMine)
                {
                    Console.WriteLine(Language.LoseMessage);
                    isRunning = false;
                }
                if (gameField.AllValueFieldsAreRevealed())
                {
                    Console.WriteLine(Language.WinMessage);
                    isRunning = false;
                }
            }
        }
        /// <summary>
        /// Size of the game field
        /// </summary>
        private Size FieldSize { get; set; }

        /// <summary>
        /// Creates a game field with the values entered by the user.
        /// </summary>
        /// <returns>The created game field</returns>
        private GameField CreateGameField()
        {
            Console.WriteLine(String.Format(Language.ExplanationStart, Configuration.MinValueFieldSize, Configuration.MaxValueFieldSize));
            int rows = GetSizeInput();

            Console.WriteLine(Language.ExplanationInputSizeColumns);
            int columns = GetSizeInput();

            FieldSize = new Size(rows, columns);
            return new GameField(FieldSize);
        }

        /// <summary>
        /// Outputs the playing field to the console.
        /// The playing field contains index of rows and lines.
        /// </summary>
        private void DisplayField()
        {
            for(int x = 0; x <= FieldSize.Width; x += 1)
            {
                string lineOutput = x == 0 ? $"{"", 3}" : CreateLineNumberOutput(x);
                for (int y = 0; y < FieldSize.Height; y += 1)
                {
                    if (x == 0)
                    {
                        lineOutput += CreateLineNumberOutput(y + 1);
                    }
                    else
                    {
                        lineOutput += $"{$"{gameField.GetFieldValue(x - 1, y)} ", 3}";
                    }
                }
                Console.WriteLine(lineOutput);
            }
        }

        /// <summary>
        /// formats the given number for the console output as index entry
        /// </summary>
        /// <param name="number">Number to format</param>
        /// <returns>The formated number</returns>
        private string CreateLineNumberOutput(int number)
        {
            return $"{$"({number})",3}";
        }

        /// <summary>
        /// Asks the user for an input for the field size until the input is valid
        /// </summary>
        /// <returns>Entred input</returns>
        private int GetSizeInput()
        {
            bool validInput = false;
            int size = 0;

            while (!validInput)
            {
                validInput = int.TryParse(Console.ReadLine(), out size) && 
                    size >= Configuration.MinValueFieldSize && 
                    size <= Configuration.MaxValueFieldSize;

                if (!validInput)
                {
                    Console.WriteLine(String.Format(Language.WrongSizeInput, Configuration.MinValueFieldSize, Configuration.MaxValueFieldSize));
                }
            }
            return size;
        }

        /// <summary>
        /// Asks the user for an input for a position until the input is valid
        /// </summary>
        /// <param name="allowedLength">Max length of the input.</param>
        /// <returns>Entred Input</returns>
        private int GetPositionInput(int allowedLength)
        {
            bool validInput = false;
            int pos = 0;

            while (!validInput)
            {
                validInput = int.TryParse(Console.ReadLine(), out pos) && pos > 0 && pos <= allowedLength;
                if (!validInput)
                {
                    Console.WriteLine(Language.WrongSizeInput);
                }
            }
            return pos - 1;
        }
    }
}
