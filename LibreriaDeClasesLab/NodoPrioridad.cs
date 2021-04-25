using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesLab
{
    public class NodoPrioridad<T>
    {
        public T Data { get; set; }
        public NodoPrioridad<T> Derecha { get; set; }
        public NodoPrioridad<T> Izquierda { get; set; }
        public NodoPrioridad<T> Siguiente { get; set; }
        public NodoPrioridad<T> Arriba { get; set; }
    }
}
