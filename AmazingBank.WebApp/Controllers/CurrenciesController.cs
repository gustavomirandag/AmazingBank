using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmazingBank.Infrastructure.DataAccess.Contexts;
using AmazingBank.Infrastructure.DataAccess.Contexts.Model;
using AmazingBank.DomainModel.ValueObjects;

namespace AmazingBank.WebApp.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly AmazingBankContext _context;

        public CurrenciesController()
        {
            AmazingBankContext context = new AmazingBankContext();
            _context = context;
        }

        // GET: Currencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Currencies.ToListAsync());
        }

        // GET: Currencies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCurrency = await _context.Currencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbCurrency == null)
            {
                return NotFound();
            }

            return View(dbCurrency);
        }

        // GET: Currencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] DbCurrency dbCurrency, string currency)
        {
            if (ModelState.IsValid)
            {
                dbCurrency.Id = Guid.NewGuid();
                dbCurrency.Currency = new Currency(currency);
                _context.Add(dbCurrency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbCurrency);
        }

        // GET: Currencies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCurrency = await _context.Currencies.FindAsync(id);
            if (dbCurrency == null)
            {
                return NotFound();
            }
            return View(dbCurrency);
        }

        // POST: Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] DbCurrency dbCurrency, string currency)
        {
            if (id != dbCurrency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbCurrency.Currency = new Currency(currency);
                    _context.Update(dbCurrency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbCurrencyExists(dbCurrency.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dbCurrency);
        }

        // GET: Currencies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCurrency = await _context.Currencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbCurrency == null)
            {
                return NotFound();
            }

            return View(dbCurrency);
        }

        // POST: Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dbCurrency = await _context.Currencies.FindAsync(id);
            _context.Currencies.Remove(dbCurrency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbCurrencyExists(Guid id)
        {
            return _context.Currencies.Any(e => e.Id == id);
        }
    }
}
