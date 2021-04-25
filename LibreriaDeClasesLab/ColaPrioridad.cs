﻿using System;

namespace LibreriaDeClasesLab
{
    public class ColaPrioridad<T> where T : IComparable
    {
        NodoPrioridad<T> Primero;
        NodoPrioridad<T> Ultimo;

        public void InsertQueu(NodoPrioridad<T> Nuevo)
        {
            if (Primero == null)
            {
                Primero = Nuevo;
                Nuevo.Arriba = null;
                Ultimo = Nuevo;
            }
            else
            {
                InsertQueu(Nuevo, Primero);
            }
        }

        void InsertQueu(NodoPrioridad<T> Nuevo, NodoPrioridad<T> Raiz)
        {
            if (Raiz.Derecha == null || Raiz.Izquierda == null)
            {
                if (Raiz.Izquierda == null)
                {
                    Raiz.Siguiente = Nuevo;
                    Raiz.Izquierda = Nuevo;
                    Nuevo.Arriba = Raiz;
                    Ultimo = Nuevo;
                }
                else
                {
                    Raiz.Siguiente.Siguiente = Nuevo;
                    Raiz.Derecha = Nuevo;
                    Nuevo.Arriba = Raiz;
                    Ultimo = Nuevo;
                }
            }
            else
            {
                InsertQueu(Nuevo, Raiz.Siguiente);
            }
        }

        public void HeapSort(Delegate Condicion)
        {
            if (Primero == null)
            {
                return;
            }
            else
            {
                HeapSort(Primero, Condicion);
            }
        }

        void HeapSort(NodoPrioridad<T> Siguiente, Delegate Condicion)
        {
            if (Siguiente != null)
            {
                if (Siguiente.Derecha != null && Siguiente.Izquierda != null)
                {
                    int IzquierdaDerecha = Convert.ToInt32(Condicion.DynamicInvoke(Siguiente.Izquierda.Data, Siguiente.Derecha.Data));
                    if (IzquierdaDerecha > 0)
                    {
                        int PadreDerecha = Convert.ToInt32(Condicion.DynamicInvoke(Siguiente.Data, Siguiente.Derecha.Data));
                        if (PadreDerecha > 0)
                        {
                            Change(Siguiente.Derecha, Siguiente);
                            HeapSort(Condicion);
                        }
                        else
                        {
                            HeapSort(Siguiente.Siguiente, Condicion);
                        }
                    }
                    else if (IzquierdaDerecha < 0)
                    {
                        int PadreIzquierda = Convert.ToInt32(Condicion.DynamicInvoke(Siguiente.Data, Siguiente.Izquierda.Data));
                        if (PadreIzquierda > 0)
                        {
                            Change(Siguiente.Izquierda, Siguiente);
                            HeapSort(Condicion);
                        }
                        else
                        {
                            HeapSort(Siguiente.Siguiente, Condicion);
                        }
                    }
                }
                else if (Siguiente.Izquierda != null)
                {
                    int PadreIzquierda = Convert.ToInt32(Condicion.DynamicInvoke(Siguiente.Data, Siguiente.Izquierda.Data));
                    if (PadreIzquierda > 0)
                    {
                        Change(Siguiente.Izquierda, Siguiente);
                        HeapSort(Condicion);
                    }
                    else
                    {
                        HeapSort(Siguiente.Siguiente, Condicion);
                    }
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }
        }
        void Change(NodoPrioridad<T> Subir, NodoPrioridad<T> Bajar)
        {
            T Aux = Subir.Data;
            Subir.Data = Bajar.Data;
            Bajar.Data = Aux;
        }

        public T returnNode(Delegate Condicion)
        {
            T Aux = Primero.Data;
            Primero.Data = Ultimo.Data;
            Delete(Primero, Condicion);
            return Aux;
        }
        void Delete(NodoPrioridad<T> Raiz, Delegate Condicion)
        {
            if (Raiz.Siguiente.Siguiente.Data != null)
            {
                Delete(Raiz.Siguiente, Condicion);
            }
            else
            {
                EliminarHijo(Condicion);
                Raiz.Siguiente = null;
            }
        }
        void EliminarHijo(Delegate Condicion)
        {
            int i = Convert.ToInt32(Condicion.DynamicInvoke(Ultimo.Arriba.Derecha.Data, Ultimo.Data));
            if (i == 0)
            {
                Ultimo.Arriba.Derecha = null;
            }
            int y = Convert.ToInt32(Condicion.DynamicInvoke(Ultimo.Arriba.Izquierda.Data, Ultimo.Data));
            if (y == 0)
            {
                Ultimo.Arriba.Izquierda = null;
            }
        }
    }
}