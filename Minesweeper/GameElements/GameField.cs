using System;
using System.Drawing;

namespace Minesweeper.GameElements
{
    /// <summary>
    /// Class containing all information of the game field
    /// </summary>
    public class GameField
    {
        /// <summary>
        /// Amount of the mines on the field.
        /// </summary>
        public int MinesAmount { get; private set; }

        private IField[,] gameField;
        /// <summary>
        /// Relationship between fields and mines.
        /// </summary>
        private readonly int mineRatio = 6;

        /// <summary>
        /// Constructor to generate the playing field.
        /// Calculates the fields and Mines.
        /// </summary>
        /// <param name="size">Game field size</param>
        public GameField(Size size)
        {
            CreateEmptyField(size);
            SetRandomMines();
            SetValueFields();
            CalculateValueFields();
        }

        /// <summary>
        /// Gets a value of a specific field.
        /// </summary>
        /// <param name="posX">X position on the field</param>
        /// <param name="posY">Y position on the field</param>
        /// <returns>Value of the field</returns>
        public string GetFieldValue(int posX, int posY)
        {
            return gameField[posX, posY].GetDisplayesValue();
        }

        /// <summary>
        /// Reveals a field and checks if it is a mine.
        /// </summary>
        /// <param name="posX">X position on the field</param>
        /// <param name="posY">Y position on the field</param>
        /// <returns>Is the field a mine or not</returns>
        public bool RevealeField(int posX, int posY)
        {
            gameField[posX, posY].IsRevealed = true;
            return gameField[posX, posY] is MineField;
        }

        /// <summary>
        /// Checks if all fields are revealed.
        /// </summary>
        /// <returns>True: If all value field are revealed</returns>
        public bool AllValueFieldsAreRevealed()
        {
            foreach (IField field in gameField)
            {
                if (field is ValueField && !(field as ValueField).IsRevealed)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Creates the field with empty objects
        /// </summary>
        /// <param name="size">Game field size</param>
        private void CreateEmptyField(Size size)
        {
            MinesAmount = size.Width * size.Height / mineRatio;
            gameField = new IField[size.Width, size.Height];
        }

        /// <summary>
        /// Calculates the value of all ValueFields
        /// </summary>
        private void CalculateValueFields()
        {
            for (int x = 0; x < gameField.GetLength(0); x += 1)
            {
                for (int y = 0; y < gameField.GetLength(1); y += 1)
                {
                    if (gameField[x, y] is ValueField)
                    {
                        int minesAdjoin = 0;
                        minesAdjoin += DetectMine(x + 1, y) ? 1 : 0;
                        minesAdjoin += DetectMine(x - 1, y) ? 1 : 0;
                        minesAdjoin += DetectMine(x, y + 1) ? 1 : 0;
                        minesAdjoin += DetectMine(x, y - 1) ? 1 : 0;
                        (gameField[x, y] as ValueField).Value = minesAdjoin;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the number of mines at random points
        /// </summary>
        private void SetRandomMines()
        {
            Random r = new Random();
            for (int minesSet = 0; minesSet < MinesAmount; minesSet += 1)
            {
                int randomX = r.Next(0, gameField.GetLength(0));
                int randomY = r.Next(0, gameField.GetLength(1));
                // Check if the field already have a mine
                if (gameField[randomX, randomY] == null) 
                {
                    gameField[randomX, randomY] = new MineField();
                } 
                else
                {
                    minesSet--;
                }
            }
        }

        /// <summary>
        /// Sets on all not set fields of the game the ValueFields.
        /// </summary>
        private void SetValueFields()
        {
            for (int x = 0; x < gameField.GetLength(0); x += 1)
            {
                for (int y = 0; y < gameField.GetLength(1); y += 1)
                {
                    if (gameField[x, y] == null)
                    {
                        gameField[x, y] = new ValueField();
                    }
                }
            }
        }

        /// <summary>
        /// Detect if a field is a mine or not.
        /// </summary>
        /// <param name="posX">X position on the field</param>
        /// <param name="posY">Y position on the field</param>
        /// <returns>Is field a mine</returns>
        private bool DetectMine(int posX, int posY)
        {
            // Check field exists
            if (posX < 0 || posY < 0 || gameField.GetLength(0) <= posX || gameField.GetLength(1) <= posY)
            {
                return false;
            }
            return gameField[posX, posY] is MineField;
        }
    }
}
