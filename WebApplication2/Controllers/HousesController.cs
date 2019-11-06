using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HousesController : Controller
    {
        private HouseDBContext db = new HouseDBContext();

        // GET: Houses
        public ActionResult Index(string idString, string cityString, string stateString, string zipcodeString, string bedroomsString, string bathroomsString, string squareFeetString)
        {

            var houses = from c in db.Houses select c;


            if (!String.IsNullOrEmpty(idString))
            {
                long id = long.Parse(idString);
                houses = houses.Where(s => s.ID == id);
            }
            
            if (!String.IsNullOrEmpty(cityString))
            {
                houses = houses.Where(s => s.City.Equals(cityString));
            }
            if (!String.IsNullOrEmpty(stateString))
            {
                houses = houses.Where(s => s.State.Equals(stateString));
            }
            if (!String.IsNullOrEmpty(zipcodeString))
            {
                houses = houses.Where(s => s.Zipcode.Equals(zipcodeString));
            }
            if (!String.IsNullOrEmpty(bedroomsString))
            {
                houses = houses.Where(s => s.Bedrooms.Equals(bedroomsString));
            }
            if (!String.IsNullOrEmpty(bathroomsString))
            {
                houses = houses.Where(s => s.Bathrooms.Equals(bathroomsString));
            }
            if (!String.IsNullOrEmpty(squareFeetString))
            {
                houses = houses.Where(s => s.SquareFeet.Equals(squareFeetString));
            }

            return View(houses);
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Street1,Street2,City,State,Zipcode,Neighborhood,SalesPrice,DateListed,Bedrooms,Bathrooms,GarageSize,SquareFeet,LotSize,Description")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(house);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Street1,Street2,City,State,Zipcode,Neighborhood,SalesPrice,DateListed,Bedrooms,Bathrooms,GarageSize,SquareFeet,LotSize,Description")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
