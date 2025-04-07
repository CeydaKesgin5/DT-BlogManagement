using BlogManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogManagement.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>()
               .HasOne(b => b.User)
               .WithMany(u => u.Blogs)
               .HasForeignKey(b => b.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            // Blog ve Category ilişkisi
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Blogs)
                .HasForeignKey(b => b.CategoryId).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)  
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
               .HasOne(c => c.Blog)
               .WithMany(u=>u.Comments)  
               .HasForeignKey(c => c.BlogId)
               .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<User>().HasData(
            //   new User { Id = "59d917ae-6c68-4852-8b5e-cdf78b79be4f", UserName = "ceyda123", Email = "ceyda@example.com", FullName="Ceyda Kesgin", PasswordHash = "hashedpass1" },
            //   new User { Id = "fddf3976-0eb3-4abe-9d01-e18ce5957bed", UserName = "mert_98", Email = "mert@example.com", FullName = "Mert ", PasswordHash = "hashedpass2" },
            //   new User { Id = "be7fcc00-4ca6-4603-9456-e389a78de363", UserName = "elifkaya", Email = "elif@example.com", FullName = "Elif Kaya", PasswordHash = "hashedpass3" },
            //   new User { Id = "e72f91b4-e511-47f2-aad6-e79753c3cda1", UserName = "ali", Email = "ali@example.com", FullName = "Ali Doğa", PasswordHash = "hashedpass4" },
            //   new User { Id = "4bae5b1b-be95-44c7-8995-8288cb93bd20", UserName = "ahmet", Email = "ahmet@example.com", FullName = "Ahmet Güneş", PasswordHash = "hashedpass5" }


            //   );

            //modelBuilder.Entity<Category>().HasData(
            //    new Category { CategoryID = 1, CategoryName = "Yazılım" },
            //    new Category { CategoryID = 2, CategoryName = "Kişisel Gelişim" },
            //    new Category { CategoryID = 3, CategoryName = "Teknoloji" },
            //    new Category { CategoryID = 4, CategoryName = "Sanat ve Kültür" },
            //    new Category { CategoryID = 5, CategoryName = "Film ve Dizi" },
            //    new Category { CategoryID = 6, CategoryName = "SeyahatFilm ve Dizi" }
            //);

            //modelBuilder.Entity<Blog>().HasData(
            //    new Blog
            //    {
            //        Id = 1,
            //        Title = "ASP.NET Core ile Web Geliştirme",
            //        Content = "Bu yazıda ASP.NET Core MVC ile nasıl web sitesi yapılır onu anlatacağız.",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 1),
            //        UserId = "1",
            //        CategoryId = 1,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 2,
            //        Title = "Verimli Çalışma Teknikleri",
            //        Content = "Pomodoro, Eisenhower matrisi ve daha fazlası!",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 5),
            //        UserId = "2",
            //        CategoryId = 2,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 3,
            //        Title = "2024’te Takip Edilmesi Gereken Teknoloji Trendleri",
            //        Content = "Yapay zeka, kuantum bilgisayarlar ve daha fazlası.",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "3",
            //        CategoryId = 4,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 4,
            //        Title = "Yazılımda Temiz Kod Yazma Prensipleri",
            //        Content = "Kod yazmak sadece çalıştırmak için değil, sürdürülebilirlik için de yapılır. Temiz kod; okunabilir, anlaşılabilir ve kolay test edilebilir olmalıdır. Bu yazıda SOLID prensiplerinden, yorum satırı kullanımından ve refactoring örneklerinden bahsedeceğiz.",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "3",
            //        CategoryId = 4,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 5,
            //        Title = "Girişimcilik Yolculuğuna Nereden Başlamalı?",
            //        Content = "Bir fikrin var ama nereden başlayacağını bilmiyor musun? Girişimcilik; problem belirleme, çözüm üretme ve doğru ekibi kurma yolculuğudur. İlk adım, pazarı anlamak ve doğru zamanlamayı yakalamaktır. Bu yazıda ilk MVP'nin nasıl oluşturulacağına dair ipuçları veriyoruz.\r\n\r\n",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "3",
            //        CategoryId = 4,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 6,
            //        Title = "ASP.NET Core ile JWT Authentication Kullanımı",
            //        Content = "Web API'lerde kullanıcı doğrulama işlemi için en çok tercih edilen yöntemlerden biri JWT'dir. Token üretimi, doğrulama ve middleware kullanımıyla adım adım güvenli bir yapı kurmayı öğreneceğiz.",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "3",
            //        CategoryId = 4,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 7,
            //        Title = "Günlük Rutinler ile Verimliliği Arttırmak",
            //        Content = "Her gün yapılacaklar listesini düzenli olarak oluşturmak ve uyumadan önce günü değerlendirmek, zaman yönetimini büyük ölçüde geliştirir. Bu yazıda 21 gün kuralı ile alışkanlık oluşturmanın yollarını paylaşıyoruz.",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "4",
            //        CategoryId = 2,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 8,
            //        Title = "Avrupa Interrail Maceram: 10 Günde 5 Ülke",
            //        Content = "Yıllardır hayalini kurduğum Interrail yolculuğuna sonunda çıktım! Amsterdam’dan başlayıp Roma’da bitirdiğim 10 günlük gezimde yaşadığım deneyimleri, tren biletleri alırken dikkat edilmesi gerekenleri ve favori şehirlerimi bu yazıda paylaşıyorum.\r\n\r\n",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "4",
            //        CategoryId = 5,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 9,
            //        Title = "Modern Sanatta Anlam Arayışı",
            //        Content = "Bir tabloya baktığında hiçbir şey anlayamıyor musun? Yalnız değilsin. Modern sanatın anlatmak istediklerine farklı bir bakış açısıyla yaklaşmak gerek. Bu yazımda Picasso’dan Banksy’ye kadar çeşitli eserlerin ardındaki hikayelere değindim.",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "3",
            //        CategoryId = 6,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 10,
            //        Title = "Kapadokya'nın Sırları: Balonlardan Yeraltı Şehirlerine",
            //        Content = "Kapadokya sadece balonlar değil! Derinkuyu Yeraltı Şehri’nden Göreme Açık Hava Müzesi’ne uzanan bu yazımda, bölgenin tarihi dokusunu ve kültürel mirasını anlattım. Ayrıca yöresel lezzetler ve önerdiğim rotaları da kaçırmayın!",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "5",
            //        CategoryId = 5,
            //        Image = "/images/aspnet-logo.jpg"
            //    },
            //    new Blog
            //    {
            //        Id = 11,
            //        Title = "En İyi Bilim Kurgu Dizileri – 2025 Güncellemesi",
            //        Content = "Black Mirror’dan Dark’a, Andor’dan 3 Body Problem’e kadar aklını zorlayacak bilim kurgu dizilerini sıraladım. Spoiler’sız öneri isteyenler için birebir!",
            //        Author = "Ceyda Kesgin",
            //        PublishedAt = new DateTime(2024, 6, 8),
            //        UserId = "5",
            //        CategoryId = 7,
            //        Image = "/images/aspnet-logo.jpg"
            //    }

            //);

        }
    }
}
