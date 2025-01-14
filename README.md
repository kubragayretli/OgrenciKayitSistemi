Proje Açıklaması

Ogrenci ve Ders Yönetim Sistemi, bir eğitim kurumunda öğrenci ve ders yönetimini kolaylaştırmak amacıyla geliştirilmiş bir C# uygulamasıdır. Uygulama, JSON formatında veri saklama, veri yükleme, ve kullanıcı dostu bir arayüz ile temel yönetim işlemlerini gerçekleştirmeyi sağlar.

  Özellikler

Kişiler
Ogrenci ve OgretimGorevlisi sınıfları ile kişilerin yönetimi.
Ad, soyad ve ID bilgilerini içerir.
Öğrenciler ve öğretim görevlileri JSON formatında kaydedilir ve yüklenebilir.

Dersler
Ders sınıfı ile ders bilgileri yönetilir.
Ders ID, ders adı, kredi bilgileri, ve öğretim görevlisi ID bilgilerini içerir.
Derslere kayıtlı öğrenciler listelenebilir ve JSON formatında saklanabilir.

JSON Tabanlı Veri Saklama
Kişi ve ders bilgileri JSON formatında dosyalara kaydedilir ve gerektiğinde yüklenir.

Kullanıcı Arayüzü
Konsol tabanlı kullanıcı arayüzü ile kullanıcılar işlemlerini kolayca gerçekleştirebilir.

  Kullanım Kılavuzu

Uygulama Menüsü
Uygulama başlatıldığında aşağıdaki seçenekler sunulur:

Yeni Öğrenci Oluştur
Kullanıcıdan öğrenci bilgileri alınır (ID, ad, soyad).
Öğrenci oluşturulur ve JSON dosyasına kaydedilir.

Mevcut Öğrenci Bilgilerini Yükle ve Göster
Kullanıcıdan öğrenci ID'si alınır.
JSON dosyasından öğrenci bilgileri yüklenir ve ekrana yazdırılır.

Çıkış
Uygulama sonlandırılır.

  Gereksinimler

.NET 6.0 veya üzeri.

JSON dosyalarının okunup yazılabileceği bir dosya sistemi.
