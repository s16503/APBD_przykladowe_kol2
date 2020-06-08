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

        public List<GetZamowienieResponse> GetAllOrders()
        {
            List<GetZamowienieResponse> zamowienia = new List<GetZamowienieResponse>();

            var query = _context.Zamowienia.ToList();

            foreach(Zamowienie zam in query)
            {
                List<GetWyrobResponse> wyroby = GetWyrobyDlaZamowienia(zam.IdZamowienia);

                zamowienia.Add(new GetZamowienieResponse
                {
                    IdKlienta = zam.IdKlienta,
                    IdPracownika = zam.IdPracownika,
                    IdZamowienia = zam.IdZamowienia,
                    Uwagi= zam.Uwagi,
                    Wyrob = wyroby
                });
            }

            return zamowienia;
        }

        public List<GetWyrobResponse> GetWyrobyDlaZamowienia(int id_Zamowienia)
        {
            //List<GetWyrobResponse> list = new List<GetWyrobResponse>();

            Zamowienie zamowienie = _context.Zamowienia.Where(z => z.IdZamowienia == id_Zamowienia).FirstOrDefault();

            if (zamowienie == null)
                throw new Exception("brak zamowienia o takim id");

            List<GetWyrobResponse> list = (from w in _context.WyrobyCukiernicze
                            join
                            zw in _context.Zamowienia_WyrobyCukiernicze
                            on w.IdWyrobuCukierniczego
                            equals zw.IdWyrobuCukierniczego
                            where zw.IdZamowienia == id_Zamowienia
                            select new GetWyrobResponse
                            {
                               IdWyrobu = w.IdWyrobuCukierniczego,
                               Nazwa = w.Nazwa,
                               Ilosc = zw.Ilosc,
                               Uwagi = zw.Uwagi
                            }).ToList();

            return list;
        }
        public List<GetZamowienieResponse> GetClientOrders(NazwiskoRequest req)
        {
            var klient = _context.Klienci.Where(k=>k.Nazwisko == req.Nazwisko).FirstOrDefault();

            if(klient == null)         
              return GetAllOrders();
            
           
            var idK = klient.IdKlient;


            List<GetZamowienieResponse> zamowienia = new List<GetZamowienieResponse>();

            var zamowienia_Klienta = _context.Zamowienia.Where(z=>z.IdKlienta == idK).ToList();

            foreach (Zamowienie zam in zamowienia_Klienta)
            {
                List<GetWyrobResponse> wyroby = GetWyrobyDlaZamowienia(zam.IdZamowienia);

                zamowienia.Add(new GetZamowienieResponse
                {
                    IdKlienta = zam.IdKlienta,
                    IdPracownika = zam.IdPracownika,
                    IdZamowienia = zam.IdZamowienia,
                    Uwagi = zam.Uwagi,
                    Wyrob = wyroby
                });
            }

                      
           return zamowienia;
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
                    throw new Exception("nie ma wyrobu o nazwie: " + wyrob.Nazwa );
                }

                Zamowienie_WyrobCukierniczy zamowienie_wyrob = new Zamowienie_WyrobCukierniczy
                {
                    IdZamowienia = newId,
                    IdWyrobuCukierniczego = w.IdWyrobuCukierniczego,
                    Ilosc = wyrob.Ilosc,
                    Uwagi = wyrob.Uwagi
                };
                _context.Zamowienia_WyrobyCukiernicze.Add(zamowienie_wyrob);

               
                list.Add(new GetWyrobResponse { IdWyrobu = w.IdWyrobuCukierniczego, Ilosc=wyrob.Ilosc,Nazwa=wyrob.Nazwa, Uwagi=wyrob.Uwagi});
            }
                response.Wyrob = list;

            _context.SaveChanges();
            return response;
        }
    }
}
