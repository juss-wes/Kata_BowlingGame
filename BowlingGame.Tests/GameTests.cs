using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestGutterGame()
        {
            // Arrange
            var game = new Game();

            // Act
            for (var i = 0; i < 20; i++)
            {
                game.Roll(0);
            }

            // Assert
            Assert.IsTrue(game.Score() == 0);
        }

        [TestMethod]
        public void TestAllOnes()
        {
            // Arrange
            var game = new Game();

            // Act
            for (var i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            // Assert
            Assert.IsTrue(game.Score() == 20);
        }

        [TestMethod]
        public void TestOneSpare()
        {
            // Arrange
            var game = new Game();

            // Act
            game.Roll(5);
            game.Roll(5); // Spare
            game.Roll(3);
            for (var i = 0; i < 17; i++)
            {
                game.Roll(0);
            }

            // Assert
            Assert.IsTrue(game.Score() == 16);
        }

        [TestMethod]
        public void TestOneStrike()
        {
            // Arrange
            var game = new Game();

            // Act
            game.Roll(10); // Strike
            game.Roll(3);
            game.Roll(4);
            for (var i = 0; i < 16; i++)
            {
                game.Roll(0);
            }

            // Assert
            Assert.IsTrue(game.Score() == 24);
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            // Arrange
            var game = new Game();

            // Act
            for (var i = 0; i < 12; i++)
            {
                game.Roll(10);
            }

            // Assert
            Assert.IsTrue(game.Score() == 300);
        }
    }
}
