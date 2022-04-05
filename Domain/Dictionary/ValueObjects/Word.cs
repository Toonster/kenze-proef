namespace Domain.Dictionary.ValueObjects;

public record Word(string Content, IEnumerable<PartCombination> Combinations)
{
    public bool IsValidCombination(PartCombination combination)
    {
        var word = combination.Combine();

        return word.Equals(Content);
    }
    
    public bool IsValidCombination(IEnumerable<Part> combination)
    {
        var word = combination.Aggregate("", (current, part) => current + part.Content);

        return word.Equals(Content);
    }

    public bool IsCombinationCorrectLength(IEnumerable<Part> combination)
    {
        return Content.Length == combination.Sum(part => part.Content.Length);
    }

    public bool Contains(Part part)
    {
        return Content.Contains(part.Content);
    }
};