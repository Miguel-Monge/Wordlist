namespace Wordlist;

public record CompoundWord(string First, string Second, string Result)
{
    public override string ToString() => $"{First} + {Second} => {Result}";
}

public class CompoundWordFinder
{
    private const int TargetLength = 6;

    public IEnumerable<CompoundWord> Find(IReadOnlySet<string> words)
    {
        var sixLetterWords = words
            .Where(w => w.Length == TargetLength)
            .OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

        foreach (var word in sixLetterWords)
        {
            for (var split = 1; split < TargetLength; split++)
            {
                var first = word[..split];
                var second = word[split..];
                if (words.Contains(first) && words.Contains(second))
                {
                    yield return new CompoundWord(first, second, word);
                    break;
                }
            }
        }
    }
}
