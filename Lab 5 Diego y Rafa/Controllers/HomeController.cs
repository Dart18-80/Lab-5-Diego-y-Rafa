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
using LibreriaDeClasesLab;

namespace Lab_5_Diego_y_Rafa.Controllers
{
    public class HomeController : Controller
    {
        public static TablaHash Tabla = new TablaHash(50);
        public static string nomrecola = null;
        private readonly ILogger<HomeController> _logger;

        delegate int Delagados(TareaCola Tarea1, TareaCola Tarea2);
        TareaCola CallTareas = new TareaCola();

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
                            if (Singleton.Instance.TablaUsuario[contador].Cargo=="Manager")
                            {
                                nomrecola = NuevoCliente.NombreUsuario;
                                return RedirectToAction("ListasTareas");
                            }
                            else
                            {
                                nomrecola = NuevoCliente.NombreUsuario;
                                return RedirectToAction("Tarea");
                            }
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
        public IActionResult ListasTareas()
        {
            Delagados Mayor = new Delagados(CallTareas.CompareToPrioridad);
            string Cargo = null;
            for (int i = 0; i < Singleton.Instance.TablaUsuario.Count; i++)
            {
                if (Singleton.Instance.TablaUsuario[i].NombreUsuario==nomrecola)
                {
                    Cargo = Singleton.Instance.TablaUsuario[i].Cargo;
                    i = Singleton.Instance.TablaUsuario.Count - 1;
                }
            }
            if (true)//////////////////////////////
            {
                if (Cargo == "Developer")
                {
                    ColaPrioridad<TareaCola> LLamado = new ColaPrioridad<TareaCola>();
                    LLamado = Singleton.Instance.ColasDePrioridad.RetornarEstructura(nomrecola);
                    Singleton.Instance.TareasUsuarios = LLamado.Tareas();
                    for (int i = 0; i<Singleton.Instance.TareasUsuarios.Count;i++) 
                    {
                        int posicion = Tabla.FuncionHash(Singleton.Instance.TareasUsuarios[i].Nombre);
                        if (Tabla.ArrayHash[posicion].lista[0].Titulo == Singleton.Instance.TareasUsuarios[i].Nombre)
                        {
                            var NuevoTarea = new Models.NodoHash
                            {
                                Titulo = Tabla.ArrayHash[posicion].lista[0].Titulo,
                                Desciprcion = Tabla.ArrayHash[posicion].lista[0].Desciprcion,
                                Proyecto = Tabla.ArrayHash[posicion].lista[0].Proyecto,
                                Prioridad = Tabla.ArrayHash[posicion].lista[0].Prioridad,
                                Fehca = Tabla.ArrayHash[posicion].lista[0   ].Fehca
                            };
                            Singleton.Instance.ListaTarea.Add(NuevoTarea);
                        }
                    }
                    return View(Singleton.Instance.ListaTarea);
                }
                else if (Cargo == "Manager")
                {
                    
                    string NombredeUusario = Singleton.Instance.Usuario1.returnNode(Mayor).Nombre;
                    Singleton.Instance.Usuario1.HeapSort(Mayor);
                    int posicion = Tabla.FuncionHash(NombredeUusario);
                    for (int i = 0; i < Tabla.ArrayHash[posicion].lista.Length; i++)
                    {
                        if (Tabla.ArrayHash[posicion].lista[i].Titulo == NombredeUusario)
                        {
                            var NuevoTarea = new Models.NodoHash
                            {
                                Titulo = Tabla.ArrayHash[posicion].lista[i].Titulo,
                                Desciprcion = Tabla.ArrayHash[posicion].lista[i].Desciprcion,
                                Proyecto = Tabla.ArrayHash[posicion].lista[i].Proyecto,
                                Prioridad = Tabla.ArrayHash[posicion].lista[i].Prioridad,
                                Fehca = Tabla.ArrayHash[posicion].lista[i].Fehca
                            };
                            Singleton.Instance.ListaTarea.Add(NuevoTarea);
                        }
                    }
                    return View(Singleton.Instance.ListaTarea);
                }
                else
                {
                    return View(Singleton.Instance.ListaTarea);
                }
            }
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
                    Prioridad = Convert.ToInt32(collection["Prioridad"]),
                    Fehca =Convert.ToDateTime(collection["Fehca"]),
                };
                var NuevaTareaCola = new Models.TareaCola
                {
                    Nombre = collection["Titulo"],
                    Prioridad = Convert.ToInt32(collection["Prioridad"]),

                };
                int posicion = Tabla.FuncionHash(NuevaTarea.Titulo);
                if (Tabla.ArrayHash[posicion].lista == null)
                {
                    Tabla.AgregarTarea(posicion, NuevaTarea);
                    ColaPrioridad<TareaCola> LLamado = new ColaPrioridad<TareaCola>();
                    Singleton.Instance.ColasDePrioridad.Encolar(Singleton.Instance.ColasDePrioridad.CrearEstructura(nomrecola, LLamado));
                    Singleton.Instance.ColasDePrioridad.RetornarEstructura(nomrecola).InsertQueu(Singleton.Instance.ColasDePrioridad.RetornarEstructura(nomrecola).CrearNodo(NuevaTareaCola));
                    Delagados Mayor = new Delagados(CallTareas.CompareToPrioridad);
                    Singleton.Instance.ColasDePrioridad.RetornarEstructura(nomrecola).HeapSort(Mayor);
                    return View();
                }
                else
                {
                    for (int i = 0; i < Tabla.ArrayHash[posicion].lista.Length; i++)
                    {
                        if (Tabla.ArrayHash[posicion].lista[i].Titulo == NuevaTarea.Titulo)
                        {
                            TareaError = "Titulo de la Tarea ya existente";
                            ViewData["ErrorTarea"] = TareaError;
                            return View();
                        }
                    }
                    Tabla.AgregarTarea(posicion, NuevaTarea);
                    ColaPrioridad<TareaCola> LLamado = new ColaPrioridad<TareaCola>();
                    Singleton.Instance.ColasDePrioridad.Encolar(Singleton.Instance.ColasDePrioridad.CrearEstructura(nomrecola,LLamado));
                    Singleton.Instance.ColasDePrioridad.RetornarEstructura(nomrecola).InsertQueu(Singleton.Instance.ColasDePrioridad.RetornarEstructura(nomrecola).CrearNodo(NuevaTareaCola));
                    Delagados Mayor = new Delagados(CallTareas.CompareToPrioridad);
                    Singleton.Instance.ColasDePrioridad.RetornarEstructura(nomrecola).HeapSort(Mayor);
                    return View();
                }
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
