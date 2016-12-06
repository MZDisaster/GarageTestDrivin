using GarageTestDrivin.Models;
using GarageTestDrivin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GarageTestDrivin.Controllers
{
    public class HomeController : Controller
    {
        private GarageRepository db;

        public HomeController(GarageRepository repo)
        {
            this.db = repo;
        }

        public HomeController()
        {
            this.db = new GRepo();
        }

        // GET: Vehicles
        public ActionResult Index()
        {
            var vehicles = db.GetVehicles();
            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.GetVehicle(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.GetOwners(), "Id", "Name");
            ViewBag.TypeId = new SelectList(db.GetVehicleTypes(), "Id", "Name");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Color,RegNr,TypeId,OwnerId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.AddVehicle(vehicle);
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.GetOwners(), "Id", "Name", vehicle.OwnerId);
            ViewBag.TypeId = new SelectList(db.GetVehicleTypes(), "Id", "Name", vehicle.TypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.GetVehicle(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.GetOwners(), "Id", "Name", vehicle.OwnerId);
            ViewBag.TypeId = new SelectList(db.GetVehicleTypes(), "Id", "Name", vehicle.TypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Color,RegNr,TypeId,OwnerId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.EditVehicle(vehicle);
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.GetOwners(), "Id", "Name", vehicle.OwnerId);
            ViewBag.TypeId = new SelectList(db.GetVehicleTypes(), "Id", "Name", vehicle.TypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.GetVehicle(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.GetVehicle(id);
            db.RemoveVehicle(vehicle);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}