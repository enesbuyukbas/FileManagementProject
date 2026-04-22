# FileManagementProject

Kurumsal dosya paylaşımı, çalışan/departman yönetimi ve güvenli erişim akışlarını tek bir backend altında birleştiren katmanlı **ASP.NET Core Web API** projesi.

Bu proje; kullanıcı kimlik doğrulama, rol bazlı yetkilendirme altyapısı, organizasyon yapısının modellenmesi, çalışan CRUD işlemleri, departman hiyerarşisi, dosya yükleme, pagination, logging ve cache gibi gerçek backend geliştirme ihtiyaçlarını aynı çatı altında toplar.

---

## Proje Özeti

FileManagementProject, şirket içinde ortak paylaşılan dosyaların ve çalışanların organizasyon yapısına göre yönetilmesini hedefleyen bir API uygulamasıdır.

Temel odak noktaları:

- Kullanıcıların güvenli şekilde sisteme giriş yapabilmesi
- Çalışan ve departman bilgilerinin merkezi olarak yönetilebilmesi
- Organizasyon yapısının hiyerarşik olarak temsil edilebilmesi
- Dosya yükleme akışlarının yönetilebilmesi
- Performans ve bakım kolaylığı için katmanlı mimari uygulanması

Bu yönüyle proje, yalnızca CRUD odaklı basit bir API değil; gerçek hayattaki kurumsal ihtiyaçlara yaklaşan daha kapsamlı bir backend çalışmasıdır.

---

## Öne Çıkan Özellikler

### Authentication & Security
- ASP.NET Identity tabanlı kullanıcı yönetimi
- JWT Authentication desteği
- Refresh Token akışı
- Rol bazlı authorization altyapısı
- Swagger üzerinden yetkili test edebilme yapısı

### Employee Management
- Çalışan listeleme
- Tek çalışan getirme
- Çalışan ekleme
- Çalışan güncelleme
- Çalışan silme
- Çalışanın bağlı olduğu departman bilgisini getirme
- Query string ile filtreleme ve sayfalama

### Department Structure
- Tüm departmanları listeleme
- Belirli bir departmanı alt yapısıyla birlikte dönebilme
- Departman güncelleme
- Parent-Child ilişkisine uygun organizasyon yaklaşımı

### File Upload
- `IFormFile` ile dosya yükleme
- `Media` klasörüne fiziksel dosya kaydı
- Dosya adı, kayıt yolu ve boyut bilgisinin response olarak dönülmesi

### Observability & Stability
- NLog ile loglama
- Action filter tabanlı request logging
- Merkezi exception middleware yapısı
- Daha temiz ve kontrol edilebilir hata yönetimi

### Performance
- Redis cache entegrasyonu
- Çalışan listeleme tarafında pagination metadata üretimi
- Daha ölçeklenebilir veri erişim mantığı için repository/service ayrımı

---

## Mimari Yaklaşım

Proje, okunabilirliği ve sürdürülebilirliği artırmak için katmanlı bir yapı ile geliştirilmiştir.

```text
Client
  ↓
Controllers (Presentation)
  ↓
Services (Business Logic)
  ↓
Repositories (Data Access)
  ↓
EF Core / SQL Server
```

Bu yapı sayesinde:

- business logic controller içinde dağılmaz
- data access katmanı soyutlanır
- test edilebilirlik ve bakım kolaylığı artar
- yeni özellik eklemek daha kontrollü hale gelir

---

## Proje Yapısı

```text
FileManagementProject/
├── FileManagementProject.sln
├── README.md
└── FileManagementProject/
    ├── Entities/
    │   ├── Contracts/
    │   ├── Dtos/
    │   ├── ErrorModel/
    │   ├── Exceptions/
    │   ├── LogModel/
    │   ├── Models/
    │   └── RequestFeatures/
    ├── Extensions/
    ├── Media/
    ├── Migrations/
    ├── Presentation/
    │   ├── ActionFilters/
    │   └── Controllers/
    ├── Properties/
    ├── Repositories/
    ├── Services/
    ├── Utilities/
    │   └── AutoMapper/
    ├── Program.cs
    ├── appsettings.json
    └── nlog.config
```

---

## Teknoloji Stack

### Backend
- **ASP.NET Core Web API** (.NET 6)
- **Entity Framework Core**
- **SQL Server / LocalDB**
- **ASP.NET Identity**
- **JWT Bearer Authentication**
- **AutoMapper**
- **Swagger / Swashbuckle**
- **NLog**
- **Redis Cache**
- **Newtonsoft.Json**
- **System.Linq.Dynamic.Core**

### Tasarım Yaklaşımları
- Dependency Injection
- Repository Pattern
- Service Layer Abstraction
- DTO Mapping
- Middleware-based Exception Handling
- Filter-based Request Logging
- Pagination & Query Parameters

---

## Domain Modelleri

### User
Identity tabanlı kullanıcı modelidir.

İçerdiği alanlar:
- `FirstName`
- `LastName`
- `RefreshToken`
- `RefreshTokenExpiryTime`

### Employee
Çalışan bilgilerini tutar.

İçerdiği alanlar:
- `EmployeeId`
- `EmployeeFirstName`
- `EmployeeLastName`
- `EmployeeEmail`
- `EmployeePassword`
- `EmployeeManagerId`
- `DepartmentId`

### Department
Departman yapısını ve organizasyon hiyerarşisini temsil eder.

İçerdiği alanlar:
- `DepartmentId`
- `DepartmentName`
- `ParentDepartmentId`
- `Employees`

### File
Yüklenen dosyalara ait temel metadata modeli bulunur.

İçerdiği alanlar:
- `FileId`
- `FileName`
- `FilePath`
- `OwnerId`
- `UploadTime`
- `DepartmentId`

