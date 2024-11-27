using System;

namespace UrunAlimSatim
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ürün bilgilerini saklamak için sabit diziler
            int[] urunId = new int[100];
            string[] urunIsim = new string[100];
            decimal[] urunFiyat = new decimal[100];
            int[] urunStok = new int[100];

            int mevcutUrunSayisi = 0;
            int idSayaci = 1;

            // Gün sonu raporu için değişkenler
            int toplamAlinanAdet = 0;
            int toplamSatilanAdet = 0;

            while (true)
            {
                Console.WriteLine("\n--- Ürün Yönetim Sistemi ---");
                Console.WriteLine("1. Ürün Ekle");
                Console.WriteLine("2. Ürün Alımı");
                Console.WriteLine("3. Ürün Satışı");
                Console.WriteLine("4. Ürün Listesi");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    // Ürün ekleme
                    Console.Write("Ürün ismi: ");
                    urunIsim[mevcutUrunSayisi] = Console.ReadLine();
                    Console.Write("Ürün fiyatı: ");
                    urunFiyat[mevcutUrunSayisi] = decimal.Parse(Console.ReadLine());
                    Console.Write("Stok miktarı: ");
                    urunStok[mevcutUrunSayisi] = int.Parse(Console.ReadLine());

                    urunId[mevcutUrunSayisi] = idSayaci++;
                    mevcutUrunSayisi++;

                    Console.WriteLine("Ürün başarıyla eklendi!");
                }
                else if (secim == "2")
                {
                    // Ürün alımı
                    Console.WriteLine("\n--- Ürün Listesi ---");
                    for (int i = 0; i < mevcutUrunSayisi; i++)
                    {
                        Console.WriteLine($"ID: {urunId[i]}, İsim: {urunIsim[i]}, Fiyat: {urunFiyat[i]:C}, Stok: {urunStok[i]}");
                    }

                    Console.Write("Almak istediğiniz ürün ID'sini girin: ");
                    int alinanId = int.Parse(Console.ReadLine());
                    Console.Write("Kaç adet almak istiyorsunuz? ");
                    int alinanAdet = int.Parse(Console.ReadLine());

                    for (int i = 0; i < mevcutUrunSayisi; i++)
                    {
                        if (urunId[i] == alinanId)
                        {
                            urunStok[i] += alinanAdet;
                            toplamAlinanAdet += alinanAdet;
                            Console.WriteLine($"{alinanAdet} adet {urunIsim[i]} başarıyla alındı. Yeni stok: {urunStok[i]}");
                            break;
                        }
                    }
                }
                else if (secim == "3")
                {
                    // Ürün satışı
                    Console.WriteLine("\n--- Ürün Listesi ---");
                    for (int i = 0; i < mevcutUrunSayisi; i++)
                    {
                        Console.WriteLine($"ID: {urunId[i]}, İsim: {urunIsim[i]}, Fiyat: {urunFiyat[i]:C}, Stok: {urunStok[i]}");
                    }

                    Console.Write("Satmak istediğiniz ürün ID'sini girin: ");
                    int satilanId = int.Parse(Console.ReadLine());
                    Console.Write("Kaç adet satmak istiyorsunuz? ");
                    int satilanAdet = int.Parse(Console.ReadLine());

                    for (int i = 0; i < mevcutUrunSayisi; i++)
                    {
                        if (urunId[i] == satilanId)
                        {
                            if (urunStok[i] >= satilanAdet)
                            {
                                urunStok[i] -= satilanAdet;
                                toplamSatilanAdet += satilanAdet;
                                decimal toplamKazanc = satilanAdet * urunFiyat[i];
                                Console.WriteLine($"{satilanAdet} adet {urunIsim[i]} başarıyla satıldı. Toplam kazanç: {toplamKazanc:C}. Yeni stok: {urunStok[i]}");
                            }
                            else
                            {
                                Console.WriteLine("Yeterli stok yok!");
                            }
                            break;
                        }
                    }
                }
                else if (secim == "4")
                {
                    // Ürün listesini görüntüleme
                    Console.WriteLine("\n--- Ürün Listesi ---");
                    for (int i = 0; i < mevcutUrunSayisi; i++)
                    {
                        Console.WriteLine($"ID: {urunId[i]}, İsim: {urunIsim[i]}, Fiyat: {urunFiyat[i]:C}, Stok: {urunStok[i]}");
                    }
                }
                else if (secim == "5")
                {
                    // Çıkış
                    Console.WriteLine("\n--- Gün Sonu Raporu ---");
                    Console.WriteLine($"Toplam alınan ürün miktarı: {toplamAlinanAdet}");
                    Console.WriteLine($"Toplam satılan ürün miktarı: {toplamSatilanAdet}");
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                }
            }
        }
    }
}