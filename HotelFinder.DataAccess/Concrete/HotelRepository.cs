using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{//Tüm veri erişim metotları, using ifadesi içinde bir HotelDbContext nesnesi oluşturur.
 //Bu, veritabanı ile etkileşime geçmek için bir bağlantı sağlar ve işlemler tamamlandığında bellekten otomatik olarak temizlenir.
    public class HotelRepository : IHotelRepository//implemet edildi
    {//HotelRepository sınıfı, IHotelRepository arayüzünü uygulamaktadır
     //. Bu, arayüzde tanımlanan tüm CRUD metotlarının bu sınıfta gerçekte nasıl çalışacağını belirler.
        public Hotel CreateHotel(Hotel hotel)
        {//CreateHotel(Hotel hotel): Yeni bir otel nesnesi oluşturur ve veritabanına ekler. SaveChanges çağrısıyla veritabanına kaydedilir.
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {//DeleteHotel(int id): Belirtilen id'ye sahip oteli veritabanından siler.
         //Önce GetHotelById(id) ile silinecek otel nesnesini bulur, ardından Remove yöntemiyle bu nesneyi siler.
            using (var hotelDbContext = new HotelDbContext())
            {
                
                var deletedHotel=GetHotelById(id);
                hotelDbContext.Hotels.Remove(deletedHotel);
                hotelDbContext.SaveChanges();
                 
            }
        }

        public List<Hotel> GetAllHotels()
        {//Tüm otellerin listesini döndürür. ToList() çağrısıyla otellerin tam listesini alır.
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {// Belirtilen id'ye sahip tek bir oteli bulur ve döndürür.
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {//Mevcut bir oteli günceller. Update yöntemiyle verilen hotel nesnesindeki değişiklikleri kaydeder ve SaveChanges çağrısıyla veritabanına uygular.
            using (var hotelDbContext = new HotelDbContext())
            {
               hotelDbContext.Hotels.Update(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }
    }
}
