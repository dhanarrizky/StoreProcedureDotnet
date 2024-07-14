using learnStoreProcedure.Models;
using learnStoreProcedure.Services;
using Microsoft.AspNetCore.Mvc;

namespace learnStoreProcedure.Controllers;

[Route("Users")]
public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly UsersServices _services;

    public UsersController(ILogger<UsersController> logger, UsersServices services){
        _logger = logger;
        _services = services;
    }

    [HttpGet]
    public IActionResult Index(){
        var res = _services.GetAllDataUsers();
        _logger.LogInformation("Get All Data Users");
        return View("Views/DataUsers/Index.cshtml", res);
    }

    [HttpGet("Insert")]
    public IActionResult GetAddNewUsers(){
        return View("Views/DataUsers/UpSert.cshtml");
    }

    [HttpPost("Insert")]
    public IActionResult AddNewUsers(UserViewModel user){
        return RedirectToAction("Index");
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id){
        var res = _services.GetUserById(id);
        _logger.LogInformation("Edit : {0}", res);
        return View("Views/DataUsers/Upsert.cshtml");
    }

    [HttpPost("Update")]
    public IActionResult Update(UserViewModel user){
        return View("Views/DataUsers/UpSert.cshtml");
    }

    [HttpGet("Delete/{id}")]
    public IActionResult Delete(int id){
        var res = _services.DeleteUserById(id);
        _logger.LogInformation("Delete : {0}" , res);
        return RedirectToAction("Index");
    }
}