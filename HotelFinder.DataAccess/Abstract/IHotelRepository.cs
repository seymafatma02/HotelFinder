using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{//IHotelRepository, otel verileriyle ilgili işlemleri tanımlayan bir arayüzdür.
 //Bu arayüzü uygulayan bir sınıf, belirli CRUD işlemlerini sağlamak zorundadır.
 
    public interface IHotelRepository
    {

        List<Hotel> GetAllHotels();//Tüm otellerin listesini döndüren bir metot.

        Hotel GetHotelById(int id);//Belirtilen id değerine sahip tek bir oteli döndüren bir metot.

        Hotel CreateHotel(Hotel hotel);//Yeni bir otel oluşturup veritabanına ekleyen bir metot. Oluşturulan otel nesnesini geri döndürür.

        Hotel UpdateHotel(Hotel hotel);//Mevcut bir oteli güncelleyen bir metot. Güncellenmiş otel nesnesini geri döndürür.

        void DeleteHotel(int id);//Belirtilen id değerine sahip oteli veritabanından silen bir metot.
    }
}
