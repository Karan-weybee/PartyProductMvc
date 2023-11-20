using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PartyProduct.Models;

namespace PartyProduct.Controllers
{
    [Authorize]
    public class ProductRatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductRates
        public ActionResult Index()
        {
            return View(db.ProductRates.Include(x => x.Product).ToList());
        }

        // GET: ProductRates/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRate productRate = db.ProductRates.Find(id);
            if (productRate == null)
            {
                return HttpNotFound();
            }
            return View(productRate);
        }

        // GET: ProductRates/Create

        public ActionResult Create()
        {
            var products = db.Products;
            ViewBag.procucts = products;
            return View();
        }

        // POST: ProductRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Rate,Date_Of_Rate,Product")] ProductRate productRate)
        {
            if (ModelState.IsValid)
            {

                var prId = Convert.ToInt32(productRate.Product.ProductName);
                var product = db.Products.Single(x => x.id == prId);

                productRate.Product = product;

                db.ProductRates.Add(productRate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productRate);
        }

        // GET: ProductRates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRate productRate = db.ProductRates.Find(id);
            if (productRate == null)
            {
                return HttpNotFound();
            }

            ViewBag.products = db.Products;
            return View(productRate);
        }

        // POST: ProductRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Rate,Date_Of_Rate,Product")] ProductRate productRate)
        {
            if (ModelState.IsValid)
            {
                var prId = Convert.ToInt32(productRate.Product.ProductName);
                var product = db.Products.Single(x => x.id == prId);


                var updateProductRate = db.ProductRates.Single(x => x.id == productRate.id);
                updateProductRate.Product = product;
                updateProductRate.Rate = productRate.Rate;
                updateProductRate.Date_Of_Rate = productRate.Date_Of_Rate;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productRate);
        }

        // GET: ProductRates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductRate productRate = db.ProductRates.Find(id);
            db.ProductRates.Remove(productRate);
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
