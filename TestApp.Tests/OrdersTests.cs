using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = new string[0];

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] { "apple 1.99 3", "banana 3.75 1", "orange 0.99 2"};

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98"));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] 
        { 
            "apple 0.5 1", 
            "banana 1.5000000006 2", 
            "orange 1.98000000000009 1", 
            "apple 1.99 2", 
            "banana 1.0 1" 
        };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 5.97{Environment.NewLine}banana -> 3.00{Environment.NewLine}orange -> 1.98"));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] 
        { 
            "apple 1 0.5", 
            "banana 1.5 2.5", 
            "orange 1.98 1", 
            "apple 1 0.5", 
            "banana 0.75 3.25" 
        };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 1.00{Environment.NewLine}banana -> 4.31{Environment.NewLine}orange -> 1.98"));
    }
}
