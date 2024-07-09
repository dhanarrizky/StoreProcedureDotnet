using Microsoft.AspNetCore.Mvc;

namespace learnStoreprocedure.Controllers;

[Route("")]
public class DefaultRedirectRouting : Controller {

    private readonly ILogger<DefaultRedirectRouting> _logger;
    public DefaultRedirectRouting(ILogger<DefaultRedirectRouting> logger){
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index(){
        return Redirect("Home/index");
    }
}