using System.Web.Mvc;
using PaP_Assisstent.Models;
using System;

namespace PaP_Assisstent.Controllers
{
    public class LoginController : Controller
    {
        PlayerManager _manager = PlayerManager.Instance;

        // GET: Player
        public ActionResult Index()
        {
            if (_manager.IsLoggedIn(Session.SessionID))
            {
                Session[_manager.GetCurrentLoggedInName(Session.SessionID)] = _manager.GetCurrentLoggedInName(Session.SessionID);
                return RedirectToAction("InGame");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Name,Password")] Player player)
        {
            if (ModelState.IsValid)
            {
                if (player == null)
                {
                    return HttpNotFound();
                }

                bool loggedIn = _manager.Login(player, Session.SessionID, out string message);
                ViewBag.Message = message;

                if (loggedIn)
                {
                    Session[player.Name] = player.Name;
                    return RedirectToAction("InGame");
                }
            }
            return View();
        }

        public ActionResult InGame()
        {
            if (_manager.IsLoggedIn(Session.SessionID))
            {
                return View(
                    new InGameModel()
                    {
                        Name = _manager.GetCurrentLoggedInName(Session.SessionID),
                        Players = _manager.LoggedInPlayers
                    }
                );
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout_Click(object sender, EventArgs e)
        {
            _manager.Logout(Session.SessionID);
            return RedirectToAction("Index");
        }

        // GET: Player/Create
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Name,Password")] Player player)
        {
            if (ModelState.IsValid)
            {
                if (player == null)
                {
                    return HttpNotFound();
                }
                bool registered = _manager.Register(player, Session.SessionID, out string message);
                ViewBag.Message = message;
                if (registered)
                {
                    Session[player.Name] = player.Name;
                    return RedirectToAction("InGame");
                }
            }
            return View();
        }

    }
}