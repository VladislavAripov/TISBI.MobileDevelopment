using App.Dal;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    [HttpGet("UsersVisits")]
    public IEnumerable<UserVisit> GetUsersVisits()
    {
        return new[]
        {
            new UserVisit
            {
                UserName = "Kamil Mustafin",
                UserIp = "127.0.0.1",
            },
            new UserVisit
            {
                UserName = "Vlad Aripov",
                UserIp = "192.168.12.23",
            },
        };
    }
}