using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab_5_Diego_y_Rafa.Models;
using Microsoft.AspNetCore.Http;
using Lab_5_Diego_y_Rafa.Helpers;

namespace Lab_5_Diego_y_Rafa.Controllers
{
    public class HomeController : Controller
    {
        public static TablaHash Tabla = new TablaHash(50);
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            try
            {
                int contador = 0;
                string e = null;
                var NuevoCliente = new Models.Cliente
                {
                    NombreUsuario = collection["NombreUsuario"],
                    Conntraseña = collection["Conntraseña"],
                };
                if (Singleton.Instance.TablaUsuario.Count==0)
                {
                    e = "Cree un Usuario";
                    ViewData["ErrorUusario"] = e;
                    return View();
                }
                else
                {
                    while (Singleton.Instance.TablaUsuario.Count>contador)
                    {
                        if (Singleton.Instance.TablaUsuario[contador].NombreUsuario==NuevoCliente.NombreUsuario && Singleton.Instance.TablaUsuario[contador].Conntraseña == NuevoCliente.Conntraseña)
                        {
                            return RedirectToAction("Tarea");
                        }
                        else
                        {
                            contador++;
                        }
                    }
                    e = "Nombre de Usuario o Conntraseña Incorrecta";
                    ViewData["ErrorUusario"] = e;
                    return View();
                }
               
            }
            catch (Exception)
            {
                return View();
            }
       
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Tarea() 
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(IFormCollection collection)
        {
            try
            {
                string ErrorC = null;
                var NuevoCliente = new Models.Cliente
                {
                    NombreUsuario = collection["NombreUsuario"],
                    Conntraseña = collection["Conntraseña"],
                    Cargo = collection["Cargo"]
                };
                if (Singleton.Instance.TablaUsuario.Count == 0)
                {
                    Singleton.Instance.TablaUsuario.Add(NuevoCliente);
                    return RedirectToAction("Index");
                }
                else
                {
                    for (int i = 0; i < Singleton.Instance.TablaUsuario.Count; i++)
                    {
                        if (Singleton.Instance.TablaUsuario[i].NombreUsuario == NuevoCliente.NombreUsuario)
                        {
                            ErrorC = "El Nombre de usuario seleccionado ya existe: ESCRIBA OTRO PORFAVOR";
                                 ViewData["ErrorCliente"] = ErrorC;
                            return View();
                        }
                        else
                        {
                            ErrorC = "";
                            ViewData["ErrorCliente"] = ErrorC;
                            Singleton.Instance.TablaUsuario.Add(NuevoCliente);
                            i += Singleton.Instance.TablaUsuario.Count - i;
                            return RedirectToAction("Index");
                        }
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }
            
        }
        [HttpPost]

        public IActionResult Tarea(IFormCollection collection)
        {
            try
            {
                string TareaError = null;
                var NuevaTarea = new Models.NodoHash
                {
                    Titulo = collection["Titulo"],
                    Desciprcion = collection["Desciprcion"],
                    Proyecto = collection["Proyecto"],
                    Prioridad = collection["Prioridad"],
                    Fehca =Convert.ToDateTime(collection["Fehca"]),
                };
                int posicion = Tabla.FuncionHash(NuevaTarea.Titulo);
                Tabla.AgregarTarea(posicion, NuevaTarea);
                return View();

            }
            catch
            {
                return View();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
