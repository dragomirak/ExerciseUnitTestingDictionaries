using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new() { "", "", ""};

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "a" };
        string expected = "a -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "aaabccc", "aabb", "ac" };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("a -> 6");
        sb.AppendLine("b -> 3");
        sb.AppendLine("c -> 4");

        string expected = sb.ToString().Trim();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "@@!!!b%%%", "!!bb", "!%" };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("@ -> 2");
        sb.AppendLine("! -> 6");
        sb.AppendLine("b -> 3");
        sb.AppendLine("% -> 4");


        string expected = sb.ToString().Trim();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithUpperCaseAndDigitsCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "aaabccc", "aabb", "ac", "ABBC123", "CCCBA323" };

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("a -> 6");
        sb.AppendLine("b -> 3");
        sb.AppendLine("c -> 4");
        sb.AppendLine("A -> 2");
        sb.AppendLine("B -> 3");
        sb.AppendLine("C -> 4");
        sb.AppendLine("1 -> 1");
        sb.AppendLine("2 -> 2");
        sb.AppendLine("3 -> 3");

        string expected = sb.ToString().Trim();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
