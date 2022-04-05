using Domain.Dictionary.Services;
using Domain.Dictionary.ValueObjects;
using Xunit;

namespace Domain.UnitTests;

public class WordCombinationFinderTests
{
    [Fact]
    public void Find_ShouldFindCombinations_WhenSuccessful()
    {
        // Arrange
        var lines = new List<string>
        {
            "foo", "bar", "fo", "obar"
        };
        var word = new Word("foobar", new List<PartCombination>());
        var parts = lines.Select(line => new Part(line));
        
        // Act
        var combinations = WordCombinationsFinder.Find(word, parts.ToList()).ToList();
        
        // Assert
        Assert.Equal(2, combinations.Count);
        Assert.Equal(word.Content, combinations[0].Combine());
        Assert.Equal(word.Content, combinations[1].Combine());
    }
}