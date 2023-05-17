# Odev2

Bu proje, Staff (Personel) verilerini y�netmek i�in bir Web API hizmeti sa�lar. Proje, Entity Framework ile Generic Repository ve Unit of Work desenini kullan�r.

## Kurulum

1. Projenin kaynak kodunu indirin veya klonlay�n.
2. `appsettings.json` dosyas�nda veritaban� ba�lant� bilgilerini g�ncelleyin.
3. Projeyi derleyin ve �al��t�r�n.

## API Endpoint'leri

- GET /OdevApi/Staff: T�m personel kay�tlar�n� getirir.
- GET /OdevApi/Staff/filter/{firstNameFilter}: �stenilen isme g�re personel kay�tlar�n� getirir.
- GET /OdevApi/Staff/{id}: Belirli bir personel kayd�n� ID'ye g�re getirir.
- POST /OdevApi/Staff: Yeni bir personel kayd� olu�turur.
- PUT /OdevApi/Staff/{id}: Mevcut bir personel kayd�n� g�nceller.
- DELETE /OdevApi/Staff/{id}: Belirli bir personel kayd�n� siler.

## Model Validasyonu

PUT ve POST isteklerinde model validasyonu yap�l�r. Fluent Validation k�t�phanesi kullan�larak gelen isteklerin ge�erlili�i kontrol edilir. Hatal� bir istek durumunda uygun hata mesajlar� d�nd�r�l�r.

## Filtreleme

GET /OdevApi/Staff/filter/{firstNameFilter} API'si, isme g�re personel kay�tlar�n� filtreler. �stenilen ismi firstNameFilter parametresiyle birlikte g�ndererek sorgu sonucunu alabilirsiniz.

## Veritaban� Migration

Bu projede veritaban� y�netimi i�in Entity Framework kullan�lmaktad�r. �lk migration dosyas�n� olu�turmak i�in a�a��daki ad�mlar� takip edin:

1. Package Manager Console'� a��n.
2. Default proje olarak OdevData projesini se�in.
3. komutu �al��t�r�n: Add-Migration InitialCreate
4. Migration dosyas� olu�turulduktan sonra update komutunu �al��t�rarak veritaban�n� g�ncelleyin: Update-Database

Bu, veritaban�nda gerekli tablolar�n ve ili�kilerin olu�turulmas�n� sa�lar.

## Katmanl� Mimaride Kullan�lan S�n�flar

- OdevData.Domain.Staff: Personel verilerini temsil eden s�n�f.
- OdevData.Repository.Staffs.IStaffRepository: Personel verileri i�in CRUD i�lemlerini tan�mlayan aray�z.
- OdevData.Repository.Staffs.StaffRepository: Personel verileri i�in CRUD i�lemlerini ger�ekle�tiren s�n�f.
- Odev2Service.Controllers.StaffController: Personel verilerini y�netmek i�in API endpoint'lerini sa�layan controller s�n�f�.
- Odev2Schema.Staff.StaffRequest: Yeni personel kayd� olu�turmak i�in kullan�lan istek modeli.
- Odev2Schema.Staff.StaffResponse: Personel verilerini d�nd�rmek i�in kullan�lan yan�t modeli.

## DI (Dependency Injection) ve AutoMapper

Bu projede DI ve AutoMapper kullan�lmaktad�r. StaffController s�n�f�nda IStaffRepository ve IMapper aray�zlerine enjekte edilmi�tir. Ba��ml�l�klar otomatik olarak ��z�mlenir ve AutoMapper, model d�n���mlerini kolayla�t�rmak i�in kullan�l�r.

## SOLID Prensiplerine Uygunluk

Bu proje SOLID prensiplerine uygun olarak tasarlanm��t�r. Her bir s�n�f�n tek bir sorumlulu�u vard�r ve ba��ml�l�klar enjeksiyon ile y�netilir.