using cursoMVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cursoMVC1.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    //mapea bd
                    string sql = @"select a.id , a.nombres, a.apellidos, a.edad, a.sexo, a.fechaRegistro, c.nombre as nombreCiudad from Alumno a inner join Ciudad c on a.codCiudad = c.id";
                    
                  
                    //trae los datos de la base de datos y los convierte en una lista 
                    return View(db.Database.SqlQuery<AlumnoCE>(sql).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        public ActionResult Agregar()
        {

            return View();
        }

        [HttpPost]
        //verifica si el formulario que se esta enviando es al que pertenece 
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {
            //si el modelo  que entra no es valido
            if (!ModelState.IsValid)
                return View();

            try
            {
                //Abre la conexion y la cierra para que no consuma muchos recursos
                using (var db = new AlumnosContext())
                {
                    a.fechaRegistro = DateTime.Now;

                    if (a.edad >= 18 && a.edad <= 99)
                    {
                        //agregar registros
                        db.Alumno.Add(a);
                        //se guardan los cambios
                        db.SaveChanges();
                    }
                    //se muestran los cambios en el index 
                    return RedirectToAction("Index");
                }
              
            }
            catch (Exception ex)
            {
                //retorna el mensaje de error en caso que lo haya
                ModelState.AddModelError("","Error al registrar alumno - "+ex.Message);

                return View();
            }
        }

        public ActionResult agregar2()
        {
            return View();
        }

        public ActionResult ListaCiudades()
        {
            using (var db = new AlumnosContext())
            {
                return PartialView(db.Ciudad.ToList());
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new AlumnosContext())
                {
                    //obtener al alumno
                    Alumno alum = db.Alumno.Find(id);
                    return View(alum);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //a = entidad entrada
        public ActionResult Editar(Alumno a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new AlumnosContext())
                {
                    //buscamos el alumno
                    Alumno alum = db.Alumno.Find(a.id);
                    
                        alum.nombres = a.nombres;
                        alum.apellidos = a.apellidos;
                        alum.edad = a.edad;
                        alum.sexo = a.sexo;

                    if (a.edad >= 18 && a.edad <= 99 )
                    {
                        //guardar cambios si es mayor a 17
                        db.SaveChanges();
                    }
                   
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult DetallesAlumnos(int id)
        {
            using (var db = new AlumnosContext())
            {
                Alumno alu = db.Alumno.Find(id);
                return View(alu);
            }
        }
        public ActionResult Eliminar(int id)
        {

            using (var db = new AlumnosContext())
            {
                Alumno alum = db.Alumno.Find(id);
                db.Alumno.Remove(alum);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }

        public static string nombreCiudad(int CodCiudad)
        {
            using (var db = new AlumnosContext())
            {
                //busca la ciudad por codigo de ciudad y trae el campo "nombre"
                return db.Ciudad.Find(CodCiudad).nombre;
            }
        }
    }
}