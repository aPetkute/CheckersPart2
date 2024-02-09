using CheckersGameV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerGameV2.Test
{
    [TestClass]
    public class RulesTests
    {
        [TestMethod]
        public void IsInBoard_WithCorrectValues_ShouldReturnTrue()
        {
            //Arange
            var rules = new Rules(8);
            List<Coordinates> input = new List<Coordinates>()
            {
                new(2,3),
                new(3,4),
            };

            //Act
            var result =rules.IsInBoard(input);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInBoard_WithOneIncorrectValue_ShouldReturnFalse()
        {
            //Arange
            var rules = new Rules(8);
            List<Coordinates> input = new List<Coordinates>()
            {
                new(10,3),
                new(3,4),
            };

            //Act
            var result = rules.IsInBoard(input);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod]
        public void IsInBoard_WithTwoIncorrectValue_ShouldReturnFalse()
        {
            //Arange
            var rules = new Rules(8);
            List<Coordinates> input = new List<Coordinates>()
            {
                new(10,3),
                new(10,4),
            };

            //Act
            var result = rules.IsInBoard(input);

            //Assert
            Assert.IsTrue(!result);
        }

        [TestMethod]
        public void IsInRange_WithValidMove_ShouldReturnFalse()
        {
            //Arange
            var rules = new Rules(8);
            Coordinates pieceCoordinates = new(2, 3);
            Coordinates move = new(3, 4);
            char color = 'b';
            Piece piece = new BasicPiece(pieceCoordinates, color);

            //Act
            var result = rules.IsInRange(move, piece);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WasAttack_ValidAttack_ShouldReturnFalse()
        {
            //Arange
            var rules = new Rules(8);
            List<Coordinates> input = new List<Coordinates>()
            {
                new(2,3),
                new(4,5),
            };

            //Act
            var result = rules.WasAttack(input);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WasAttack_InvalidAttack_ShouldReturnFalse()
        {
            //Arange
            var rules = new Rules(8);
            List<Coordinates> input = new List<Coordinates>()
            {
                new(2,3),
                new(3,4),
            };

            //Act
            var result = rules.WasAttack(input);

            //Assert
            Assert.IsTrue(!result);
        }
    }
}
