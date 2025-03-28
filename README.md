# 🚀 Setup Proyek

Dokumen ini menjelaskan langkah-langkah untuk menjalankan proyek setelah meng-clone repositori.

## 📥 Clone Repositori
Pastikan Git sudah terinstall, lalu jalankan perintah berikut:
```sh
git clone <URL_REPOSITORI>
cd <NAMA_REPOSITORI>
```

## 🛠️ Prasyarat
Pastikan Anda memiliki:
- **.NET SDK 9** atau versi yang sesuai
- **Docker & Docker Compose**
- **SQL Server** (bisa menggunakan Docker)
- **RabbitMQ** (bisa menggunakan Docker)

## 📂 Konfigurasi
1. **Buat file `.env` di root proyek dan isi dengan variabel berikut:**
   ```sh
   SA_PASSWORD=<YourStrong!Passw0rd>
   DB_CONNECTION=Server=sqlserver;Database=QueueDB;User Id=sa;Password=<YourStrong!Passw0rd>;TrustServerCertificate=Yes
   RABBITMQ_DEFAULT_USER=guest
   RABBITMQ_DEFAULT_PASS=guest
   ```
2. **Periksa file `appsettings.json` untuk memastikan konfigurasi benar.**

## 🐳 Menjalankan Aplikasi
Jalankan setiap service secara terpisah atau gunakan Docker:
```sh
docker compose up -d
```

## 🏗️ Menjalankan Migrasi Database
Jika ini pertama kali menjalankan proyek, lakukan migrasi database:
```sh
cd Shared
dotnet ef database update
```

## 🔧 Troubleshooting
- **Masalah koneksi SQL Server?** Pastikan kontainer sudah berjalan dengan `docker ps` dan coba `docker logs sqlserver`.
- **Masalah RabbitMQ?** Periksa `docker logs rabbitmq` dan pastikan RabbitMQ berjalan dengan benar.
- **Masalah saat menjalankan migrasi?** Pastikan koneksi database di `appsettings.json` sudah benar.

---


