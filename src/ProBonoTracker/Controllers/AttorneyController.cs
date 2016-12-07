using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ProBonoTracker.Controllers
{
    public class AttorneyController : Controller
    {
        // GET: Volunteer
        public ActionResult Index(bool? assigning)
        {
            return View();
        }

        // GET: Volunteer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Volunteer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Volunteer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Volunteer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Volunteer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Volunteer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}