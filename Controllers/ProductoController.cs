using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAppCentroComputo.Models;

namespace WebAppCentroComputo.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        private readonly db_centro_computoContext _context;
        public ProductoController(db_centro_computoContext context) { 
            _context = context;
        }
        public ActionResult Index()
        { 
            List<Producto> producto = _context.Productos.ToList();
            foreach (var item in producto) {
                item.IdMarcaNavigation = _context.Marcas.Where(p => p.IdMarca == item.IdMarca).FirstOrDefault();
                item.IdCategNavigation = _context.Categoria.Where(p => p.IdCateg == item.IdCateg).FirstOrDefault();
            }
            return View(producto);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(string id)
        {
            _context.Categoria.ToList();
            _context.Marcas.ToList();
            Producto producto = _context.Productos.Where(p=>p.IdProd == id).FirstOrDefault();
            //producto.IdMarcaNavigation = _context.Marcas.Where(p => p.IdMarca == producto.IdMarca).FirstOrDefault();
            //producto.IdCategNavigation = _context.Categoria.Where(p => p.IdCateg == producto.IdCateg).FirstOrDefault();
            return View(producto);
        }

        // GET: ProductoController/Create
        [HttpGet]
        public ActionResult Create()
        {
            List<Categorium> categoria = _context.Categoria.ToList();
            List<Marca> marca = _context.Marcas.ToList();
            List<SelectListItem> itemCat = categoria.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Categoria.ToString(),
                    Value = d.IdCateg.ToString(),
                    Selected = false
                };
            });
            List<SelectListItem> itemMarca = marca.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Marca1.ToString(),
                    Value = d.IdMarca.ToString(),
                    Selected = false
                };
            });
            ViewBag.itemCat = itemCat;
            ViewBag.itemMarca = itemMarca;
            Producto producto = new Producto();
            return View(producto);
        }

        // POST: ProductoController/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            //List<Producto> Listaproducto = _context.Productos.ToList();
            //string ultimoElem = Listaproducto[Listaproducto.Count - 1].IdProd;
            //producto.IdProd = 
            _context.Add(producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            _context.Productos.ToList();
            Producto producto = _context.Productos.Where(p => p.IdProd == id).FirstOrDefault();
            List<Categorium> categoria = _context.Categoria.ToList();
            List<Marca> marca = _context.Marcas.ToList();
            List<SelectListItem> itemCat = categoria.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Categoria.ToString(),
                    Value = d.IdCateg.ToString(),
                    Selected = false
                };
            });
            List<SelectListItem> itemMarca = marca.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Marca1.ToString(),
                    Value = d.IdMarca.ToString(),
                    Selected = false
                };
            });
            ViewBag.itemCat = itemCat;
            ViewBag.itemMarca = itemMarca;

            
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            _context.Attach(producto);
            _context.Entry(producto).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(string id)
        {
            Producto producto = _context.Productos.Where(p => p.IdProd == id).FirstOrDefault();
            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Producto producto)
        {
            _context.Attach(producto);
            _context.Entry(producto).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
