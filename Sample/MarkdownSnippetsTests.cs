
// https://github.com/SimonCropp/MarkdownSnippets

[UsesVerify]
public class MarkdownSnippetsTests
{
    [Fact]
    public Task MySnippet()
    {
        #region collection


        var players = new List<Player>
        {
            new(Name: "Alex", Team: "Team A", Score: 10),
            new(Name: "Anna", Team: "Team A", Score: 20),
            new(Name: "Luke", Team: "Team L", Score: 60),
            new(Name: "Lucy", Team: "Team L", Score: 40),
        };


        #endregion

        #region query

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

        #endregion

        return Verifier.Verify(scores);
    }

    #region record

    public record Player(string Name, string Team, int Score);

    #endregion
}