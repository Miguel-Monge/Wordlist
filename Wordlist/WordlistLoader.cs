namespace Wordlist;

public class WordlistLoader
{
    public IReadOnlySet<string> Load(string path)
    {
        var words = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var line in File.ReadLines(path))
        {
            var word = line.Trim();
            if (!string.IsNullOrEmpty(word))
                words.Add(word);
        }
        return words;
    }
}
