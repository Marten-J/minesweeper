using Minesweeper.GameData;
using Minesweeper.GameElements;
using NUnit.Framework;
using System.Drawing;

namespace Minesweeper.Test.GameElements
{
    /// <summary>
    /// Test class of the game field
    /// </summary>
    [TestFixture]
    class GameField_Test
    {
        private GameField field;
        private int fildSizeX = 5;
        private int fildSizeY = 5;

        [SetUp]
        public void SetUp()
        {
            field = new GameField(new Size(fildSizeX, fildSizeY));
        }

        /// <summary>
        /// Test Checks if the field is created correctly. (Amount of mines)
        /// </summary>
        [Test]
        public void GameField_ValidInput_CreateCorrectField()
        {
            int numberOfMines = 0;

            for (int x = 0; x < fildSizeX; x += 1)
            {
                for (int y = 0; y < fildSizeY; y += 1)
                {
                    if (field.RevealeField(x, y))
                    {
                        numberOfMines++;
                    }
                }
            }

            Assert.AreEqual(numberOfMines, field.MinesAmount);
        }

        /// <summary>
        /// Test if nothing is revealed the HiddenFieldValue is returned
        /// </summary>
        [Test]
        public void GetFieldValue_ValidInput_ReturnHideSymbole()
        {
            Assert.AreEqual(field.GetFieldValue(0, 0), Configuration.HiddenFieldValue);
            Assert.AreEqual(field.GetFieldValue(2, 2), Configuration.HiddenFieldValue);
            Assert.AreEqual(field.GetFieldValue(4, 4), Configuration.HiddenFieldValue);
        }

        /// <summary>
        /// Test if a field is revealed afer the method is called
        /// </summary>
        public void RevealeField_ValidInput_FieldIsRevealedAfterwards()
        {
            Assert.AreEqual(field.GetFieldValue(3, 3), Configuration.HiddenFieldValue);
            field.RevealeField(3, 3);
            Assert.AreNotEqual(field.GetFieldValue(3, 3), Configuration.HiddenFieldValue);
        }

        /// <summary>
        /// Test if values are revealed the HiddenFieldValue is not returned
        /// </summary>
        [Test]
        public void GetFieldValue_ValidInputRevealed_ReturnHideSymbole()
        {
            field.RevealeField(0, 0);
            field.RevealeField(2, 2);
            field.RevealeField(4, 4);
            Assert.AreNotEqual(field.GetFieldValue(0, 0), Configuration.HiddenFieldValue);
            Assert.AreNotEqual(field.GetFieldValue(2, 2), Configuration.HiddenFieldValue);
            Assert.AreNotEqual(field.GetFieldValue(4, 4), Configuration.HiddenFieldValue);
        }

        /// <summary>
        /// Check if all field are revealed the method returns true
        /// </summary>
        [Test]
        public void AllValueFieldsAreRevealed_RevealAllFields_ReturnTrue()
        {
            Assert.IsFalse(field.AllValueFieldsAreRevealed());
            for (int x = 0; x < fildSizeX; x += 1)
            {
                for (int y = 0; y < fildSizeY; y += 1)
                {
                    // Just reveal ValueFields and not MineFields
                    if (!field.RevealeField(x, y))
                    {
                        field.RevealeField(x, y);
                    }
                }
            }
            Assert.IsTrue(field.AllValueFieldsAreRevealed());
        }
    }
}
