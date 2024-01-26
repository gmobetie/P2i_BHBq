using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers;
public class LotController : Controller
{
    private readonly BHBqContext _context;
    public GetLotsViewModel Listes {get;set;}

    public LotController()
    {
        var options = new DbContextOptionsBuilder<BHBqContext>()
            .UseSqlite($"Data Source=BHBq.db")
            .Options;

        _context = new BHBqContext(options);
        Listes = new GetLotsViewModel();
    }

    //Get toutes les Lots
    public IActionResult GetLots()
    {
        return View(Listes);
    }

    [HttpPost]
    public async Task<IActionResult> EditLot(int id, Lot Lot)
    {
        var existingLot = await _context.Lots.FindAsync(id);

        if (existingLot == null)
        {
            return NotFound();
        }

        // Copier les valeurs de l'objet Lot dans l'objet existant
        _context.Entry(existingLot).CurrentValues.SetValues(Lot);

        // Marquer toutes les propriétés comme modifiées
        _context.Entry(existingLot).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return RedirectToAction("Lots");
    }

    [HttpPost]
    public async Task<IActionResult> NewLot(Lot lot)
    {
        await _context.Lots.AddAsync(lot);
        await _context.SaveChangesAsync();
        return RedirectToAction("Lots");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

    [HttpPost]
    public async Task<IActionResult> DeleteLot(int id)
    {
        var existingLot = await _context.Lots.FindAsync(id);

        if (existingLot == null)
        {
            return NotFound();
        }

        _context.Lots.Remove(existingLot);
        await _context.SaveChangesAsync();

        return RedirectToAction("Lots");
    }
}
