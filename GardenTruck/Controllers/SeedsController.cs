using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GardenTruck.Data;
using GardenTruck.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GardenTruck.Controllers
{
        public class SeedsController : Controller
        {
            private readonly GardenTruckContext _context;

            public SeedsController(GardenTruckContext context)
            {
                _context = context;
            }

        // GET: Seeds
        public async Task<IActionResult> Index()
            {
               return View(await _context.Seeds.ToListAsync());               
            }

        // GET: Seeds/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Seeds = await _context.Seeds
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Seeds == null)
                {
                    return NotFound();
                }

                return View(Seeds);
            }
        public IActionResult FlowerNotFound()
        {
            return View();
        }
        
        // GET: Seeds/Create
        public IActionResult Create()
            {
            var Flowers = _context.Flowers.ToList();
            if (Flowers.Count > 0)
            {
                Flowers.Insert(0, new Flowers { Id = 0, Flower = "Select Flowers" });
                ViewBag.ListFlowers = Flowers;
                return View();
            }
            else
            {
                return RedirectToAction(nameof(FlowerNotFound));
            }
            }



        // POST: Seeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Contact,Address,NumberOfPacket,FlowerId")] Seeds Seeds)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Seeds);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Seeds);
            }

        // GET: Seeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Seeds = await _context.Seeds.FindAsync(id);
                if (Seeds == null)
                {
                    return NotFound();
                }
                return View(Seeds);
            }

        // POST: Seeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,Address,NumberOfPacket,FlowerId")] Seeds Seeds)
            {
                if (id != Seeds.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Seeds);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SeedsExists(Seeds.Id))
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
                return View(Seeds);
            }

        // GET: Seeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Seeds = await _context.Seeds
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Seeds == null)
                {
                    return NotFound();
                }

                return View(Seeds);
            }

        // POST: Seeds/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Seeds = await _context.Seeds.FindAsync(id);
                _context.Seeds.Remove(Seeds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool SeedsExists(int id)
            {
                return _context.Seeds.Any(e => e.Id == id);
            }
        }
    }
