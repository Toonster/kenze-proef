namespace Domain.Dictionary.ValueObjects;

public record PartCombination(List<Part> Parts)
{
    public int TotalLength()
    {
        return Parts.Sum(part => part.Content.Length);
    }

    public string Combine()
    {
        return Parts.Aggregate("", (current, part) => current + part.Content);
    }

    public PartCombination AddPart(Part part)
    {
        Parts.Add(part);
        
        return new PartCombination(Parts);
    }

    public PartCombination RemoveLastPart()
    {
        Parts.RemoveAt(Parts.Count - 1);
        
        return new PartCombination(Parts);
    }
}