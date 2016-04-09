using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CarambaOpen.DbContexts;
using CarambaOpen.Extensions;
using CarambaOpen.Models;
using CarambaOpen.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;

namespace CarambaOpen.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IList<UserViewModel> _userViewModel = new List<UserViewModel>();

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(bool force = false)
        {
            LoadUsers();

            if (!string.IsNullOrEmpty(HttpContext.Request.Cookies["Done"]) && !force)
            {
                ViewData["Title"] = "Du har redan registrerat dina val...försöker du fuska, eller?";

                return View("Done");
            }

            var vm = new WizardViewModel
            {
                Users = _userViewModel.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name, Selected = x.Id == 0, Disabled = x.Id == 0 }),
                Question1 = _dbContext.Questions.Single(x => x.Order == 1),
                Question2 = _dbContext.Questions.Single(x => x.Order == 2),
                Question3 = _dbContext.Questions.Single(x => x.Order == 3),
                Question4 = _dbContext.Questions.Single(x => x.Order == 4),
                Question5 = _dbContext.Questions.Single(x => x.Order == 5),
                Question6 = _dbContext.Questions.Single(x => x.Order == 6),
                Question7 = _dbContext.Questions.Single(x => x.Order == 7),
            };

            // Alternativ
            // ----------
            // Öland
            // Polen
            // Prag
            // Alicante/Spanien

            return View(vm);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public IActionResult Add(WizardViewModel vm)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == vm.SelectedUserId);
            if (user == null)
            {
                ModelState.AddModelError("UserNotFound", "DEN användaren finns inte hos oss. Tror du på tomten också?");
                ViewData["Message"] = "DEN användaren finns inte hos oss. Tror du på tomten också?";
                vm.Users =
                    _userViewModel.Select(
                        x =>
                            new SelectListItem
                            {
                                Value = x.Id.ToString(),
                                Text = x.Name,
                                Selected = x.Id == 0,
                                Disabled = x.Id == 0
                            });
                return View("Index", vm);
            }

            if (user.Password != vm.Password.Sha256())
            {
                ModelState.AddModelError("InvalidPassword", "Aja baja, fel lösenord...");
                ViewData["Message"] = "Aja baja, fel lösenord...";
                vm.Users =
                    _userViewModel.Select(
                        x =>
                            new SelectListItem
                            {
                                Value = x.Id.ToString(),
                                Text = x.Name,
                                Selected = x.Id == 0,
                                Disabled = x.Id == 0
                            });
                return View("Index", vm);
            }

            var poll = new Poll
            {
                User = user
            };
            vm.Answer1.Question = _dbContext.Questions.Single(x => x.Order == 1);
            vm.Answer2.Question = _dbContext.Questions.Single(x => x.Order == 2);
            vm.Answer3.Question = _dbContext.Questions.Single(x => x.Order == 3);
            vm.Answer4.Question = _dbContext.Questions.Single(x => x.Order == 4);
            vm.Answer5.Question = _dbContext.Questions.Single(x => x.Order == 5);
            vm.Answer6.Question = _dbContext.Questions.Single(x => x.Order == 6);
            vm.Answer7.Question = _dbContext.Questions.Single(x => x.Order == 7);

            poll.Answers = new List<Answer>
            {
                vm.Answer1,
                vm.Answer2,
                vm.Answer3,
                vm.Answer4,
                vm.Answer5,
                vm.Answer6,
                vm.Answer7
            };

            vm.Answer1.Poll = poll;
            vm.Answer2.Poll = poll;
            vm.Answer3.Poll = poll;
            vm.Answer4.Poll = poll;
            vm.Answer5.Poll = poll;
            vm.Answer6.Poll = poll;
            vm.Answer7.Poll = poll;
            vm.Answer1.Question = _dbContext.Questions.Single(x => x.Order == 1);
            vm.Answer2.Question = _dbContext.Questions.Single(x => x.Order == 2);
            vm.Answer3.Question = _dbContext.Questions.Single(x => x.Order == 3);
            vm.Answer4.Question = _dbContext.Questions.Single(x => x.Order == 4);
            vm.Answer5.Question = _dbContext.Questions.Single(x => x.Order == 5);
            vm.Answer6.Question = _dbContext.Questions.Single(x => x.Order == 6);
            vm.Answer7.Question = _dbContext.Questions.Single(x => x.Order == 7);

            _dbContext.Answers.Add(vm.Answer1);
            _dbContext.Answers.Add(vm.Answer2);
            _dbContext.Answers.Add(vm.Answer3);
            _dbContext.Answers.Add(vm.Answer4);
            _dbContext.Answers.Add(vm.Answer5);
            _dbContext.Answers.Add(vm.Answer6);
            _dbContext.Answers.Add(vm.Answer7);

            _dbContext.Polls.Add(poll);
            _dbContext.SaveChanges();

            var rankings = Ranking.GetRanking(poll);
            
            HttpContext.Response.Cookies.Append("Done", "1");

            // Bug: For simplicity, we store the user name in a cookie. Not very secure...
            HttpContext.Response.Cookies.Append("User", user.Password);

            ViewData["Title"] = "Du har nu registrerat dina val";

            return View("Done", vm);
        }

        [HttpGet("Rank")]
        public IActionResult Rank(int pollId = 0)
        {
            string password = HttpContext.Request.Cookies["User"];
            Ranking rankings = null;

            var polls = _dbContext.Polls
                .Include(x => x.Answers)
                .ThenInclude(x => x.Question)
                .Where(x => x.User.Password == password);

            var poll = pollId == 0 ? polls.FirstOrDefault() : polls.Single(x => x.Id == pollId);
            if (poll != null)
            {
                rankings = Ranking.GetRanking(poll);
            }

            return View("Rank", rankings);
        }

        [HttpGet("Results")]
        public IActionResult Results()
        {
            string password = HttpContext.Request.Cookies["User"];
            var polls = _dbContext.Polls
                .Include(x => x.Answers)
                .ThenInclude(x => x.Question)
                .Where(x => x.User.Password == password);
            var user = _dbContext.Users.Single(x => x.Password == password);

            var vm = new ResultsViewModel
            {
                Polls = polls.ToList(),
                UserName = _dbContext.Users.Single(x => x.Id == user.Id).Name
            };

            return View("Results", vm);
        }

        [HttpGet("Destinations")]
        public IActionResult Destinations()
        {
            return View("Destinations", _dbContext.Destinations.ToList());
        }


        private void LoadUsers()
        {
            var users = _dbContext.Users.ToList();

            _userViewModel.Add(new UserViewModel
            {
                Id = 0,
                Name = "Vem är jag nu igen?"
            });

            foreach (var user in users)
            {
                _userViewModel.Add(new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name
                });
            }
        }
    }
}



