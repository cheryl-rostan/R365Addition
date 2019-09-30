using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365AdditionUtility;

namespace R365AdditionalUtilityTest
{
    [TestClass]
    public class AddEvaluatorTest
    {
        [TestMethod]
        public void RequirementOne_OneValue()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "20";

            /// Act
            var total = evaluator.RequirementOne(input);

            /// Assert
            Assert.AreEqual(20, total);
        }

        [TestMethod]
        public void RequirementOne_AddTwoNumbers()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "1,5000";

            /// Act
            var total = evaluator.RequirementOne(input);

            /// Assert
            Assert.AreEqual(5001, total);
        }

        [TestMethod]
        public void RequirementOne_AddBlank()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "";

            /// Act
            var total = evaluator.RequirementOne(input);

            /// Assert
            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void RequirementOne_AddMoreThanTwoValues()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "5,5,5,5";

            /// Act
            var total = evaluator.RequirementOne(input);

            /// Assert
            Assert.AreEqual(10, total);
        }

        [TestMethod]
        public void RequirementOne_AddNumbersMixedWithText()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "5,tytyt";

            /// Act
            var total = evaluator.RequirementOne(input);

            /// Assert
            Assert.AreEqual(5, total);
        }

        [TestMethod]
        public void RequirementTwo_AddManyNumbers()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5";

            /// Act
            var total = evaluator.RequirementTwo(input);

            /// Assert
            Assert.AreEqual(200, total);
        }

        [TestMethod]
        public void RequirementThree_AddNumbersWithSecondDeliminatorNewLine()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "1\n2,3";

            /// Act
            var total = evaluator.RequirementThree(input);

            /// Assert
            Assert.AreEqual(6, total);
        }

        [TestMethod]
        public void RequirementThree_AddNumbersWithOnlyDeliminatorNewLine()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "1\n2\n3";

            /// Act
            var total = evaluator.RequirementThree(input);

            /// Assert
            Assert.AreEqual(6, total);
        }

        [TestMethod]
        public void RequirementThree_AddNumbersWithOnlyCommaDeliminator()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "1,2,3";

            /// Act
            var total = evaluator.RequirementThree(input);

            /// Assert
            Assert.AreEqual(6, total);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RequirementFour_NegativeValuesIncluded()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "-1,3,-4";

            /// Act
            var total = evaluator.RequirementFour(input);

            /// Assert
            Assert.Fail();
        }

        [TestMethod]
        public void RequirementFour_NegativeValuesNOTIncluded()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "1,3,4";

            /// Act
            var total = evaluator.RequirementFour(input);

            /// Assert
            Assert.AreEqual(8, total);
        }

        [TestMethod]
        public void RequirementFive_IgnoreGT1000()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "2,1001,6";

            /// Act
            var total = evaluator.RequirementFive(input);

            /// Assert
            Assert.AreEqual(8, total);
        }

        [TestMethod]
        public void RequirementFive_AcceptLE1000()
        { 
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "2,1000,6";

            /// Act
            var total = evaluator.RequirementFive(input);

            /// Assert
            Assert.AreEqual(1008, total);
        }

        [TestMethod]
        public void RequirementSix_AlternativeSingleCharacterFormat()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "//;\n2;5";

            /// Act
            var total = evaluator.RequirementSix(input);

            /// Assert
            Assert.AreEqual(7, total);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void RequirementSix_AlternativeManyCharacterFormat()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "//;|\n2;5";

            /// Act
            var total = evaluator.RequirementSix(input);

            /// Assert
        }

        [TestMethod]
        public void RequirementSix_PreviousFormat()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "2,5,3";

            /// Act
            var total = evaluator.RequirementSix(input);

            /// Assert
            Assert.AreEqual(10, total);
        }

        [TestMethod]
        public void RequirementSeven_AlternativeManyCharacterFormat()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "//[***]\n11***22***33";

            /// Act
            var total = evaluator.RequirementSeven(input);

            /// Assert
            Assert.AreEqual(66, total);
        }

        [TestMethod]
        public void RequirementSeven_PreviousFormat()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "2,5,3";

            /// Act
            var total = evaluator.RequirementSeven(input);

            /// Assert
            Assert.AreEqual(10, total);
        }

        [TestMethod]
        public void RequirementEight_ManyAlternativeManyCharacterFormats()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "//[*][!!][r9r]\n11r9r22*33!!44";

            /// Act
            var total = evaluator.RequirementEight(input);

            /// Assert
            Assert.AreEqual(110, total);
        }

        [TestMethod]
        public void RequirementEight_PreviousFormat()
        {
            /// Arrange
            AddEvaluator evaluator = new AddEvaluator();
            var input = "2,5,3";

            /// Act
            var total = evaluator.RequirementEight(input);

            /// Assert
            Assert.AreEqual(10, total);
        }

    }
}
