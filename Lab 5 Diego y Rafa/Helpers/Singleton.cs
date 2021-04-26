using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_5_Diego_y_Rafa.Models;
using LibreriaDeClasesLab;

namespace Lab_5_Diego_y_Rafa.Helpers
{
    public class Singleton
    {
        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singleton();
                return _instance;
            }
        }
        public List<Cliente> TablaUsuario = new List<Cliente>();
        public List<NodoHash> ListaTarea = new List<NodoHash>();
        public List<TareaCola> TareasUsuarios = new List<TareaCola>();
        public ColaPrioridad<TareaCola> Usuario1 = new ColaPrioridad<TareaCola>();
        public ColaEstructura<ColaPrioridad<TareaCola>> ColasDePrioridad = new ColaEstructura<ColaPrioridad<TareaCola>>();
        public int TotalUsuarios;
    }
}
