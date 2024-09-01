using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext:DbContext //DbContext ten miras alır
    {//DbContext Sınıfının Türetilmesi: HotelDbContext sınıfı, Entity Framework Core'un DbContext sınıfından türetilmiştir
     //Bu sınıf, veritabanı ile etkileşim kuran bir bağlamı tanımlar.
     //Veritabanı Yapılandırması (OnConfiguring Metodu): OnConfiguring metodu, veritabanı bağlantı dizesini (Connection String) tanımlar ve
     //SQL Server veritabanına bağlanmak için kullanılır.
     //DbSet Tanımlama: DbSet<Hotel> özelliği, Hotel varlıklarını temsil eder ve
     //Entity Framework tarafından bu varlıklarla ilgili işlemleri gerçekleştirmek için kullanılır.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-E17N4A6;Database=HotelDb;uid=sa;pwd=1234;");
        }

        public DbSet<Hotel> Hotels{ get; set; }
    }
}
