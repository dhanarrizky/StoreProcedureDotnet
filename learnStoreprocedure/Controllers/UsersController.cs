using learnStoreprocedure.Models;
using Microsoft.AspNetCore.Mvc;

namespace learnStoreprocedure.Controllers
{
    [Route("data")]
    public class UsersController : Controller
    {
        private readonly UsersService _service;
        public UsersController(UsersService service){
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var res = _service.GetAllUsers();
            return View("./../Data/index", res);
        }

        [HttpPost]
        public ActionResult AddNewUser(UserViewModel user)
        {
            var res = _service.AddNewUser(user);
            return View("./../Data/index", res);
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
