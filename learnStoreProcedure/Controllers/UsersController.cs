using learnStoreProcedure.Models;
using Microsoft.AspNetCore.Mvc;

namespace learnStoreProcedure.Controllers;

[Route("Users")]
public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger){
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(){
        return View("Views/DataUsers/Index.cshtml");
    }

    [HttpGet("Insert")]
    public IActionResult GetAddNewUsers(){
        return View("Views/DataUsers/Index.cshtml");
    }

    [HttpPost("Insert")]
    public IActionResult AddNewUsers(UserViewModel user){
        return View("Views/DataUsers/Index.cshtml");
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id){
        return View("Views/DataUsers/Upsert.cshtml");
    }

    [HttpGet("Update")]
    public IActionResult Update(UserViewModel user){
        return View("Views/DataUsers/UpSert.cshtml");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        return RedirectToAction("Views/DataUsers/Index.cshtml");
    }
}