using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Economizar.Models;
using Microsoft.AspNet.Identity;

namespace Economizar.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private EconomizarContext db = new EconomizarContext();

        // GET: Item
        public ActionResult Index()
        {
            string usuario = User.Identity.GetUserName();
            ViewBag.Usuario = usuario.ToString();
            var items = from x in db.Items.Include(i => i.Supermercado) where x.Usuario == usuario select x;

            if (items == null)
            {
                return View(items.ToList());
            }

            return View(items.ToList().OrderByDescending(i => i.ItemId));
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            var lista = db.Supermercadoes.ToList();
            var selecionar = new Supermercado { SupermercadoId = 0, Nome = "Selecione um supermercado..." };
            lista.Add(selecionar);
            ViewBag.SupermercadoId = new SelectList(lista.OrderBy(l => l.SupermercadoId), "SupermercadoId", "Nome");
            return View();
        }

        // POST: Item/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,Produto,Quantidade,Preco,Usuario,SupermercadoId")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.SupermercadoId == 0)
                {
                    var listar = db.Supermercadoes.ToList();
                    var selecione = new Supermercado { SupermercadoId = 0, Nome = "Selecione um supermercado..." };
                    listar.Add(selecione);
                    ViewBag.SupermercadoId = new SelectList(listar.OrderBy(l => l.SupermercadoId), "SupermercadoId", "Nome");
                    return View();
                }


                if (User.Identity.GetUserName() != null)
                {
                    var listaCompras = db.Compras.ToList();

                    List<Compra> listadb = new List<Compra>();

                    foreach (var items in listaCompras)
                    {
                        if (items.Produto == item.Produto)
                        {
                            listadb.Add(items);
                        }                        
                    }

                    decimal valorMax;
                    decimal valorMin;
                    if (listadb.Count() > 0)
                    {
                        valorMax = listadb.Where(x => x.Produto == item.Produto).Max(x => x.Preco);
                        valorMin = listadb.Where(x => x.Produto == item.Produto).Min(x => x.Preco);
                    }
                    else
                    {
                        valorMax = 0;
                        valorMin = 0;
                    }

                    var list = new Item
                    {
                        ItemId = item.ItemId,
                        Preco = item.Preco,
                        Produto = item.Produto,
                        Quantidade = item.Quantidade,
                        DataCompra = DateTime.Now,
                        SupermercadoId = item.SupermercadoId,
                        Usuario = User.Identity.GetUserName().ToString(),
                        ValorMax = valorMax,
                        ValorMin = valorMin
                    };

                    db.Items.Add(list);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }

            var lista = db.Supermercadoes.ToList();
            var selecionar = new Supermercado { SupermercadoId = 0, Nome = "Selecione um supermercado..." };
            lista.Add(selecionar);
            ViewBag.SupermercadoId = new SelectList(lista.OrderBy(l => l.SupermercadoId), "SupermercadoId", "Nome");
            return View(item);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupermercadoId = new SelectList(db.Supermercadoes, "SupermercadoId", "Nome", item.SupermercadoId);
            return View(item);
        }

        // POST: Item/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            var items = new Item
            {
                DataCompra = item.DataCompra,
                Preco = item.Preco,
                Produto = item.Produto,
                Quantidade = item.Quantidade,
                SupermercadoId = item.SupermercadoId,
                Usuario = User.Identity.GetUserName().ToString()
            };

            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupermercadoId = new SelectList(db.Supermercadoes, "SupermercadoId", "Nome", item.SupermercadoId);
            return View(items);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Salvar()
        {
            var list = db.Items.ToList();
            if (list != null)
            {
                var items = new List<Item>();
                var itemdelete = new List<Item>();
                foreach (var item in list)
                {
                    db.Compras.Add(new Compra
                    {
                        CompraId = item.ItemId,
                        Preco = item.Preco,
                        Produto = item.Produto,
                        Quantidade = item.Quantidade,
                        Supermercado = item.Supermercado,
                        SupermercadoId = item.SupermercadoId,
                        Usuario = item.Usuario,
                        DataCompra = item.DataCompra
                    });
                    db.SaveChanges();
                }

                foreach (var i in list)
                {
                    db.Items.Remove(i);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Item");
            }

            return RedirectToAction("Index", "Item");
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
