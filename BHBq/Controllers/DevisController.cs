using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BHBq.Controllers;

public class DevisController : Controller
{
    private readonly ILogger<DevisController> _logger;
    private readonly BHBqContext _context;

    public DevisController(ILogger<DevisController> logger)
    {
        _logger = logger;

            var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
    }

    public IActionResult DevisFlow()
    {
        return View();
    }
    public IActionResult Error(string Message)
    {
        ViewBag.Message=Message;
        ViewBag.Url= HttpContext.Request.Headers["Referer"];
        return View();
    }
}
