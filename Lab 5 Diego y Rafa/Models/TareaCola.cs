using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_Diego_y_Rafa.Models
{
    public class TareaCola : IComparable
    {
        public string Nombre { get; set; }
        public int Prioridad { get; set; }

        public int CompareToNombre(TareaCola Ultimo, TareaCola Arriba)
        {
            return Ultimo.Prioridad.CompareTo(Arriba.Prioridad);
        }
        public int CompareTo(object obj)
        {
            if (Convert.ToInt16(this.CompareTo(obj)) > 0)
                return 1;
            else if (Convert.ToInt16(this.CompareTo(obj)) < 0)
                return -1;
            else
                return 0;
        }
    }
}
