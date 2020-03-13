using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OldHouse.Data;
using OldHouse.Models;

namespace OldHouse.Controllers
{
    public class MachinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        #region Constructor 
        public MachinesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        /// <summary>
        /// GET: Machines
        /// Call this method when you want to get all the machines and want to display them in the index page.
        /// </summary>
        /// <returns>list of type machines</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Machines.ToListAsync());
        }

        /// <summary>
        /// GET: Machines/Details/5
        /// Call this method when you want to show the details for a specific machine (Battery Lvl, Serial Number, Status)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of type Machine</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        /// <summary>
        /// GET: Machines/Create
        /// Call this method when you want to show the create page
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Machines/Create
        /// Call this method when you press on the save button 
        /// and want to save and create the specifyed number of machines
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int num)
        {
                for (int i = 0; i < num; i++)
                {
                    var machine = new Machine()
                    {
                        Battery = 100,
                        Status = Status.AVAILABLE
                    };
                _context.Add(machine);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET: Machines/Edit/5
        /// Call this method when you want to edit the machine information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of type Machine</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines.FindAsync(id);

            if (machine == null)
            {
                return NotFound();
            }
            return View(machine);
        }

        /// <summary>
        /// POST: Machines/Edit/5
        /// Call this method when you want to save your updated information for a specific machine
        /// </summary>
        /// <param name="id"></param>
        /// <param name="machine"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineId,Battery,Status,SerialNumber")] Machine machine)
        {
            if (id != machine.MachineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineExists(machine.MachineId))
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
            return View(machine);
        }

        /// <summary>
        /// GET: Machines/Delete/5
        /// Call this method when you want to delete a specific machine 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machine = await _context.Machines
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machine == null)
            {
                return NotFound();
            }

            return View(machine);
        }

        /// <summary>
        /// POST: Machines/Delete/5
        /// Call this method when you want to delete a specific machine 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineExists(int id)
        {
            return _context.Machines.Any(e => e.MachineId == id);
        }
        #endregion
    }
}
