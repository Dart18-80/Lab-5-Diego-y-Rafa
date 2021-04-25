using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesLab
{
    public class NodoPrioridad
    {
        public string Nombre { get; set; }
        public int Prioridad { get; set; }
        public int Recorrido { get; set; }
        public NodoPrioridad Derecha { get; set; }
        public NodoPrioridad Izquierda { get; set; }
        public NodoPrioridad Siguiente { get; set; }
        public NodoPrioridad Arriba { get; set; }
    }
}
