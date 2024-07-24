using NUnit.Framework;
using ShippingChargesApp;

namespace ShippingChargesAppTests
{
    public class Tests
    {
        ShippingCharges shippingCharges { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            // Initialize with default values, these will be changed in individual tests
            shippingCharges = new ShippingCharges(1m, 100);
        }

        [Test]
        public void TestCalculateChargesBelow2kg()
        {
            // Arrange
            shippingCharges = new ShippingCharges(1.5m, 750);
            decimal expectedResult = 2.20m; // 1.10 * 2 segments

            // Act
            var result = shippingCharges.CalculateCharges();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateCharges2To6kg()
        {
            // Arrange
            shippingCharges = new ShippingCharges(4m, 1200);
            decimal expectedResult = 6.60m; // 2.20 * 3 segments

            // Act
            var result = shippingCharges.CalculateCharges();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateCharges6To10kg()
        {
            // Arrange
            shippingCharges = new ShippingCharges(8m, 2700);
            decimal expectedResult = 22.20m; // 3.70 * 5 segments

            // Act
            var result = shippingCharges.CalculateCharges();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateChargesAbove10kg()
        {
            // Arrange
            shippingCharges = new ShippingCharges(15m, 3200);
            decimal expectedResult = 33.60m; // 4.80 * 7 segments

            // Act
            var result = shippingCharges.CalculateCharges();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateChargesExactlyOnSegmentBoundary()
        {
            // Arrange
            shippingCharges = new ShippingCharges(1m, 500);
            decimal expectedResult = 1.10m; // 1.10 * 1 segment

            // Act
            var result = shippingCharges.CalculateCharges();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }

        [Test]
        public void TestCalculateChargesJustOverSegmentBoundary()
        {
            // Arrange
            shippingCharges = new ShippingCharges(1m, 501);
            decimal expectedResult = 2.20m; // 1.10 * 2 segments

            // Act
            var result = shippingCharges.CalculateCharges();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.TypeOf<decimal>());
        }
    }
}