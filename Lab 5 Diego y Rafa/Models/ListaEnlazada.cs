using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_Diego_y_Rafa.Models
{
    public class ListaEnlazada
    {
        public NodoHash[] lista { get; set; }

        public ListaEnlazada()
        {
            lista = null;
        }

        public void insertarNodo(NodoHash valor)
        {

            if (lista == null)
            {
                lista = new NodoHash[1];
                lista[0] = new NodoHash();
                lista[0] = valor;
            }
            else
            {
                NodoHash[] temporal = lista;
                lista = new NodoHash[temporal.Length + 1];
                int cont = 0;
                while (cont < temporal.Length)
                {
                    lista[cont] = temporal[cont];
                    cont++;
                }
                lista[cont] = valor;

            }
        }
        public NodoHash Recorrerlista(string ValTitulo)
        {
            int cont = 0;

            while ((cont <= lista.Length) && (lista[cont].Titulo != ValTitulo))
            {
                cont++;
            }
            if (cont == lista.Length)
            {
                return null;
            }
            else
            {
                return lista[cont];
            }
        }
    }
}
