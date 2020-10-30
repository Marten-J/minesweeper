using Minesweeper.GameData;
using Minesweeper.GameElements;
using NUnit.Framework;
namespace Minesweeper.Test.GameElements
{
    /// <summary>
    /// Test class of the value field
    /// </summary>
    [TestFixture]
    public class ValueField_Test
    {
        [Test]
        public void GetDisplayesValue_Called_ReturnCorrectValue()
        {
            ValueField field = new ValueField();
            Assert.AreEqual(field.GetDisplayesValue(), Configuration.HiddenFieldValue);
            field.IsRevealed = true;
            Assert.AreEqual(field.GetDisplayesValue(), 0);
        }
    }
}
