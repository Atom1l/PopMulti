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
            return View();
        }

        // ResultPage //
        public IActionResult PopResult()
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            return View(model);
        }

        // KMUTTPOP //
        public IActionResult KMUTTPOP()
        {
            var model = _db.PopMultiDB.FirstOrDefault();
            if(model == null)
            {
                model = new PopMultiModel();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> KMUTTPOP(int kmuttbtn)
        {
            var record = _db.PopMultiDB.FirstOrDefault();
            if (record != null)
            {
                record.KMUTT += 1;
                _db.SaveChanges();

                // Broadcast the updated score to all connected clients
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", record.KMUTT);
            }
            return Ok();
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

                // Broadcast the updated score to all connected clients
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", record.SU);
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

                // Broadcast the updated score to all connected clients
                await _hubContext.Clients.All.SendAsync("ReceiveScoreUpdate", record.SWU);
            }
            return Ok();
        }
    }
}
