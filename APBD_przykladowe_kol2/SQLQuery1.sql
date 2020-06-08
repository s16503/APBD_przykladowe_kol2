use s16503

select * from WyrobyCukiernicze

select * from zamowienia

select * from klienci

insert into klienci Values('Anastazy', 'Lipka');

SELECT nazwa, Zamowienia_WyrobyCukiernicze.Ilosc as ilosc from WyrobyCukiernicze join Zamowienia_WyrobyCukiernicze on WyrobyCukiernicze.IdWyrobuCukierniczego =  Zamowienia_WyrobyCukiernicze.IdWyrobuCukierniczego join Zamowienia on Zamowienia.IdZamowienia = Zamowienia_WyrobyCukiernicze.IdZamowienia where Zamowienia.IdKlienta =4;