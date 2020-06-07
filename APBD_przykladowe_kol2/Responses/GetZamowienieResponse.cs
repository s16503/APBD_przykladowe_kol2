using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Responses
{
    public class GetZamowienieResponse
    {
        public int IdZamowienia { get; set; }
        public int IdKlienta { get; set; }
        public int IdPracownika { get; set; }
        public string Uwagi { get; set; }
        public IEnumerable<GetWyrobResponse> Wyrob { get; set; }
    }
}
