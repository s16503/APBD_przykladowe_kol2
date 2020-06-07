using APBD_przykladowe_kol2.Models;
using APBD_przykladowe_kol2.Requests;
using APBD_przykladowe_kol2.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_przykladowe_kol2.Services
{
    public class OrdersDbService : IDbService
    {
        public ZamowieniaDbContext _context { get; set; }

        public OrdersDbService(ZamowieniaDbContext context)
        {
            _context = context;
        }

        public List<Zamowienie> GetAllOrders()
        {
            var query = _context.Zamowienia.ToList();

            return query;
        }

        public GetZamowienieResponse AddZamowienie(AddOrderRequest request, int id)
        {
            int idPrac = 1;
            var klient = _context.Klienci.Where(k => k.IdKlient == id).FirstOrDefault();

            if(klient==null)
            {
                throw new Exception("nie znaleziono klienta o takim id");
            }
            GetZamowienieResponse response = new GetZamowienieResponse();
            response.IdKlienta = klient.IdKlient;           
            response.IdPracownika = idPrac;
            response.Uwagi = request.Uwagi;

            List<GetWyrobResponse> list = new List<GetWyrobResponse>();

            string pattern = "dd.MM.yyyy";
            DateTime parsedDate;
            if (!DateTime.TryParseExact(request.DataPrzyjecia, pattern, null, DateTimeStyles.None, out parsedDate))
                throw new Exception("niepoprawna data");

            Zamowienie order = new Zamowienie
            {
                IdKlienta = id,
                IdPracownika = idPrac,
                DataPrzyjecia = parsedDate,
                DataRealizacji = DateTime.Now,
                Uwagi = request.Uwagi

            };

            _context.Add(order);
           _context.SaveChanges();

            int newId = order.IdZamowienia;
            response.IdZamowienia = newId;
          


            foreach (var wyrob in request.Wyroby)
            {
                //var resp = new GetWyrobResponse();
                var w = _context.WyrobyCukiernicze.Where(w => w.Nazwa == wyrob.Nazwa).FirstOrDefault();
                if(w == null)
                {
                    _context.Remove(order);
                    _context.SaveChanges();
                    throw new Exception("nie ma wyrobu");
                }

                Zamowienie_WyrobCukierniczy zamowienie_wyrob = new Zamowienie_WyrobCukierniczy
                {
                    IdZamowienia = newId,
                    IdWyrobuCukierniczego = w.IdWyrobuCukierniczego,
                    Ilosc = wyrob.Ilosc,
                    Uwagi = wyrob.Uwagi
                };

                _context.Add(order);
                list.Add(new GetWyrobResponse { IdWyrobu = w.IdWyrobuCukierniczego, Ilosc=wyrob.Ilosc,Nazwa=wyrob.Nazwa, Uwagi=wyrob.Uwagi});
                response.Wyrob = list;
            }

            return response;
        }
    }
}
