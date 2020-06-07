using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Responses
{
    public class GetWyrobResponse
    {
        public int IdWyrobu { get; set; }
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
    }
}
