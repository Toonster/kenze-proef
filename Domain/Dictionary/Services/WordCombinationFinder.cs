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

            var combination = new PartCombination(new List<Part> {firstPart});
            foreach (var secondPart in parts)
            {
                combination = combination.AddPart(secondPart);
                if (!word.IsCombinationCorrectLength(combination) || !word.Content.Contains(secondPart.Content))
                {
                    combination.RemoveLastPart();
                    continue;
                }

                if (word.IsValidCombination(combination))
                {
                    combinations.Add(new PartCombination(combination.Parts.Select(part => new Part(part.Content)).ToList()));
                }
                
                combination = combination.RemoveLastPart();
            }
        }

        return combinations;
    }
}