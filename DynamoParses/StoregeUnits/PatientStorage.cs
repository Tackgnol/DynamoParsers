using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits 
{
    public class PatientStorage : AbstractStorage
    {
        public PatientStorage() : base()
        {
            currentPatients = new List<Patient>();
        }
        public List<Patient> AllPatients
        {
            get
            {
                return currentPatients;
            }
        }
        private List<Patient> currentPatients;
        public Patient GetOrCreate(string firstName, string lastName, string sex = null)
        {
            var patientsFound = from patient in currentPatients
                                where patient.FirstName == firstName && patient.LastName == lastName
                                select patient;
            if (!patientsFound.Any())
            {
                Patient newPatient = new Patient(firstName, lastName, sex);
                currentPatients.Add(newPatient);
                return newPatient;
            }
            return patientsFound.FirstOrDefault();
        }
    }
}
