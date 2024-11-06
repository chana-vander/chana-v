using clinica.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinica.Controllers
{
    public class PatientsController : Controller
    {
        static List<Patient> PatientsList = new List<Patient>();

        // GET: PatientsController
        public List<Patient> Index()
        {
            return PatientsList;
        }

        // GET: PatientsController/Details/5
        public ActionResult Details(int id)
        {
            foreach (Patient item in PatientsList)
            {
                if (item.id == id)
                    return Ok(item);
            }

            return NotFound(new { message = "patient not found:(" });
        }

        // GET: PatientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientsController/Create
        //הוספת ערך חדש
        [HttpPost]
        [ValidateAntiForgeryToken]
        //void or ActionResult???
        public ActionResult Create(Patient patient)
        {
            PatientsList.Add(patient);  
            return View();
        }

        // GET: PatientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            foreach (Patient patient in PatientsList)
            {
                if (patient.id == id)
                {
                    patient.name = collection["Name"];
                    patient.status = collection["status"];
                   //? patient.age = collection["age"];
                }
            }
            return NotFound();
        }

        // GET: PatientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            foreach (Patient p in PatientsList)
            {
                if (p.id == id)
                    PatientsList.Remove(p);
            }
            return NotFound();
        }
    }
}
