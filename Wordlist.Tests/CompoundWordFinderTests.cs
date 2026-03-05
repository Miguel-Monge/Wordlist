using Xunit;

namespace Wordlist.Tests;

public class CompoundWordFinderTests
{
    [Fact]
    public void Find_ReturnsCompoundWords()
    {
        var words = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "al", "bums", "albums"
        };
        var finder = new CompoundWordFinder();
        var results = finder.Find(words).ToList();
        Assert.Single(results);
        Assert.Equal("al", results[0].First);
        Assert.Equal("bums", results[0].Second);
        Assert.Equal("albums", results[0].Result);
    }

    [Fact]
    public void Find_FormatsOutputCorrectly()
    {
        var words = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "al", "bums", "albums"
        };
        var finder = new CompoundWordFinder();
        var result = finder.Find(words).First();
        Assert.Equal("al + bums => albums", result.ToString());
    }

    [Fact]
    public void Find_ReturnsEmpty_WhenNoCompoundWords()
    {
        var words = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "albums", "other", "words"
        };
        var finder = new CompoundWordFinder();
        var results = finder.Find(words).ToList();
        Assert.Empty(results);
    }

    [Fact]
    public void Find_ReturnsOnlyFirstValidSplit()
    {
        var words = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "a", "l", "bums", "al", "bums", "albums"
        };
        var finder = new CompoundWordFinder();
        var results = finder.Find(words).ToList();
        Assert.Single(results);
    }

    [Fact]
    public void Find_OrdersResultsAlphabetically()
    {
        var words = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "bar", "ely", "barely", "al", "bums", "albums"
        };
        var finder = new CompoundWordFinder();
        var results = finder.Find(words).ToList();
        Assert.Equal("albums", results[0].Result);
        Assert.Equal("barely", results[1].Result);
    }
}
