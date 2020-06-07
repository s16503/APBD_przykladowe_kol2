using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Requests
{
    public class AddOrderRequest
    {
        public string DataPrzyjecia { get; set; }

        public string Uwagi { get; set; }
        public IEnumerable<AddWyrobRequest> Wyroby { get; set; }

    }
}
