using clinica.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinica.Controllers
{
    public class PrescriptionController : Controller
    {
        static List<Prescription> prescriptionsList = new List<Prescription>();
        // GET: PrescriptionController
        public ActionResult Index()
        {
            return View(prescriptionsList);
        }

        // GET: PrescriptionController/Details/5
        public ActionResult Details(int id)
        {
            foreach(Prescription pres in prescriptionsList)
            {
                if(pres.id == id)
                  return View(pres);
            }
            return NotFound();
        }

        // GET: PrescriptionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrescriptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrescriptionController/Edit/5
        public ActionResult Edit(int id)
        {
            foreach(Prescription pres in prescriptionsList)
            {
                if(pres.id == id)
                {
                    prescriptionsList.Add(pres);
                }
            }
            return NotFound();
        }

        // POST: PrescriptionController/Edit/5
        //עדכון
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            int year = int.Parse(collection["year"]);
            int month = int.Parse(collection["month"]);
            int day = int.Parse(collection["day"]);
            foreach (Prescription pres in prescriptionsList)
            {
                if (pres.id == id)
                {

                    pres.description = collection["description"];
                    pres.endDate = new DateOnly(year,month,day);
                    pres.pName = collection["name"];
                }
            }
            return NotFound();
        }

        // GET: PrescriptionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrescriptionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            foreach (Prescription pres in prescriptionsList)
            {
                if (pres.id == id)
                    prescriptionsList.Remove(pres);
            }
            return NotFound();
        }
    }
}
