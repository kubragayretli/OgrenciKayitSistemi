using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OgrenciDersYonetimSistemi
{
    // Base class for shared properties and methods
    public abstract class Kisi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public abstract void BilgiGoster();
    }

    // Interface
    public interface IKayit
    {
        void Kaydet();
        void Yukle();
    }

    // Derived class: Ogrenci
    public class Ogrenci : Kisi, IKayit
    {
        public List<int> Dersler { get; set; } = new List<int>();

        public override void BilgiGoster()
        {
            Console.WriteLine($"Ogrenci ID: {Id}, Ad: {Ad}, Soyad: {Soyad}");
        }

        public void Kaydet()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText($"Ogrenci_{Id}.json", json);
        }

        public void Yukle()
        {
            if (File.Exists($"Ogrenci_{Id}.json"))
            {
                string json = File.ReadAllText($"Ogrenci_{Id}.json");
                var ogrenci = JsonSerializer.Deserialize<Ogrenci>(json);
                Ad = ogrenci.Ad;
                Soyad = ogrenci.Soyad;
                Dersler = ogrenci.Dersler;
            }
        }

        public static Ogrenci Olustur()
        {
            Console.WriteLine("Ogrenci ID girin:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ogrenci Adı girin:");
            string ad = Console.ReadLine();

            Console.WriteLine("Ogrenci Soyadı girin:");
            string soyad = Console.ReadLine();

            var yeniOgrenci = new Ogrenci { Id = id, Ad = ad, Soyad = soyad };
            yeniOgrenci.Kaydet();

            Console.WriteLine("Ogrenci başarıyla oluşturuldu ve kaydedildi.");
            return yeniOgrenci;
        }
    }

    // Derived class: OgretimGorevlisi
    public class OgretimGorevlisi : Kisi, IKayit
    {
        public List<int> Dersler { get; set; } = new List<int>();

        public override void BilgiGoster()
        {
            Console.WriteLine($"Ogretim Gorevlisi ID: {Id}, Ad: {Ad}, Soyad: {Soyad}");
        }

        public void Kaydet()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText($"OgretimGorevlisi_{Id}.json", json);
        }

        public void Yukle()
        {
            if (File.Exists($"OgretimGorevlisi_{Id}.json"))
            {
                string json = File.ReadAllText($"OgretimGorevlisi_{Id}.json");
                var ogretimGorevlisi = JsonSerializer.Deserialize<OgretimGorevlisi>(json);
                Ad = ogretimGorevlisi.Ad;
                Soyad = ogretimGorevlisi.Soyad;
                Dersler = ogretimGorevlisi.Dersler;
            }
        }
    }

    // Course class
    public class Ders
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int Kredi { get; set; }
        public int OgretimGorevlisiId { get; set; }
        public List<int> KayitliOgrenciler { get; set; } = new List<int>();

        public void Kaydet()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText($"Ders_{Id}.json", json);
        }

        public static Ders Yukle(int id)
        {
            if (File.Exists($"Ders_{id}.json"))
            {
                string json = File.ReadAllText($"Ders_{id}.json");
                return JsonSerializer.Deserialize<Ders>(json);
            }
            return null;
        }

        public void BilgiGoster()
        {
            Console.WriteLine($"Ders ID: {Id}, Ad: {Ad}, Kredi: {Kredi}, Ogretim Gorevlisi ID: {OgretimGorevlisiId}");
            Console.WriteLine("Kayitli Ogrenciler: " + string.Join(", ", KayitliOgrenciler));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Öğrenci ve Ders Yönetim Sistemi");

            // Kullanıcı seçim menüsü
            while (true)
            {
                Console.WriteLine("Lütfen bir işlem seçin:");
                Console.WriteLine("1. Yeni Öğrenci Oluştur");
                Console.WriteLine("2. Mevcut Öğrenci Bilgilerini Yükle ve Göster");
                Console.WriteLine("3. Çıkış");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Ogrenci.Olustur();
                        break;

                    case "2":
                        Console.WriteLine("Yüklemek istediğiniz öğrenci ID'sini girin:");
                        int id = int.Parse(Console.ReadLine());

                        Ogrenci yuklenenOgrenci = new Ogrenci { Id = id };
                        yuklenenOgrenci.Yukle();
                        yuklenenOgrenci.BilgiGoster();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }
    }
}
