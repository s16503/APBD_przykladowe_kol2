using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Models
{
    public class Zamowienie
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public int IdKlienta { get; set; }
        public virtual Klient Klient { get; set; }
        public int IdPracownika { get; set; }
        public virtual Pracownik Pracownik { get; set; }

        public ICollection<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobyCukiernicze { get; set; }
    }
}
