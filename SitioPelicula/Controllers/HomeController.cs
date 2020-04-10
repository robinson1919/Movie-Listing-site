using SitioPelicula.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SitioPelicula.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeliculas()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var peliculas = dc.Peliculas.OrderBy(a => a.NombrePelicula).ToList();
                return Json(new { data = peliculas }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Peliculas.Where(a => a.PeliculasID == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Pelicula emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    if (emp.PeliculasID > 0)
                    {
                        //Edit
                        var v = dc.Peliculas.Where(a => a.PeliculasID == emp.PeliculasID).FirstOrDefault();
                        if (v != null)
                        {
                            v.NombrePelicula = emp.NombrePelicula;
                            v.GeneroPelicula = emp.GeneroPelicula;
                            v.AñoPelicula = emp.AñoPelicula;
                            v.PaisPelicula = emp.PaisPelicula;
                            v.DirectorPelicula = emp.DirectorPelicula;
                            v.ActorPelicula1 = emp.ActorPelicula1;
                            v.ActorPelicula2 = emp.ActorPelicula2;
                            v.ActorPelicula3 = emp.ActorPelicula3;
                            v.ActorPelicula4 = emp.ActorPelicula4;
                        }
                    }
                    else
                    {
                        // Save
                        dc.Peliculas.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Peliculas.Where(a => a.PeliculasID == id).FirstOrDefault();
                if(v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePelicula(int id)
        {
            bool status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Peliculas.Where(a => a.PeliculasID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Peliculas.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
       
    }
}
