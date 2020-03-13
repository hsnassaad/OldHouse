using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OldHouse.Data;
using OldHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Hubs
{
    public class BatteryCheck : Hub
    {
        private readonly ApplicationDbContext _context;

        public BatteryCheck(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Methods
        /// <summary>
        /// Call this method every 1 min to decrease the battery level for machines that are IN USE
        /// </summary>
        /// <returns></returns>
        public async Task Check()
        {
            var machines = await _context.Machines.ToListAsync();

            for (int i = 0; i < machines.Count; i++)
            {
                if (machines[i].Status == Status.IN_USE)
                {
                    if(machines[i].Battery <= 40)
                    {
                        machines[i].Status = Status.OUT_OF_SERVICE;
                    }
                    else
                    {
                    machines[i].Battery--;
                    }
                }
            }
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("batteryCheckk", machines);
        }


        public async Task CheckPatientsBatteryMachineStatus()
        {
            var BatteryBelow50 = new List<string>();
            var patients = await _context.Patients.Include(m=>m.Machine).Where(m => m.Machine.Battery <= 60).ToListAsync();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Machine.Status == Status.IN_USE)
                {
                    if (patients[i].Machine.Battery <= 60)
                    {
                        patients[i].Machine.Status = Status.OUT_OF_SERVICE;
                        var errorMsg = patients[i].DisplayName + " 's Machine have battery low";
                        BatteryBelow50.Add(errorMsg);
                        _context.Alerts.Add(new Alert() { Level = "Battery", PatientId = patients[i].PatientId, Description = errorMsg });
                    }
                }
            }
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("patientsBatteryCheckk", BatteryBelow50);
        }


        public async Task CheckPatientRecords()
        {
            var BadPatients = new List<string>();
            var patients = await _context.Patients.Include(r=>r.Records).ToListAsync();
            for (int i = 0; i < patients.Count; i++)
            {
                var patientRecord = patients[i].Records;
                for (int j = 0; j < patientRecord.Count; j++)
                {

                    var bp = patientRecord[j].BloodPressure;
                    var gl = patientRecord[j].GlucoseLevel;
                    var hr = patientRecord[j].HeartRate;
                    var tmp = patientRecord[j].Temperature;
                    if (bp < 90)
                    {
                        BadPatients.Add(patients[i].DisplayName + " 's Blood Pressure is below 90 mmHg");
                        if(patientRecord[j].PatientId != patients[i].PatientId)
                        _context.Alerts.Add(new Alert() { Level = "Danger", PatientId = patients[i].PatientId, Description = patients[i].DisplayName + " 's Blood Pressure is below 90 mmHg" });
                    }
                    if(bp > 120)
                    {
                        BadPatients.Add(patients[i].DisplayName + " 's Blood Pressure is above 120 mmHg");
                        if (patientRecord[j].PatientId != patients[i].PatientId)
                            _context.Alerts.Add(new Alert() { Level = "Danger", PatientId = patients[i].PatientId, Description = patients[i].DisplayName + " 's Blood Pressure is above 120 mmHg" });
                    }

                    if(gl < 3.9)
                    {
                        BadPatients.Add(patients[i].DisplayName + " 's Glucose Level is below 3.9 mmol/L");
                        if (patientRecord[j].PatientId != patients[i].PatientId)
                            _context.Alerts.Add(new Alert() { Level = "Danger", PatientId = patients[i].PatientId, Description = patients[i].DisplayName + " 's Glucose Level is below 3.9 mmol/L" });
                    }
                    if (gl > 7.1)
                    {
                        BadPatients.Add(patients[i].DisplayName + " 's Glucose Level is above 7.1 mmol/L");
                        if (patientRecord[j].PatientId != patients[i].PatientId)
                            _context.Alerts.Add(new Alert() { Level = "Danger", PatientId = patients[i].PatientId, Description = patients[i].DisplayName + " 's Glucose Level is above 7.1 mmol/L" });
                    }
                    if (hr > 100)
                    {
                        BadPatients.Add(patients[i].DisplayName + " 's Heart Rate is above 100 bpm");
                        if (patientRecord[j].PatientId != patients[i].PatientId)
                            _context.Alerts.Add(new Alert() { Level = "Danger", PatientId = patients[i].PatientId, Description = patients[i].DisplayName + " 's Heart Rate is above 100 bpm" });
                    }
                    if (hr < 60)
                    {
                        BadPatients.Add(patients[i].DisplayName + " 's Heart Rate is below 60 bpm");
                        if (patientRecord[j].PatientId != patients[i].PatientId)
                            _context.Alerts.Add(new Alert() { Level = "Danger", PatientId = patients[i].PatientId, Description = patients[i].DisplayName + " 's Heart Rate is below 60 bpm" });

                    }
                    if (tmp < 37)
                    {
                        BadPatients.Add(patients[i].DisplayName + " 's Heart Rate is below 37 C");
                        if (patientRecord[j].PatientId != patients[i].PatientId)
                            _context.Alerts.Add(new Alert() { Level = "Danger", PatientId = patients[i].PatientId, Description = patients[i].DisplayName + " 's Heart Rate is below 37 C" });
                    }

                    if (tmp > 37)
                    {
                        BadPatients.Add(patients[i].DisplayName + " 's Heart Rate is above 37 C");
                        if (patientRecord[j].PatientId != patients[i].PatientId)
                            _context.Alerts.Add(new Alert() { Level = "Danger", PatientId = patients[i].PatientId, Description = patients[i].DisplayName + " 's Heart Rate is above 37 C" });
                    }
                }
            }
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("patientRecordsCheckk", BadPatients);
        }


        #endregion
    }
}
