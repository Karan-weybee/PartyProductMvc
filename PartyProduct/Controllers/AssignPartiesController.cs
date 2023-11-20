using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PartyProduct.Models;
using PartyProduct.ViewModels;

namespace PartyProduct.Controllers
{
    [Authorize]
    public class AssignPartiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignParties
        public ActionResult Index()
        {
            return View(db.AssignParties.Include(c => c.Party).Include(d => d.Product).ToList());
        }


        // GET: AssignParties/Create
        public ActionResult Create()
        {
            var party = db.Parties;
            var product = db.Products;

            ViewBag.list = party;
            ViewBag.list2 = product;
            return View();
        }

        // POST: AssignParties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //public ActionResult Create(AssignParty assignParty)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Party,Product")] AssignParty assignParty)
        {
            if (ModelState.IsValid)
            {
                var pId = Convert.ToInt32(assignParty.Party.PartyName);
                var prId = Convert.ToInt32(assignParty.Product.ProductName);
                var party = db.Parties.Single(x => x.id == pId);
                var product = db.Products.Single(x => x.id == prId);
                AssignParty Assign = new AssignParty()
                {


                    Party = party,
                    Product = product
                };
                db.AssignParties.Add(Assign);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(assignParty);
        }

        // GET: AssignParties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignParty assignParty = db.AssignParties.Find(id);
            if (assignParty == null)
            {
                return HttpNotFound();
            }
            var party = db.Parties;
            var product = db.Products;
            ViewBag.list = party;
            ViewBag.list2 = product;
            return View(assignParty);
        }

        // POST: AssignParties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Party,Product")] AssignParty assignParty)
        {
            if (ModelState.IsValid)
            {
                var pId = Convert.ToInt32(assignParty.Party.PartyName);
                var prId = Convert.ToInt32(assignParty.Product.ProductName);
                var party = db.Parties.Single(x => x.id == pId);
                var product = db.Products.Single(x => x.id == prId);


                var updateAssign = db.AssignParties.Single(x => x.id == assignParty.id);
                updateAssign.Party = party;
                updateAssign.Product = product;

                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(assignParty);
        }

        // GET: AssignParties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignParty assignParty = db.AssignParties.Find(id);
            db.AssignParties.Remove(assignParty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: AssignParties/Delete/5


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
