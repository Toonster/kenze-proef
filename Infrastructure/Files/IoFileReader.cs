using Application.Files;

namespace Infrastructure.Files;

public class IoFileReader : IFileReader
{
    public IEnumerable<string> ReadLines(string filePath)
    {
        return File.ReadLines(filePath);
    }
}