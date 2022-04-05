namespace Domain.Dictionary.ValueObjects;

public record PartCombination(IEnumerable<Part> Parts)
{
    public int TotalLength()
    {
        return Parts.Sum(part => part.Content.Length);
    }

    public string Combine()
    {
        return Parts.Aggregate("", (current, part) => current + part.Content);
    }
};