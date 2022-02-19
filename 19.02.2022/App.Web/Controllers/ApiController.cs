using App.Dal;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private AppDbContext _appDbContext;

    public ApiController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    [HttpGet("UsersVisits")]
    public IEnumerable<UserVisit> GetUsersVisits()
    {
        return _appDbContext.UserVisits.ToList();
    }
}