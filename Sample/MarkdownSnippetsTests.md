# Linq Explained

## Given the following record

<!-- snippet: record -->
<a id='snippet-record'></a>
```cs
public record Player(string Name, string Team, int Score);
```
<sup><a href='/Sample/MarkdownSnippetsTests.cs#L40-L44' title='Snippet source file'>snippet source</a> | <a href='#snippet-record' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

## And a collection of items

<!-- snippet: collection -->
<a id='snippet-collection'></a>
```cs
var players = new List<Player>
{
    new(Name: "Alex", Team: "Team A", Score: 10),
    new(Name: "Anna", Team: "Team A", Score: 20),
    new(Name: "Luke", Team: "Team L", Score: 60),
    new(Name: "Lucy", Team: "Team L", Score: 40),
};
```
<sup><a href='/Sample/MarkdownSnippetsTests.cs#L10-L20' title='Snippet source file'>snippet source</a> | <a href='#snippet-collection' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Can be queried with linq using

<!-- snippet: query -->
<a id='snippet-query'></a>
```cs
var scores =
    from player in players
    group player by player.Team
    into playerGroup
    select new
    {
        Team = playerGroup.Key,
        BestScore = playerGroup.Max(x => x.Score),
        TotakScore = playerGroup.Sum(x => x.Score),
    };
```
<sup><a href='/Sample/MarkdownSnippetsTests.cs#L22-L35' title='Snippet source file'>snippet source</a> | <a href='#snippet-query' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Will result in the follow data

<!-- snippet: MarkdownSnippetsTests.MySnippet.verified.txt -->
<a id='snippet-MarkdownSnippetsTests.MySnippet.verified.txt'></a>
```txt
[
  {
    Team: Team A,
    BestScore: 20,
    TotakScore: 30
  },
  {
    Team: Team L,
    BestScore: 60,
    TotakScore: 100
  }
]
```
<sup><a href='/Sample/MarkdownSnippetsTests.MySnippet.verified.txt#L1-L12' title='Snippet source file'>snippet source</a> | <a href='#snippet-MarkdownSnippetsTests.MySnippet.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
