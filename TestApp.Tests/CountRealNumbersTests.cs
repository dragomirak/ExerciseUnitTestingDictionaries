using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { 5 };
        string expected = "5 -> 1";

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { 1, 1, 5, 7, 7, 7 };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("1 -> 2");
        sb.AppendLine("5 -> 1");
        sb.AppendLine("7 -> 3");

        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { -1, 1, 1, 5, 7, 7, -7, -7 };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("-7 -> 2");
        sb.AppendLine("-1 -> 1");
        sb.AppendLine("1 -> 2");
        sb.AppendLine("5 -> 1");
        sb.AppendLine("7 -> 2");
        
        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { 1, -2, 1, 0, 0, 1 };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("-2 -> 1");
        sb.AppendLine("0 -> 2");
        sb.AppendLine("1 -> 3");
        
        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
