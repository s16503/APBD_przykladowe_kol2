using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Models
{
    public class WyrobCukierniczy
    {
      
        public int IdWyrobuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public float Cena { get; set; }
        public string Typ { get; set; }
      // public ICollection<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobyCukiernicze { get; set; }



    }
}
