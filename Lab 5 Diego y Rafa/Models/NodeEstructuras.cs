using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreriaDeClasesLab;

namespace Lab_5_Diego_y_Rafa.Models
{
    public class NodeEstructuras<T> where T : IComparable
    {
        public NodeEstructuras<T> Estructura { get; set; }
        public NodeEstructuras<T> Siguiente { get; set; }
    }
}
