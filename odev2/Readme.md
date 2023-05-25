# Odev2

Bu proje, Staff (Personel) verilerini yönetmek için bir Web API hizmeti saðlar. Proje, Entity Framework ile Generic Repository ve Unit of Work desenini kullanýr.

## Kurulum

1. Projenin kaynak kodunu indirin veya klonlayýn.
2. `appsettings.json` dosyasýnda veritabaný baðlantý bilgilerini güncelleyin.
3. Projeyi derleyin ve çalýþtýrýn.

## API Endpoint'leri

- GET /OdevApi/Staff: Tüm personel kayýtlarýný getirir.
- GET /OdevApi/Staff/filter/{firstNameFilter}: Ýstenilen isme göre personel kayýtlarýný getirir.
- GET /OdevApi/Staff/{id}: Belirli bir personel kaydýný ID'ye göre getirir.
- POST /OdevApi/Staff: Yeni bir personel kaydý oluþturur.
- PUT /OdevApi/Staff/{id}: Mevcut bir personel kaydýný günceller.
- DELETE /OdevApi/Staff/{id}: Belirli bir personel kaydýný siler.

## Model Validasyonu

PUT ve POST isteklerinde model validasyonu yapýlýr. Fluent Validation kütüphanesi kullanýlarak gelen isteklerin geçerliliði kontrol edilir. Hatalý bir istek durumunda uygun hata mesajlarý döndürülür.

## Filtreleme

GET /OdevApi/Staff/filter/{firstNameFilter} API'si, isme göre personel kayýtlarýný filtreler. Ýstenilen ismi firstNameFilter parametresiyle birlikte göndererek sorgu sonucunu alabilirsiniz.

## Veritabaný Migration

Bu projede veritabaný yönetimi için Entity Framework kullanýlmaktadýr. Ýlk migration dosyasýný oluþturmak için aþaðýdaki adýmlarý takip edin:

1. Package Manager Console'ý açýn.
2. Default proje olarak OdevData projesini seçin.
3. komutu çalýþtýrýn: Add-Migration InitialCreate
4. Migration dosyasý oluþturulduktan sonra update komutunu çalýþtýrarak veritabanýný güncelleyin: Update-Database

Bu, veritabanýnda gerekli tablolarýn ve iliþkilerin oluþturulmasýný saðlar.

## Katmanlý Mimaride Kullanýlan Sýnýflar

- OdevData.Domain.Staff: Personel verilerini temsil eden sýnýf.
- OdevData.Repository.Staffs.IStaffRepository: Personel verileri için CRUD iþlemlerini tanýmlayan arayüz.
- OdevData.Repository.Staffs.StaffRepository: Personel verileri için CRUD iþlemlerini gerçekleþtiren sýnýf.
- Odev2Service.Controllers.StaffController: Personel verilerini yönetmek için API endpoint'lerini saðlayan controller sýnýfý.
- Odev2Schema.Staff.StaffRequest: Yeni personel kaydý oluþturmak için kullanýlan istek modeli.
- Odev2Schema.Staff.StaffResponse: Personel verilerini döndürmek için kullanýlan yanýt modeli.

## DI (Dependency Injection) ve AutoMapper

Bu projede DI ve AutoMapper kullanýlmaktadýr. StaffController sýnýfýnda IStaffRepository ve IMapper arayüzlerine enjekte edilmiþtir. Baðýmlýlýklar otomatik olarak çözümlenir ve AutoMapper, model dönüþümlerini kolaylaþtýrmak için kullanýlýr.

## SOLID Prensiplerine Uygunluk

Bu proje SOLID prensiplerine uygun olarak tasarlanmýþtýr. Her bir sýnýfýn tek bir sorumluluðu vardýr ve baðýmlýlýklar enjeksiyon ile yönetilir.