using clinica.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinica.Controllers
{
    public class DoctorsController : Controller
    {
        static List<Doctor> doctorsList = new List<Doctor>();

        // GET: DoctorsController
        public List<Doctor> Index()
        {
            return doctorsList;
        }

        // GET: DoctorsController/Details/5
        public ActionResult Details(int id)
        {

            foreach (Doctor item in doctorsList)
            {
                if (item.id == id)
                    return Ok(item);
            }

            return NotFound(new { message = "doctor not found:(" });

        }

        // GET: DoctorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorsController/Create
        //הוספת ערך חדש
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Doctor Create(Doctor doctor)
        {
            doctorsList.Add(doctor);
            return doctor;
        }

        // GET: DoctorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            foreach (Doctor doctor in doctorsList)
            {
                if (doctor.id == id)
                {
                    doctor.name = collection["Name"];
                    doctor.occupation = collection["Specialty"];
                    doctor.phone = collection["PhoneNumber"];
                }
            }
            return NotFound();

        }

        // GET: DoctorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            foreach (Doctor doctor in doctorsList)
            {
                if (doctor.id == id)
                    doctorsList.Remove(doctor);
            }
            return NotFound();
        }
    }
}
