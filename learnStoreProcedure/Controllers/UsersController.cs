using Microsoft.AspNetCore.Mvc;

namespace learnStoreProcedure.Controllers;

[Route("Users")]
public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger){
        _logger = logger;
    }

    public IActionResult Index(){
        return View("Views/DataUsers/Index.cshtml");
    }
}