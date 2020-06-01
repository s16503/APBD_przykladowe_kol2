using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public virtual WyrobCukierniczy WyrobCukierniczy { get; set; }
        public int IdZamowienia { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }


    }
}
