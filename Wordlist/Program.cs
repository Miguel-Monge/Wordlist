using Wordlist;

var wordlistPath = Path.Combine(AppContext.BaseDirectory, "media", "wordlist.txt");
if (!File.Exists(wordlistPath))
{
    Console.Error.WriteLine($"Wordlist not found: {wordlistPath}");
    return 1;
}

var loader = new WordlistLoader();
var words = loader.Load(wordlistPath);
var finder = new CompoundWordFinder();

foreach (var compound in finder.Find(words))
{
    Console.WriteLine(compound);
}

return 0;
