# Sistem Manajemen Produk & Pesanan

Proyek ini adalah RESTful API** yang digunakan untuk mengelola **Produk** dan **Pesanan**.  
Struktur proyek menggunakan arsitektur terpisah (Controller, Services, Models, Validator) agar mudah dipelihara dan dikembangkan.  

---

## Fitur Utama

### Autentikasi
- Menggunakan **Basic Authentication Handler** untuk keamanan endpoint API.  

### Manajemen Produk
- Tambah Produk  
- Lihat Daftar Produk  
- Update Produk  
- Hapus Produk  

### Manajemen Pesanan
- Tambah Pesanan  
- Lihat Daftar Pesanan  
- Update Pesanan  
- Hapus Pesanan  

### Response Handling
- Setiap request akan mengembalikan format response standar menggunakan `GeneralResponse`.  

---

## Teknologi yang Digunakan
- **ASP.NET Core 6 / 7** (Web API)  
- **Entity Framework Core** (ORM untuk database)  
- **C#** sebagai bahasa pemrograman  
- **Migrations** untuk pengelolaan skema database  
- **DTO (Data Transfer Object)** untuk memisahkan data model & API response  
