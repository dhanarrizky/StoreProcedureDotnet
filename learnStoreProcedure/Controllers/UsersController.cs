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
        UpSertModel model = new UpSertModel(){
            CurrentPosition = "Insert",
            User = new UserViewModel()
        };
        return View("Views/DataUsers/UpSert.cshtml", model);
    }

    [HttpPost("Insert")]
    public IActionResult AddNewUsers(UpSertModel model){
        _logger.LogInformation("Inserting");
        _services.InsertDataUser(model.User);
        return RedirectToAction("Index");
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id){
        UpSertModel model = new UpSertModel {
            CurrentPosition = "Update",
            User = _services.GetUserById(id)
        };
        return View("Views/DataUsers/Upsert.cshtml", model);
    }

    [HttpPost("Update")]
    public IActionResult Update(UpSertModel model){
        _services.UpdateDataUser(model.User);
        return RedirectToAction("Index");
    }

    [HttpGet("Delete/{id}")]
    public IActionResult Delete(int id){
        var res = _services.DeleteUserById(id);
        _logger.LogInformation("Delete : {0}" , res);
        return RedirectToAction("Index");
    }
}