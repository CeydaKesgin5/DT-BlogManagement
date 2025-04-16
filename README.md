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

![Register](https://github.com/user-attachments/assets/8772ad59-494c-4570-baaa-2c55b4aa69bd)
![BlogList](https://github.com/user-attachments/assets/b3a5b10b-fca0-491b-bdd8-0d3b3e7c3582)
![Create](https://github.com/user-attachments/assets/00320bee-26ef-42b7-aaa9-6955f8370849)
![Admin Panel](https://github.com/user-attachments/assets/0af55128-b79b-499b-895d-6fd0bc1d0f8e)
![Categories](https://github.com/user-attachments/assets/06b563bb-fc65-4f06-8e29-49ba0e4768ad)
![UserList](https://github.com/user-attachments/assets/7261e824-528b-49ba-87c6-224088fead5e)
![Comments](https://github.com/user-attachments/assets/7aa4dc2b-0f50-4314-81f1-ce7d1005ae17)




