using Minesweeper.GameData;
using Minesweeper.GameElements;
using NUnit.Framework;

namespace Minesweeper.Test.GameElements
{
    /// <summary>
    /// Test class of the mine field
    /// </summary>
    [TestFixture]
    public class MineField_Test
    {
        [Test]
        public void GetDisplayesValue_Called_ReturnCorrectValue()
        {
            MineField field = new MineField();
            Assert.AreEqual(field.GetDisplayesValue(), Configuration.HiddenFieldValue);
            field.IsRevealed = true;
            Assert.AreEqual(field.GetDisplayesValue(), "*");
        }
    }
}
