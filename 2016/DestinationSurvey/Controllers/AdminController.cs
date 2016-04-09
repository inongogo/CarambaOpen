using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarambaOpen.DbContexts;
using CarambaOpen.Extensions;
using CarambaOpen.Models;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace CarambaOpen.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AdminController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("admin/cleardone")]
        public IActionResult ClearDone()
        {
            HttpContext.Response.Cookies.Delete("Done", new CookieOptions {Expires = DateTime.Now.AddDays(-1)});

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("admin/showallranks")]
        public IActionResult ShowAllRanks()
        {
            IList<Ranking> rankings = new List<Ranking>();

            var polls = _dbContext.Polls
                .Include(a => a.User)
                .Include(p => p.Answers)
                .ThenInclude(x => x.Question);

            foreach (var poll in polls)
            {
                rankings.Add(Ranking.GetRanking(poll));
            }

            return View("ShowAllRanks", rankings);
        }

        [HttpGet("admin/showallresults")]
        public IActionResult ShowAllResults()
        {
            var polls = _dbContext.Polls
                .Include(a => a.User)
                .Include(p => p.Answers)
                .ThenInclude(x => x.Question);

            return View("ShowAllResults", polls.ToList());
        }
    }
}