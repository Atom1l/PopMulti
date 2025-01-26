using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

public class ScoreHub : Hub
{
    private const int ScoreLimit = 50;
    private static ConcurrentDictionary<string, int> Scores = new ConcurrentDictionary<string, int>();

    public async Task UpdateScore(string university, int newScore)
    {
        // Update the score for the university
        Scores[university] = newScore;

        // Broadcast the updated score to all clients
        await Clients.All.SendAsync("ReceiveScoreUpdate", university, Scores[university]);

        // Check if the score limit is reached
        if (Scores[university] >= ScoreLimit)
        {
            await Clients.All.SendAsync("ScoreLimitReached", university);
        }
    }
}
