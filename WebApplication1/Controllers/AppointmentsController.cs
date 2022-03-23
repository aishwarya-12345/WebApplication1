using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "admin")]
    public class AppointmentController : Controller
    {
        HospitalContext hc1 = new HospitalContext();
        // GET: Appointment
        public ActionResult Index()
        {

            return View(hc1.apt.Include("doc").Include("pt").ToList());
        }

        public ActionResult Create()
        {
            ViewBag.docId = new SelectList(hc1.doctor.ToList(), "id", "name");
            ViewBag.ptId = new SelectList(hc1.patient.ToList(), "id", "name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Appointment apt)
        {
            if (ModelState.IsValid)
            {
                apt.ptemail = "aishwarya@gmail.com";
                hc1.apt.Add(apt);
                hc1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apt);
        }
        public ActionResult Delete(int id)
        {
            return View(hc1.doctor.Find(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            Doctor dc = hc1.doctor.Find(id);
            hc1.doctor.Remove(dc);
            hc1.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}





