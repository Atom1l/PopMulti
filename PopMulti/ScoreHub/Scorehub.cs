using Microsoft.AspNetCore.SignalR;

public class ScoreHub : Hub
{
    // Method to broadcast score updates
    public async Task UpdateScore(int newScore)
    {
        await Clients.All.SendAsync("ReceiveScoreUpdate", newScore);
    }
}