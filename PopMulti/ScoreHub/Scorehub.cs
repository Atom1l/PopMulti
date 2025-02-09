using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PopMulti.Data;
using PopMulti.Models.PopModel;
using System.Threading.Tasks;

public class ScoreHub : Hub
{
    private readonly PopMultiDBContext _db;
    private const int ScoreLimit = 20;

    public ScoreHub(PopMultiDBContext dbContext)
    {
        _db = dbContext;
    }

    public async Task UpdateScore(string university, int newScore)
    {
        var scoreEntry = await _db.PopMultiDB.FirstOrDefaultAsync();

        if (scoreEntry == null)
        {
            // Create a new entry if none exists
            scoreEntry = new PopMultiModel { KMUTT = 0, SU = 0, SWU = 0 };
            _db.PopMultiDB.Add(scoreEntry);
        }

        // Update the score for the specified university
        switch (university)
        {
            case "KMUTT":
                scoreEntry.KMUTT = newScore;
                break;
            case "SU":
                scoreEntry.SU = newScore;
                break;
            case "SWU":
                scoreEntry.SWU = newScore;
                break;
            default:
                return; // Ignore invalid university names
        }

        await _db.SaveChangesAsync();

        // Broadcast the updated score to all clients
        await Clients.All.SendAsync("ReceiveScoreUpdate", university, newScore);

        // Check if the score limit is reached
        if (newScore >= ScoreLimit)
        {
            await Clients.All.SendAsync("ScoreLimitReached", university);
        }
    }

    public async Task<int> GetScore(string university)
    {
        var scoreEntry = await _db.PopMultiDB.FirstOrDefaultAsync();
        if (scoreEntry == null) return 0;

        // Return the score for the requested university
        return university switch
        {
            "KMUTT" => scoreEntry.KMUTT,
            "SU" => scoreEntry.SU,
            "SWU" => scoreEntry.SWU,
            _ => 0
        };
    }
}
