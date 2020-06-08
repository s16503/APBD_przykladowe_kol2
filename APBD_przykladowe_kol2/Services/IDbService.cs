using APBD_przykladowe_kol2.Models;
using APBD_przykladowe_kol2.Requests;
using APBD_przykladowe_kol2.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Services
{
    public interface IDbService
    {
        public List<GetZamowienieResponse> GetAllOrders();
        public GetZamowienieResponse AddZamowienie(AddOrderRequest request, int id);
        public List<GetZamowienieResponse> GetClientOrders(NazwiskoRequest req);
        public List<GetWyrobResponse> GetWyrobyDlaZamowienia(int id_Zamowienia);

    
    }
}
