using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;
public class ErrorController : Controller
{
    private readonly BHBqContext _context;

    public ErrorController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
    }

    public IActionResult Error(string Message)
    {
        ViewBag.Message=Message;
        ViewBag.Url= HttpContext.Request.Headers["Referer"];
        return View();
    }


}