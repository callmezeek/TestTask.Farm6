﻿namespace TestTask.Farm6.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using TestTask.Farm6.Models;
    using TestTask.Farm6.Store;

    public class FarmController : FarmMapController
    {
        // GET: Farm/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farm farm = await db.Farms.FindAsync(id);
            if (farm == null)
            {
                return HttpNotFound();
            }
            return View(farm);
        }

        // GET: Farm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Farm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Farmer,Name,Kultur,LastYearHarvest,Area,GisX,GisY,Region")] Farm farm)
        {
            if (ModelState.IsValid)
            {
                farm.Id = Guid.NewGuid();
                db.Farms.Add(farm);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(farm);
        }

        // GET: Farm/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farm farm = await db.Farms.FindAsync(id);
            if (farm == null)
            {
                return HttpNotFound();
            }
            return View(farm);
        }

        // POST: Farm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Farmer,Name,Kultur,LastYearHarvest,Area,GisX,GisY,Region")] Farm farm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farm).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(farm);
        }

        // GET: Farm/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farm farm = await db.Farms.FindAsync(id);
            if (farm == null)
            {
                return HttpNotFound();
            }
            return View(farm);
        }

        // POST: Farm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Farm farm = await db.Farms.FindAsync(id);
            db.Farms.Remove(farm);
            await db.SaveChangesAsync();
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
