# DT-BlogManagement

Proje sürecinde **ASP.NET Core MVC, Entity Framework Core, Razor Pages, SOLID prensipleri** ve modern web teknolojileri kullanılmıştır. IService, IRepository gibi interface’ler üzerinden uygulama loosely coupled hale getirilmiştir.

## Proje Özeti

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

## 🔍Ekstra Özellikler
- **Area / Admin Panel:**
  - User bilgilerini listeler, siler.
  - Blog yazılarına ve kategorilere detaylı erişim sağlar, CRUD işlemlerini gerçekleştirir.
  - Yorum silme yetkisine sahiptir.
- Bloglar yayınlanma tarihine göre sıralama yapılabilir.
- **Notification:** Kullanıcılara belirli işlemler sonrasında sistem bildirimleri gösterilir.
- Kullanıcılar bloglarını ve kayıt bilgilerini görüntüleyebilir.


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
+ Microservice Architecture
+ ASP.NET Core Identity
+ AutoMapper
+ View Component
+ ViewModel
**YouTube Link:** https://youtu.be/nCJZg3YRMlg
  
> `appsettings.json` dosyasındaki gerekli düzemleme yapılması gerekmektedir. (Server=...;)

**Register**
![register](https://github.com/user-attachments/assets/1ebcd76f-e77b-4312-8833-109608b86464)

**Login**
![login](https://github.com/user-attachments/assets/dc1d607f-ac8f-4045-980a-f7a304a5a4dc)

**Blog List**
![BlogList](https://github.com/user-attachments/assets/7453ec12-4a4c-4ff0-929f-2888fe32973a)

**Create Blog**
![CreateBlog](https://github.com/user-attachments/assets/a7dee27d-e980-4984-abd4-622c4e7c395d)

**Update Blog**
![UpdateBlog](https://github.com/user-attachments/assets/4c14dde1-8a09-4c77-a985-728e3294c412)

**Admin Panel**
![AdminPage](https://github.com/user-attachments/assets/83f05fb3-e2f1-46ad-b1d1-d5de79089b48)

**Category Operations**
![Categories](https://github.com/user-attachments/assets/06b563bb-fc65-4f06-8e29-49ba0e4768ad)

**User List**
![UserPage](https://github.com/user-attachments/assets/7d835702-efc1-492e-8130-4609a2cc297e)

**User's Blogs**
![usersblog](https://github.com/user-attachments/assets/d5dc3b53-3851-4754-b653-05525d05f6fa)

**Profile**
![profile](https://github.com/user-attachments/assets/b68d1c61-3b74-424e-847d-ba809b9ad193)

**Comments**
![Comments](https://github.com/user-attachments/assets/7aa4dc2b-0f50-4314-81f1-ce7d1005ae17)




