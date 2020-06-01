using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Models
{
    public class Pracownik
    {
       
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; }

    }
}
