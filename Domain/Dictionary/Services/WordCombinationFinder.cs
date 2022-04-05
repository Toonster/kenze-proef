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

            foreach (var secondPart in parts)
            {
                var combination = new PartCombination(new List<Part> {firstPart, secondPart});
                if (!word.IsCombinationCorrectLength(combination))
                {
                    continue;
                }

                if (!word.Content.Contains(secondPart.Content))
                {
                    continue;
                }

                if (word.IsValidCombination(combination))
                {
                    combinations.Add(combination);
                }
            }
        }

        return combinations;
    }
}