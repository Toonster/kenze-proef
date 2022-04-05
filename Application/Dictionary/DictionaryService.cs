using Application.Files;
using Domain.Dictionary.Entities;
using Domain.Dictionary.Factories;

namespace Application.Dictionary;

public class DictionaryService
{
    private readonly IFileReader _fileReader;

    public DictionaryService(IFileReader fileReader)
    {
        _fileReader = fileReader;
    }

    public WordDictionary CreateDictionary(string filePath, int wordLength)
    {
        var lines = _fileReader.ReadLines(filePath).ToList();
        var wordDictionary = WordDictionaryFactory.Create(lines, wordLength);

        return wordDictionary;
    }
    
    
}