---

## API Yüzeyi

### Authentication Endpoints
```http
POST /api/authentication/register
POST /api/authentication/login
POST /api/authentication/refresh
```

### Department Endpoints
```http
GET /api/department
GET /api/department/{id}
PUT /api/department/{id}
```

### Employee Endpoints
```http
GET    /employees
GET    /employee/{id}
GET    /employee/{id}/department
POST   /api/employee/create/{id}
PUT    /api/employee/update/{id}
DELETE /api/employee/delete/{id}
```

### File Endpoints
```http
POST /api/files/upload
```

---

## Authentication Akışı

### Register
Yeni kullanıcı oluşturur. Doğrulama hataları `ModelState` üzerinden döndürülür.

### Login
Kullanıcı doğrulanır. Başarılı durumda token nesnesi üretilir.

### Refresh Token
Süresi dolan access token sonrasında yeni token üretimi için kullanılır.

Bu akış, modern API projelerinde beklenen temel güvenlik modelini kurmak için iyi bir başlangıç sağlar.

---

## Employee Akışı

Employee tarafında proje yalnızca temel CRUD sunmakla kalmaz; aynı zamanda:

- filtrelenebilir listeleme
- sayfalama
- response header içinde pagination metadata dönme
- çalışanın departman bilgisini ayrı endpoint ile alma

senaryolarını da kapsar.

Örnek istek:

```http
GET /employees?PageNumber=1&PageSize=10&requestDepartmentId=2
```

Response header tarafında pagination bilgisi döndürülür:

```http
X-Pagination: {
  "CurrentPage": 1,
  "TotalPage": 3,
  "PageSize": 10,
  "TotalCount": 25,
  "HasPrevious": false,
  "HasPage": true
}
```

Bu yaklaşım, frontend tarafında tablo ve listeleme ekranlarının çok daha sağlıklı çalışmasını sağlar.

---

## Department Hiyerarşisi

Departman controller tarafında iki önemli kullanım senaryosu öne çıkar:

1. tüm departmanları listeleme
2. belirli bir departmanı alt yapısıyla birlikte döndürme

Bu, organizasyon ağacını temsil eden sistemler için önemlidir. Özellikle:

- çalışanların hiyerarşik konumu
- departman bazlı erişim kısıtları
- üst/alt birim ilişkileri

gibi ihtiyaçlarda bu model genişletilmeye uygundur.

---

## Dosya Yükleme Akışı

Dosya yükleme endpoint’i gelen dosyayı sunucu üzerinde `Media` klasörüne kaydeder.

Akış şu şekildedir:

1. request içindeki dosya alınır
2. `Media` klasörü kontrol edilir
3. klasör yoksa oluşturulur
4. dosya fiziksel olarak kaydedilir
5. dosya adı, tam path ve boyut bilgisi response olarak döndürülür

Bu yapı; sonraki versiyonlarda aşağıdaki geliştirmeler için iyi bir temel sunar:

- veritabanına dosya metadata kaydı
- departman bazlı dosya yetkileri
- owner bazlı erişim kontrolü
- bulut depolama entegrasyonu
- dosya versiyonlama

---

## Logging, Exception Handling ve Cache

Projede operasyonel kaliteyi artıran birkaç önemli teknik detay bulunuyor:

### Logging
- NLog konfigürasyonu mevcut
- action filter ile request seviyesinde loglama yapılabiliyor
- hata ve işlem takibi için daha okunabilir bir yapı sunuyor

### Exception Handling
- custom exception middleware bulunuyor
- uygulama genelinde daha merkezi hata kontrolü sağlanıyor

### Cache
- Redis bağlantısı konfigüre edilmiş durumda
- performans iyileştirmesi için cache altyapısı projeye dahil edilmiş

Bu başlıklar, projeyi klasik “öğrenci CRUD API” seviyesinin üstüne çıkaran detaylardan biridir.

---

## Neden Güçlü Bir Proje?

Bu projeyi değerli yapan nokta, birden fazla backend pratiğini tek yapıda toplamasıdır:

- authentication
- authorization
- entity management
- hierarchical data modeling
- pagination
- logging
- caching
- file upload
- layered architecture

Bu kombinasyon, projeyi hem portföy açısından güçlü gösterir hem de gerçek kurumsal backend sistemlerine geçiş için iyi bir temel sunar.

---

## Kurulum

### Gereksinimler
- .NET 6 SDK
- SQL Server veya LocalDB
- Redis
- Git

### 1. Repoyu klonla
```bash
git clone https://github.com/enesbuyukbas/FileManagementProject.git
cd FileManagementProject
```

### 2. Proje klasörüne geç
```bash
cd FileManagementProject
```

### 3. Bağımlılıkları yükle
```bash
dotnet restore
```

### 4. Veritabanını oluştur / migration uygula
```bash
dotnet ef database update
```

### 5. Uygulamayı çalıştır
```bash
dotnet run
```

---

## Konfigürasyon

Temel ayarlar `appsettings.json` içinde bulunur.

```json
{
  "ConnectionStrings": {
    "sqlConnection": "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=fileMnagementApp; Integrated Security=true;",
    "Redis": "localhost:6379"
  },
  "JwtSettings": {
    "validIssuer": "filemanagementapi",
    "validAudience": "http://localhost:3000",
    "secretKey": "your-secret-key",
    "expires": 60
  }
}
```

> Not: Production ortamında secret değerleri doğrudan `appsettings.json` içinde tutulmamalı; environment variable, user secrets veya secret manager yaklaşımı tercih edilmelidir.

---

## Geliştirici

**Enes Büyükbaş**

GitHub: [github.com/enesbuyukbas](https://github.com/enesbuyukbas)
