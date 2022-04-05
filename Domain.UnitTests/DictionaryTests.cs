using Domain.Dictionary.Factories;
using Domain.Dictionary.ValueObjects;
using Xunit;

namespace Domain.UnitTests;

public class DictionaryTests
{
    [Fact]
    public void Create_ShouldFindWordsWithCorrectLength_WhenSuccessful()
    {
        // Arrange
        var lines = new List<string>
        {
            "zambia", "foobar", "qu", "iny", "foo", "bar"
        };
        const int wordLength = 6;

        // Act
        var dictionary = WordDictionaryFactory.Create(lines, wordLength);

        // Assert
        var words = dictionary.Words.ToList();
        Assert.Contains(words, word => word.Content.Equals(lines[0]));
        Assert.Contains(words, word => word.Content.Equals(lines[1]));
        Assert.DoesNotContain(words, word => word.Content.Equals(lines[2]));
        Assert.DoesNotContain(words, word => word.Content.Equals(lines[3]));
    }

    [Fact]
    public void Create_ShouldFindPartsWithoutCorrectLength_WhenSuccessful()
    {
        // Arrange
        var lines = new List<string>
        {
            "zambia", "foobar", "qu", "iny"
        };
        const int wordLength = 6;

        // Act
        var dictionary = WordDictionaryFactory.Create(lines, wordLength);

        // Assert
        var parts = dictionary.Parts.ToList();
        Assert.DoesNotContain(parts, word => word.Equals(new Part(lines[0])));
        Assert.DoesNotContain(parts, word => word.Equals(new Part(lines[1])));
        Assert.Contains(parts, word => word.Equals(new Part(lines[2])));
        Assert.Contains(parts, word => word.Equals(new Part(lines[3])));
    }

    [Fact]
    public void Create_ShouldFindCombinationOfWord_WhenSuccessful()
    {
        // Arrange
        var lines = new List<string>
        {
            "querer", "foobar", "qu", "fer", "foo", "bar"
        };
        const int wordLength = 6;

        // Act
        var dictionary = WordDictionaryFactory.Create(lines, wordLength);

        // Assert
        var word = dictionary.Words.Single(word => word.Content.Equals(lines[1]));
        var combination = word.Combinations.ToList()[0];
        Assert.Equal(lines[1], combination.Combine());
    }
    
    [Fact]
    public void PrintWords_ShouldPrintCorrectFormat_WhenSuccessful()
    {
        // Arrange
        var lines = new List<string>
        {
            "foobar","foo", "bar"
        };
        const int wordLength = 6;
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        var dictionary = WordDictionaryFactory.Create(lines, wordLength);

        // Assert
        dictionary.PrintWords();
        var correctFormat = lines[1] + "+" + lines[2] + "=" + lines[0] + "\r\n";
        Assert.Equal(correctFormat,stringWriter.ToString());
    }
}