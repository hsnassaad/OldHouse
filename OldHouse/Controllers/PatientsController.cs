﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OldHouse.Data;

namespace OldHouse.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            var patient = new Patient();

            patient.BloodTypes = new List<SelectListItem>
        {
                new SelectListItem {Value="B+",Text="B+"},
                new SelectListItem {Value="O+",Text="O+"},
                new SelectListItem {Value="A+",Text="A+"},
                new SelectListItem {Value="AB+",Text="AB+"},
                new SelectListItem {Value="B-",Text="B-"},
                new SelectListItem {Value="O-",Text="O-"},
                new SelectListItem {Value="A-",Text="A-"},
                new SelectListItem {Value="AB-",Text="AB-"}
        };

            return View(patient);
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,FirstName,LastName,Birthdate,Gender,BloodType,DisplayName,CreatedAt,UpdatedAt")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            patient.BloodTypes = new List<SelectListItem>
        {
                new SelectListItem {Value="B+",Text="B+"},
                new SelectListItem {Value="O+",Text="O+"},
                new SelectListItem {Value="A+",Text="A+"},
                new SelectListItem {Value="AB+",Text="AB+"},
                new SelectListItem {Value="B-",Text="B-"},
                new SelectListItem {Value="O-",Text="O-"},
                new SelectListItem {Value="A-",Text="A-"},
                new SelectListItem {Value="AB-",Text="AB-"}
        };

            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            patient.BloodTypes = new List<SelectListItem>
        {
                new SelectListItem {Value="B+",Text="B+"},
                new SelectListItem {Value="O+",Text="O+"},
                new SelectListItem {Value="A+",Text="A+"},
                new SelectListItem {Value="AB+",Text="AB+"},
                new SelectListItem {Value="B-",Text="B-"},
                new SelectListItem {Value="O-",Text="O-"},
                new SelectListItem {Value="A-",Text="A-"},
                new SelectListItem {Value="AB-",Text="AB-"}
        };

            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,FirstName,LastName,Birthdate,Gender,BloodType,DisplayName,CreatedAt,UpdatedAt")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientId))
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
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}
