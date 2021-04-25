using System;

namespace LibreriaDeClasesLab
{
    public class ColaPrioridad
    {
        NodoPrioridad Primero;
        NodoPrioridad Ultimo;

        public void InsertQueue(NodoPrioridad Nuevo)
        {
            if (Primero == null)
            {
                Primero = Nuevo;
            }
            else
            {
                InsertQueue(Nuevo, Primero);
            }
        }

        void InsertQueue(NodoPrioridad Nuevo, NodoPrioridad Anterior)
        {
            if (Anterior.Siguiente == null)
            {
                Anterior.Siguiente = Nuevo;
                Ultimo = Nuevo;
            }
            else
            {
                InsertQueue(Nuevo, Anterior.Siguiente);
            }
        }

        public void OrdenarCola()
        {
            NodoPrioridad Aux1, Aux2;
            int PrioridadAux;
            string NombreAux;

            Aux1 = Primero;


            while (Aux1.Siguiente != null)
            {
                Aux2 = Aux1.Siguiente;

                while (Aux2.Siguiente != null)
                {
                    if (Aux1.Prioridad > Aux2.Prioridad)
                    {
                        PrioridadAux = Aux1.Prioridad;
                        NombreAux = Aux1.Nombre;

                        Aux1.Prioridad = Aux2.Prioridad;
                        Aux1.Nombre = Aux2.Nombre;

                        Aux2.Prioridad = PrioridadAux;
                        Aux2.Nombre = NombreAux;
                    }
                    Aux2 = Aux2.Siguiente;
                }
                Aux1 = Aux1.Siguiente;
            }
        }
        public NodoPrioridad SacarPrimero(NodoPrioridad Sig)
        {
            if (Sig.Siguiente.Siguiente == null)
            {
                NodoPrioridad Aux = Primero;
                Primero.Nombre = Ultimo.Nombre;
                Primero.Prioridad = Ultimo.Prioridad;
                Sig.Siguiente = null;
                return Aux;
            }
            else
            {
                SacarPrimero(Sig.Siguiente);
                OrdenarCola();
                return Sig;
            }
        }
    }
}
