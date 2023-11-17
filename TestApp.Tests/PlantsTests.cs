using NUnit.Framework;

using System;
using System.Numerics;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = new string[0];

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.Empty);
    }


    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = new string[] { "kiwi" };

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo($"Plants with 4 letters:{Environment.NewLine}kiwi"));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = new string[]
        {
            "lemon",
            "orange",
            "apple",
            "papaya"
        };

        string expected = $"Plants with 5 letters:{Environment.NewLine}lemon{Environment.NewLine}apple"+
            $"{Environment.NewLine}Plants with 6 letters:{Environment.NewLine}orange{Environment.NewLine}papaya";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] plants = new string[]
        {
            "leMon",
            "orangE",
            "APPLE",
            "Papaya"
        };

        string expected = $"Plants with 5 letters:{Environment.NewLine}leMon{Environment.NewLine}APPLE" +
            $"{Environment.NewLine}Plants with 6 letters:{Environment.NewLine}orangE{Environment.NewLine}Papaya";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
