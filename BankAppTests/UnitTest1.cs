using NUnit.Framework;
using BankApp;

namespace BankAppTests
{
    public class Tests
    {
        BankCharges bankCharges { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            // Initialize with default values, these will be changed in individual tests
            bankCharges = new BankCharges(1000m, 15);
        }

        [Test]
        public void TestCalculateCheckFeesLessThan20()
        {
            // Arrange
            decimal expectedResult = 1.50m;

            // Act
            var result = bankCharges.CalculateCheckFees();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateCheckFees20To39()
        {
            // Arrange
            bankCharges = new BankCharges(1000m, 30);
            decimal expectedResult = 2.40m;

            // Act
            var result = bankCharges.CalculateCheckFees();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateCheckFees40To59()
        {
            // Arrange
            bankCharges = new BankCharges(1000m, 50);
            decimal expectedResult = 3.00m;

            // Act
            var result = bankCharges.CalculateCheckFees();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateCheckFees60OrMore()
        {
            // Arrange
            bankCharges = new BankCharges(1000m, 70);
            decimal expectedResult = 2.80m;

            // Act
            var result = bankCharges.CalculateCheckFees();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateServiceChargesBalanceAbove400()
        {
            // Arrange
            decimal expectedResult = 11.50m;

            // Act
            var result = bankCharges.CalculateServiceCharges();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateServiceChargesBalanceBelow400()
        {
            // Arrange
            bankCharges = new BankCharges(350m, 15);
            decimal expectedResult = 26.50m;

            // Act
            var result = bankCharges.CalculateServiceCharges();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }
    }
}