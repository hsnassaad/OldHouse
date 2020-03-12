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
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AssignPatientToMachine(int? patientId)
        {
            if(patientId != null)
            {
                var patient = await _context.Patients.Include(p=>p.Machine).FirstOrDefaultAsync(p => p.PatientId == patientId);
                ViewData["MachineId"] = new SelectList(_context.Machines.Where(m => (m.Status == Status.AVAILABLE) | (m.MachineId == patient.MachineId)), "MachineId", "SerialNumber");
                ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "DisplayName", patient.DisplayName);
               
                if(patient.MachineId != null && patient.Machine.Status == Status.OUT_OF_SERVICE)
                {
                    ViewData["DangerMessage"] = patient.Machine.SerialNumber + " is out of service.";
                }
                var machines = _context.Machines.Where(m => (m.Status == Status.AVAILABLE) | (m.MachineId == patient.MachineId));
                if (machines.Count() <=0)
                {
                    return RedirectToAction(nameof(Details), patient.PatientId);
                }
            }
            else
            {

                ViewData["MachineId"] = new SelectList(_context.Machines.Where(m => (m.Status == Status.AVAILABLE)), "MachineId", "SerialNumber");
                ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "DisplayName");
                
                ViewData["InfoMessage"] = "Please assign a machine to the patient.";
            }
           

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignPatientToMachine(int patientId, int machineId)
        {
            var patient = await _context.Patients.Include(p=>p.Machine).FirstOrDefaultAsync(p => p.PatientId == patientId);
            var machine = await _context.Machines.FirstOrDefaultAsync(m => m.MachineId == machineId);
            patient.MachineId = machineId;
            machine.Status = Status.IN_USE;
            patient.Machine = machine;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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

            var patient = await _context.Patients.Include(p=>p.Machine)
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
            var patient = await _context.Patients.Include(p=>p.Machine).FirstOrDefaultAsync(p=>p.PatientId == id);
            if(patient.Machine.Status == Status.IN_USE)
            {
                patient.Machine.Status = Status.AVAILABLE;

            }
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
