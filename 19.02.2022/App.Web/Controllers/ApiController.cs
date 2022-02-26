using App.Dal;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public ApiController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    [HttpGet("UsersVisits")]
    public IEnumerable<UserVisit> GetUsersVisits(int skip = 0, int take = 20)
    {
        if (skip < 0 || take < 0)
            throw new ArgumentException("Skip and take values must be a positive numbers");

        return _appDbContext.UserVisits
            .Skip(skip)
            .Take(take)
            .ToList();
    }

    [HttpPost("UsersVisits")]
    public void AddUserVisit(UserVisit userVisit)
    {
        if (string.IsNullOrEmpty(userVisit.UserName) || string.IsNullOrEmpty(userVisit.UserName))
            throw new ArgumentException("UserName and userIp must be specified");

        _appDbContext.UserVisits
            .Add(userVisit);
        _appDbContext.SaveChanges();
    }
}