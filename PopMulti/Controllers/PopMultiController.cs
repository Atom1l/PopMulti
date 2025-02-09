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
        public IActionResult PopResult() // /PopMulti/PopResult //
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            return View(model);
        }
        public IActionResult PopBigResult() // /PopMulti/PopBigResult //
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            return View(model);
        }

        // ResetPage //
        [HttpGet]
        public IActionResult PopReset() // /PopMulti/PopReset //
        {
            return View();
        }
        [HttpPost]
        public IActionResult PopReset(int id)
        {
            var model = _db.PopMultiDB.FirstOrDefault(pop => pop.Id == id);
            if(model != null) // To Reset the score of each universities //
            {
                model.KMUTT = 0;
                model.SU = 0;
                model.SWU = 0;
            }
            _db.SaveChanges();
            
            return RedirectToAction("PopMulti");
        }

        // KMUTTPOP (GET) //
        public async Task<IActionResult> KMUTTPOP()
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            await _hubContext.Clients.All.SendAsync("Redirect");
            return View(model);
        }

        // KMUTTPOP (POST) //
        [HttpPost]
        public async Task<IActionResult> KMUTTPOP(int kmuttbtn)
        {
            var record = _db.PopMultiDB.FirstOrDefault();
            if (record != null)
            {
                record.KMUTT += 1;
                _db.SaveChanges();

                // Broadcast the updated score for KMUTT to all connected clients(SU,SWU) //
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", "KMUTT", record.KMUTT);

                // Check if the score for KMUTT has reached the limit //
                const int ScoreLimit = 20;
                if (record.KMUTT >= ScoreLimit)
                {
                    // Notify all clients that the KMUTT score limit has been reached //
                    // Then proceed to navigate all the page to PopResult page //
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

                // Same as KMUTT method //
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", "SU", record.SU);

                const int ScoreLimit = 20;
                if (record.SU >= ScoreLimit)
                {
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

                // Same as KMUTT,SU method //
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", "SWU", record.SWU);

                const int ScoreLimit = 20; 
                if (record.SWU >= ScoreLimit)
                {
                    await _hubContext.Clients.All.SendAsync("ScoreLimitReached", "SU");
                }
            }
            return Ok();
        }
    }
}
