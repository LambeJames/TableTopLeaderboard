using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TableTopLeaderboard.Interfaces.Services;
using TableTopLeaderboard.Models;
using TableTopLeaderboard.ViewModelBuilders;
using TableTopLeaderboard.ViewModels;

namespace TableTopLeaderboard.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<ActionResult> Index()
        {
            var players = await _playerService.GetAll();

            var result = players.Select(player => player.ToViewModel());

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlayerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _playerService.Add(viewModel.ToModel());

                if (result)
                {
                    ViewBag.Message = "Player Added Successfully";
                    ModelState.Clear();
                }
            }

            return View(viewModel);
        }

        // 3. ************* EDIT STUDENT DETAILS ******************
        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            DbHandle sdb = new DbHandle();
            return View(sdb.GetPlayers().Find(smodel => smodel.Id == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PlayerModel model)
        {
            try
            {
                DbHandle sdb = new DbHandle();
                sdb.UpdatePlayer(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* DELETE STUDENT DETAILS ******************
        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                DbHandle sdb = new DbHandle();
                if (sdb.DeletePlayer(id))
                {
                    ViewBag.AlertMsg = "Player Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
