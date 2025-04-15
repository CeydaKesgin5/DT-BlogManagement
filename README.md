# DT-BlogManagement

Bu proje, Doğuş Teknoloji Bootcamp kapsamında geliştirilmiştir. Proje sürecinde **ASP.NET Core MVC, Entity Framework Core, Razor Pages, SOLID prensipleri** ve modern web teknolojileri kullanılmıştır. IService, IRepository gibi interface’ler üzerinden uygulama loosely coupled hale getirilmiştir.

## 🔍 Proje Özeti

Kullanıcıların blog yazılarını oluşturabildiği, okuyabildiği ve yönetebildiği bir blog platformudur. Sistemde kullanıcı kimlik doğrulaması yapılır ve yetkili kullanıcılar blog gönderileri üzerinde tam kontrol sahibi olur.

## Özellikler

### Kullanıcı Yönetimi
- Kullanıcı Kayıt / Giriş / Çıkış
- **Cookie Authentication**
- Yetkilendirme (sadece giriş yapan kullanıcılar içerik oluşturabilir)
- Admin User, Blog, Category hakkında detaylı bilgilere ulaşabilir.

### Blog Yönetimi
- CRUD (Create, Read, Update, Delete) işlemleri
- Başlık, içerik, yazar, yayınlanma tarihi ve kategori bilgileri
- **Görsel yükleme**
- Yayınlanma tarihine göre sıralama yapılabilir

### Kategori Sistemi
- Blog yazıları kategorilere ayrılır
- **Kategoriye göre filtreleme yapılabilir**
- Admin Panel'de kategorilere ait detaylı bilgilere ulaşılabilir.

### Yorum Sistemi
- Giriş yapan kullanıcılar yorum bırakabilir
- Giriş yapan kullanıcılar sadece kendi yorumlarını silebilir.
  

### Sayfa Yapısı ve Tasarım
- Bootstrap 5 kullanılarak arayüz
- Razor Pages ile dinamik sayfalar
- **Layout, Partial View ve Section yapısı**

### Form İşlemleri ve Validations
- Model Validations

### Ekstra Özellikler
- **Area / Admin Panel:**
  - User bilgilerini listeler, siler.
  - Blog yazılarına ve kategorilere detaylı erişim sağlar, CRUD işlemlerini gerçekleştirir.
- Bloglar yayınlanma tarihine göre sıralama yapılabilir.
- **Notification:** Kullanıcılara belirli işlemler sonrasında sistem bildirimleri gösterilir.
- Seed Data
- TempData ve ViewBag


## Kullanılan Teknolojiler

- ASP.NET Core MVC
- Entity Framework Core
- MsSQL
- Razor Pages
- Bootstrap
- LibMan (Client Packages)
- Cookie Middleware
- SOLID Prensipleri
- Dependency Injection
- Repository Pattern
- Microservice Architecture
- ASP.NET Core Identity
- AutoMapper
- View Component
- ViewModel





