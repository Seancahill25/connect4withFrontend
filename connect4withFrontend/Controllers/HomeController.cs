using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using connect4withFrontend.Models;
using static connect4withFrontend.Models.Board;

namespace connect4withFrontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            State[,] board = new State[6, 7]; 

            return View(board);
        }

    }
}