using Domain.Dictionary.Entities;
using Domain.Dictionary.Services;
using Domain.Dictionary.ValueObjects;

namespace Domain.Dictionary.Factories;

public static class WordDictionaryFactory
{
    public static WordDictionary Create(List<string> lines, int lengthOfWords)
    {
        var words = FindDistinctWords(lines, lengthOfWords);
        var parts = FindDistinctParts(lines, lengthOfWords);

        var wordsWithCombinations = new List<Word>();
        foreach (var word in words)
        {
            var combinations = WordCombinationsFinder.Find(word, parts);
            wordsWithCombinations.Add(word with {Combinations = combinations});
        }

        return new WordDictionary(Guid.NewGuid(), wordsWithCombinations, parts);
    }

    private static IEnumerable<Word> FindDistinctWords(IEnumerable<string> lines, int lengthOfWords)
    {
        return lines.Where(line => line.Length == lengthOfWords)
            .Select(line => new Word(line, new List<PartCombination>())).Distinct();
    }

    private static List<Part> FindDistinctParts(IEnumerable<string> lines, int lengthOfWords)
    {
        return lines.Where(line => line.Length != lengthOfWords).Select(line => new Part(line)).Distinct().ToList();
    }
}