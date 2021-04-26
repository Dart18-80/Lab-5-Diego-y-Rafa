using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_Diego_y_Rafa.Models
{
    public class ColaEstructura<T>
    {
        NodeEstructuras<T> Primero;
        public NodeEstructuras<T> CrearEstructura(string Nombre, T Data)
        {
            NodeEstructuras<T> Nuevo = new NodeEstructuras<T>();
            Nuevo.Estructura = Data;
            Nuevo.UsuarioNombre = Nombre;
            return Nuevo;
        }

        public void Encolar(NodeEstructuras<T> Nuevo)
        {
            if (Primero == null)
            {
                Primero = Nuevo;
            }
            else
            {
                Encolar(Primero, Nuevo);
            }
        }
        void Encolar(NodeEstructuras<T> Raiz, NodeEstructuras<T> Nuevo)
        {
            if (Raiz.Siguiente == null)
            {
                Raiz.Siguiente = Nuevo;
            }
            else
            {
                Encolar(Raiz.Siguiente, Nuevo);
            }
        }

        public T RetornarEstructura(string NombreU)
        {
            if (Primero == null)
            {
                return default;
            }
            else
            {
                return RetornarEstructura(NombreU, Primero);
            }
        }

        T RetornarEstructura(string NombreU,NodeEstructuras<T> Raiz) 
        {
            if (Raiz == null)
            {
                return default;
            }
            else 
            {
                if (Raiz.UsuarioNombre == NombreU)
                {
                    return Raiz.Estructura;
                }
                else 
                {
                    return RetornarEstructura(NombreU, Raiz.Siguiente);
                }
            }
        }
    }
}
