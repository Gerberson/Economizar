using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Economizar.Models;

namespace Economizar.Controllers
{
    public class SupermercadoController : Controller
    {
        private EconomizarContext db = new EconomizarContext();

        // GET: Supermercado
        public async Task<ActionResult> Index()
        {
            return View(await db.Supermercadoes.ToListAsync());
        }

        // GET: Supermercado/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supermercado supermercado = await db.Supermercadoes.FindAsync(id);
            if (supermercado == null)
            {
                return HttpNotFound();
            }
            return View(supermercado);
        }

        // GET: Supermercado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supermercado/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SupermercadoId,Nome")] Supermercado supermercado)
        {
            if (ModelState.IsValid)
            {
                db.Supermercadoes.Add(supermercado);
                await db.SaveChangesAsync();
                return RedirectToAction("Create", "Item");
            }

            return View(supermercado);
        }

        // GET: Supermercado/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supermercado supermercado = await db.Supermercadoes.FindAsync(id);
            if (supermercado == null)
            {
                return HttpNotFound();
            }
            return View(supermercado);
        }

        // POST: Supermercado/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SupermercadoId,Nome")] Supermercado supermercado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supermercado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(supermercado);
        }

        // GET: Supermercado/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supermercado supermercado = await db.Supermercadoes.FindAsync(id);
            if (supermercado == null)
            {
                return HttpNotFound();
            }
            return View(supermercado);
        }

        // POST: Supermercado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Supermercado supermercado = await db.Supermercadoes.FindAsync(id);
            db.Supermercadoes.Remove(supermercado);
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
