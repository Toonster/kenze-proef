using System.Collections;
using Domain.Dictionary.ValueObjects;

namespace Domain.Dictionary.Services;

public static class WordCombinationsFinder
{
    public static IEnumerable<PartCombination> Find(Word word, List<Part> parts)
    {
        var combinations = new List<PartCombination>();
        foreach (var firstPart in parts)
        {
            if (!word.Content.Contains(firstPart.Content))
            {
                continue;
            }
            
            var combination = new List<Part>{ firstPart };
            foreach (var secondPart in parts)
            {
                if (combination.Count > 1)
                {
                    RemoveLastPart(combination);
                }
                
                combination.Add(secondPart);

                if (!word.Contains(secondPart) || !word.IsCombinationCorrectLength(combination))
                {
                    continue;
                }

                if (word.IsValidCombination(combination))
                {
                    combinations.Add(new PartCombination(combination.Select(part => new Part(part.Content)).ToList()));
                }
            }
        }

        return combinations;
    }

    private static void RemoveLastPart(IList combination)
    {
        combination.RemoveAt(combination.Count - 1);
    }
}