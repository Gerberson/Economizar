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
    [Authorize]
    public class CompraController : Controller
    {
        private EconomizarContext db = new EconomizarContext();

        // GET: Compra
        public async Task<ActionResult> Index()
        {
            var compras = db.Compras.Include(c => c.Supermercado);
            ViewBag.DatasCompras = new SelectList(compras.OrderByDescending(l => l.DataCompra), "DataCompra", "DataCompra").Distinct();
            return View(await compras.OrderByDescending(x => x.CompraId).ToListAsync());
        }

        // GET: Compra/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            ViewBag.SupermercadoId = new SelectList(db.Supermercadoes, "SupermercadoId", "Nome");
            return View();
        }

        // POST: Compra/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CompraId,Produto,Quantidade,Preco,Usuario,SupermercadoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compra);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SupermercadoId = new SelectList(db.Supermercadoes, "SupermercadoId", "Nome", compra.SupermercadoId);
            return View(compra);
        }

        // GET: Compra/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupermercadoId = new SelectList(db.Supermercadoes, "SupermercadoId", "Nome", compra.SupermercadoId);
            return View(compra);
        }

        // POST: Compra/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CompraId,Produto,Quantidade,Preco,Usuario,SupermercadoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SupermercadoId = new SelectList(db.Supermercadoes, "SupermercadoId", "Nome", compra.SupermercadoId);
            return View(compra);
        }

        // GET: Compra/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = await db.Compras.FindAsync(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Compra compra = await db.Compras.FindAsync(id);
            db.Compras.Remove(compra);
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
