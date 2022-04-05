using Domain.Common.Entities;
using Domain.Dictionary.ValueObjects;

namespace Domain.Dictionary.Entities;

public class WordDictionary : Entity
{
    public IEnumerable<Word> Words { get; }
    public IEnumerable<Part> Parts { get; }
    public WordDictionary(Guid id, IEnumerable<Word> words, IEnumerable<Part> parts) : base(id)
    {
        Words = words;
        Parts = parts;
    }
    public void PrintWords()
    {
        foreach (var (content, combinations) in Words.Where(word => word.Combinations.Any()))
        {
            foreach (var combination in combinations)
            {
                Console.WriteLine(combination.Parts.Aggregate("", (current, part) =>  current + (string.IsNullOrWhiteSpace(current) ? "" : "+") + part.Content) + "=" + content);
            }
        }
    }
}