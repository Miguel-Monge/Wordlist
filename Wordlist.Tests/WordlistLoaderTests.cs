using Xunit;

namespace Wordlist.Tests;

public class WordlistLoaderTests
{
    [Fact]
    public void Load_ReadsWordsFromFile()
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllLines(path, ["al", "bums", "albums"]);
            var loader = new WordlistLoader();
            var words = loader.Load(path);
            Assert.Equal(3, words.Count);
            Assert.True(words.Contains("al"));
            Assert.True(words.Contains("bums"));
            Assert.True(words.Contains("albums"));
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void Load_IsCaseInsensitive()
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllLines(path, ["Al", "bums", "albums"]);
            var loader = new WordlistLoader();
            var words = loader.Load(path);
            Assert.True(words.Contains("al"));
            Assert.True(words.Contains("AL"));
        }
        finally
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void Load_TrimsWhitespace()
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllLines(path, ["  al  ", "bums"]);
            var loader = new WordlistLoader();
            var words = loader.Load(path);
            Assert.True(words.Contains("al"));
        }
        finally
        {
            File.Delete(path);
        }
    }
}
