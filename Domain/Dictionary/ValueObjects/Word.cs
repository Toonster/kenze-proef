namespace Domain.Dictionary.ValueObjects;

public record Word(string Content, IEnumerable<PartCombination> Combinations)
{
    public bool IsValidCombination(PartCombination combination)
    {
        var word = combination.Combine();

        return word.Equals(Content);
    }

    public bool IsCombinationCorrectLength(PartCombination combination)
    {
        return Content.Length == combination.TotalLength();
    }
};