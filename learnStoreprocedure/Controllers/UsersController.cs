using learnStoreprocedure.Models;
using Microsoft.AspNetCore.Mvc;

namespace learnStoreprocedure.Controllers
{
    [Route("data/index")]
    public class UsersController : Controller
    {
        // GET: UsersController
        [HttpGet]
        public ActionResult Index()
        {
            // return View("~/Views/Data/index.cshtml");
            return View("./../Data/index");
        }

        [HttpPost]
        public ActionResult AddNewUser(UserViewModel user)
        {
            return View("./../Data/index");
        }

        [HttpGet("id")]
        public ActionResult GetUserById(int id)
        {
            return View("./../Data/index");
        }

        [HttpPut("id")]
        public ActionResult EditUserById(int id)
        {
            return View("./../Data/index");
        }

        [HttpDelete("id")]
        public ActionResult DeleteUserById(int id)
        {
            return View("./../Data/index");
        }
    }
}
