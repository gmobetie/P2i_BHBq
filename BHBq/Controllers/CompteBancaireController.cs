
using System.Diagnostics;
using BHBq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHBq.Controllers
{
    public class CompteBancaireController : Controller
    {
        private readonly BHBqContext _context;
        public List<CompteBancaire> comptesBancaires { get; set; }
        public EntrepriseViewModel Listes { get; set; }

        public CompteBancaireController()
        {
            var options = new DbContextOptionsBuilder<BHBqContext>()
                .UseSqlite($"Data Source=BHBq.db")
                .Options;

            _context = new BHBqContext(options);
            Listes = new EntrepriseViewModel();
        }

        // GET: Tous les comptes bancaires
        public IActionResult ComptesBancaires(int idEntreprise)
        {
            Listes.TargetEntreprise = _context.Entreprises.Find(idEntreprise);

            return View(Listes);
        }

        [HttpPost]
        public async Task<IActionResult> EditCompteBancaire(int id, CompteBancaire compteBancaire)
        {
            var existingCompteBancaire = await _context.ComptesBancaires.FindAsync(id);

            if (existingCompteBancaire == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés non nulles de l'objet existant
            if (compteBancaire.IdEntreprise != null)
            {
                existingCompteBancaire.IdEntreprise = compteBancaire.IdEntreprise;
            }
            if (!string.IsNullOrEmpty(compteBancaire.Adresse))
            {
                existingCompteBancaire.Adresse = compteBancaire.Adresse;
            }
            if (!string.IsNullOrEmpty(compteBancaire.IBAN))
            {
                existingCompteBancaire.IBAN = compteBancaire.IBAN;
            }
            if (!string.IsNullOrEmpty(compteBancaire.BIC))
            {
                existingCompteBancaire.BIC = compteBancaire.BIC;
            }
            if (!string.IsNullOrEmpty(compteBancaire.NumCompte))
            {
                existingCompteBancaire.NumCompte = compteBancaire.NumCompte;
            }
            if (!string.IsNullOrEmpty(compteBancaire.NomBanque))
            {
                existingCompteBancaire.NomBanque = compteBancaire.NomBanque;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ComptesBancaires");
        }

        [HttpPost]
        public async Task<IActionResult> NewCompteBancaire(CompteBancaire compteBancaire)
        {
            var newCompteBancaire = new CompteBancaire
            {
                IdEntreprise = compteBancaire.IdEntreprise,
                Adresse = compteBancaire.Adresse,
                IBAN = compteBancaire.IBAN,
                BIC = compteBancaire.BIC,
                NumCompte = compteBancaire.NumCompte,
                NomBanque = compteBancaire.NomBanque
            };

            await _context.ComptesBancaires.AddAsync(newCompteBancaire);
            await _context.SaveChangesAsync();
            return RedirectToAction("ComptesBancaires");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCompteBancaire(int id)
        {
            var existingCompteBancaire = await _context.ComptesBancaires.FindAsync(id);

            if (existingCompteBancaire == null)
            {
                return NotFound();
            }

            _context.ComptesBancaires.Remove(existingCompteBancaire);
            await _context.SaveChangesAsync();

            return RedirectToAction("ComptesBancaires");
        }
    }
}

