# Wordlist

Console application that finds 6-letter words formed by concatenating two other words from a word list.

**Example:** `albums` is valid because `al`, `bums`, and `albums` are all in the list.

## Output

```
al + bums => albums
bar + ely => barely
be + foul => befoul
con + vex => convex
here + by => hereby
jig + saw => jigsaw
tail + or => tailor
we + aver => weaver
...
```

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Project Structure

```
Wordlist/
├── Wordlist/                 # Main application
│   ├── Program.cs
│   ├── WordlistLoader.cs
│   ├── CompoundWordFinder.cs
│   └── media/wordlist.txt
├── Wordlist.Tests/           # Unit tests (xUnit)
```
