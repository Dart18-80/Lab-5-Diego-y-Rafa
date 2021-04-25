using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_5_Diego_y_Rafa.Models
{
    public class TablaHash
    {
        public ListaEnlazada[] ArrayHash;
        public int lenght { get; set; }

        public NodoHash Encontrar;

        public TablaHash(int z)
        {
            ArrayHash = new ListaEnlazada[z];
            int cont = 0;
            while (cont < z)
            {
                ArrayHash[cont] = new ListaEnlazada();
                cont++;
            }
            lenght = z;
        }

        public void AgregarTarea(int posicion, NodoHash valor)
        {
            ArrayHash[posicion].insertarNodo(valor);
        }

        public int FuncionHash(string Titulo)
        {
            int suma = 0;
            int indice = ((Titulo.Length*10)%20)*FuncionCadena(Titulo)%25;
            return indice;
        }

        public int FuncionCadena(string Titulo)
        {
            Titulo.ToUpper();
            string TituloJunto = Regex.Replace(Titulo, @"\s", "");
            char[] cadena = TituloJunto.ToArray();
            int cont = TituloJunto.Length;
            int Func = 0;
            for (int i = 0; i < cont; i++)
            {
                switch (cadena[i].ToString())   
                {
                    case "A":
                        Func += 1;
                        break;
                    case "B":
                        Func += 2;
                        break;
                    case "C":
                        Func += 3;
                        break;
                    case "D":
                        Func += 4;
                        break;
                    case "E":
                        Func += 5;
                        break;
                    case "F":
                        Func += 6;
                        break;
                    case "G":
                        Func += 7;
                        break;
                    case "H":
                        Func += 8;
                        break;
                    case "I":
                        Func += 9;
                        break;
                    case "J":
                        Func += 10;
                        break;
                    case "K":
                        Func += 11;
                        break;
                    case "L":
                        Func += 12;
                        break;
                    case "M":
                        Func += 13;
                        break;
                    case "N":
                        Func += 14;
                        break;
                    case "Ñ":
                        Func += 15;
                        break;
                    case "O":
                        Func += 16;
                        break;
                    case "P":
                        Func += 17;
                        break;
                    case "Q":
                        Func += 18;
                        break;
                    case "R":
                        Func += 19;
                        break;
                    case "S":
                        Func += 20;
                        break;
                    case "T":
                        Func += 21;
                        break;
                    case "U":
                        Func += 22;
                        break;
                    case "V":
                        Func += 23;
                        break;
                    case "VW":
                        Func += 24;
                        break;
                    case "X":
                        Func += 25;
                        break;
                    case "Y":
                        Func += 26;
                        break;
                    case "Z":
                        Func += 27;
                        break;
                    default:

                        break;
                }
            }

            return Func;
        }

        public NodoHash Buscar(string Titulo)
        {
            int posicion = FuncionHash(Titulo);
            return ArrayHash[posicion].Recorrerlista(Titulo);
        }
    }
}
