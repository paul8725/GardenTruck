using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenTruck.Data;
using GardenTruck.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace GardenTruck.Controllers
{
        public class FlowersController : Controller
        {
            private readonly GardenTruckContext _context;

            public FlowersController(GardenTruckContext context)
            {
                _context = context;
            }

            // GET: Flowers
            public async Task<IActionResult> Index()
            {
                
                    return View(await _context.Flowers.ToListAsync());
            }

            public async Task<IActionResult> UserView()
            {
                
                    return View(await _context.Flowers.ToListAsync());
            }
        
            // GET: Flowers/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Flowers = await _context.Flowers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Flowers == null)
                {
                    return NotFound();
                }

                return View(Flowers);
            }

            // GET: Flowers/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Flowers/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Flower,Age,Price")] Flowers Flowers)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Flowers);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Flowers);
            }

            // GET: Flowers/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Flowers = await _context.Flowers.FindAsync(id);
                if (Flowers == null)
                {
                    return NotFound();
                }
                return View(Flowers);
            }

            // POST: Flowers/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Flower,Age,Price")] Flowers Flowers)
            {
                if (id != Flowers.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Flowers);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FlowersExists(Flowers.Id))
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
                return View(Flowers);
            }

            // GET: Flowers/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Flowers = await _context.Flowers
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Flowers == null)
                {
                    return NotFound();
                }

                return View(Flowers);
            }

            // POST: Flowers/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Flowers = await _context.Flowers.FindAsync(id);
                _context.Flowers.Remove(Flowers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool FlowersExists(int id)
            {
                return _context.Flowers.Any(e => e.Id == id);
            }
        }
    }