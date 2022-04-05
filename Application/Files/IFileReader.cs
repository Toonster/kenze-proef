namespace Application.Files;

public interface IFileReader
{
    IEnumerable<string> ReadLines(string filePath);
}