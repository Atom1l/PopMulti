using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PopMulti.Data;
using PopMulti.Models.PopModel;

namespace PopMulti.Controllers
{
    public class PopMultiController : Controller
    {
        private readonly PopMultiDBContext _db;
        private readonly IHubContext<ScoreHub> _hubContext;

        public PopMultiController(PopMultiDBContext db, IHubContext<ScoreHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }

        // MainPage //
        public IActionResult PopMulti()
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            if (model == null)
            {
                model = new PopMultiModel
                {
                    KMUTT = 0,
                    SU = 0,
                    SWU = 0
                };
                _db.PopMultiDB.Add(model);
                _db.SaveChanges();
            }
            return View(model);
        }

        // ResultPage //
        public IActionResult PopResult()
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            return View(model);
        }

        // KMUTTPOP (GET)
        public IActionResult KMUTTPOP()
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            return View(model);
        }

        // KMUTTPOP (POST)
        [HttpPost]
        public async Task<IActionResult> KMUTTPOP(int kmuttbtn)
        {
            var record = _db.PopMultiDB.FirstOrDefault();
            if (record != null)
            {
                record.KMUTT += 1;
                _db.SaveChanges();

                // Broadcast the updated score for KMUTT to all connected clients
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", "KMUTT", record.KMUTT);

                // Check if the score for KMUTT has reached the limit
                const int ScoreLimit = 50; // Adjust the limit as needed
                if (record.KMUTT >= ScoreLimit)
                {
                    // Notify all clients that the KMUTT score limit has been reached
                    await _hubContext.Clients.All.SendAsync("ScoreLimitReached", "KMUTT");
                }
            }
            return Ok(new { success = true });
        }


        // SUPOP //
        public IActionResult SUPOP()
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SUPOP(int subtn)
        {
            var record = _db.PopMultiDB.FirstOrDefault();
            if (record != null)
            {
                record.SU += 1;
                _db.SaveChanges();

                // Broadcast the updated score for KMUTT to all connected clients
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", "SU", record.SU);

                // Check if the score for KMUTT has reached the limit
                const int ScoreLimit = 50; // Adjust the limit as needed
                if (record.SU >= ScoreLimit)
                {
                    // Notify all clients that the KMUTT score limit has been reached
                    await _hubContext.Clients.All.SendAsync("ScoreLimitReached", "SU");
                }
            }
            return Ok();
        }

        // SWUPOP //
        public IActionResult SWUPOP()
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SWUPOP(int swubtn)
        {
            var record = _db.PopMultiDB.FirstOrDefault();
            if (record != null)
            {
                record.SWU += 1;
                _db.SaveChanges();

                // Broadcast the updated score for KMUTT to all connected clients
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", "SWU", record.SWU);

                // Check if the score for KMUTT has reached the limit
                const int ScoreLimit = 50; // Adjust the limit as needed
                if (record.SWU >= ScoreLimit)
                {
                    // Notify all clients that the KMUTT score limit has been reached
                    await _hubContext.Clients.All.SendAsync("ScoreLimitReached", "SU");
                }
            }
            return Ok();
        }
    }
}
