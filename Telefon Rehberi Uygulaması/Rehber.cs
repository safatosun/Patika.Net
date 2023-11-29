class Rehber {
    private List<Numara> rehber;

    public Rehber()
    {
        rehber = new List<Numara>
        {
            new Numara("Ali", "Ezer", "4567894123"),
            new Numara("Aleyna", "Ezici", "4557494783"),
            new Numara("Sıla", "Güleryüz", "4572895203"),
            new Numara("Gülsema", "Kirmizi", "4287894923"),
            new Numara("Doğa", "Erdoğdu", "4534899021"),
        };
    }

     public void numaraKaydet()
    {
        Console.WriteLine("Lütfen isim giriniz:");
        string isim = Console.ReadLine();

        Console.WriteLine("Lütfen soyisim giriniz:");
        string soyisim = Console.ReadLine();

        Console.WriteLine("Lütfen telefon numarasi giriniz:");
        string telefon = Console.ReadLine();
        
        var numara = new Numara(isim, soyisim, telefon);

        rehber.Add(numara);

        Console.WriteLine($"{isim} {telefon} basariyla kayit edildi.");
    }

    public void numaraSil()
    {
        Console.WriteLine("Lütfen numarasini silmek istediğiniz kişinin adini ya da soyadini giriniz:");

        string silenecekKisi = Console.ReadLine() ?? "";

        var kisiler = rehber.Where(kisi => kisi.isim.Contains(silenecekKisi) || kisi.soyisim.Contains(silenecekKisi)).ToList();

        if (kisiler.Count == 0)
        {
        
            Console.WriteLine("Aradiginiz kriterlere uygun veri rehberde bulunamadi. Lütfen bir seçim yapiniz.");
        
            Console.WriteLine("Silmeyi sonlandirmak için : (1)");
        
            Console.WriteLine("Yeniden denemek için : (2)");

            int secim = Convert.ToInt32(Console.ReadLine());
        
            if (secim == 2){
        
                numaraSil();
            }
            else
            {
                Console.WriteLine("Kişi bulunamadiği için silme işlemi sonlandirildi.");
            }
                
        }
        else
        {
            var silinecekKisi = kisiler.FirstOrDefault();

            Console.Write($"{silinecekKisi.isim} isimli kişi rehberden silinmek üzere, onayliyor musunuz? (y/n): ");
            
            var onay = Console.ReadLine();

            if (onay == "y")
            {
                rehber.Remove(silinecekKisi);
                Console.WriteLine("{silinecekKisi.isim} isimli kişi basariyla rehberinizden silindi.");
            }
            else
            {
                Console.WriteLine($" {silinecekKisi.isim} isimli kişinin rehberden silinmesi iptal edildi.");
            }
        }
    }

    public void numaraGuncelle()
    {
        Console.WriteLine("Lütfen numarasini güncellemek istediğiniz kişinin adini ya da soyadini giriniz:");
        
        string guncellencekKisi = Console.ReadLine();

        var kisiler = rehber.Where(numara => numara.isim.Contains(guncellencekKisi) || numara.soyisim.Contains(guncellencekKisi)).ToList();

        if (kisiler.Count == 0)
        {
            Console.WriteLine("Aradiginiz kriterlere uygun veri rehberde bulunamadi. Lütfen bir seçim yapiniz.");
            
            Console.WriteLine("Guncellemeyi sonlandirmak için : (1)");
        
            Console.WriteLine("Yeniden denemek için : (2)");

            int secim = Convert.ToInt32(Console.ReadLine());
        
            if (secim == 2){
        
                numaraGuncelle();
            }
            else
            {
                Console.WriteLine("Kişi bulunamadigi için guncelleme işlemi sonlandirildi.");
            }
        }
        else
        {
            var guncellenecekKisi = kisiler.First();

            var index = rehber.IndexOf(guncellenecekKisi);
            

            Console.WriteLine($"Lütfen yeni isim giriniz (eski isim: {guncellenecekKisi.isim}):");
            guncellenecekKisi.isim = Console.ReadLine();

            Console.WriteLine($"Lütfen yeni soyisim giriniz (eski soyisim: {guncellenecekKisi.soyisim}):");
            guncellenecekKisi.soyisim = Console.ReadLine();

            Console.WriteLine($"Lütfen yeni telefon numarası giriniz (eski numara: {guncellenecekKisi.telefon}):");
            guncellenecekKisi.telefon = Console.ReadLine();

            Console.WriteLine($"{guncellenecekKisi.isim}");

            rehber[index] = guncellenecekKisi;

            Console.WriteLine("Kişi başariyla güncellendi.");

        }
    }

    public void rehberiListele()
    {
        Console.WriteLine("Telefon Rehberi");
        Console.WriteLine("**********************************************");

        foreach (var kisi in rehber)
        {
            Console.WriteLine($"isim: {kisi.isim} Soyisim: {kisi.soyisim} Telefon Numarası: {kisi.telefon}");
        }

        Console.WriteLine("**********************************************");
    
        
    }

     public void rehberArama()
    {
        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
        Console.WriteLine("**************************************");

        Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
        
        Console.WriteLine("Telefon numarisina göre arama yapmak için: (2)");

        int secim;
        secim = Convert.ToInt32(Console.ReadLine());
        switch (secim)
        {
            case 1:
                Console.WriteLine("Lütfen isim veya soyisim giriniz:");

                string arananKisi = Console.ReadLine();
                
                var kisiSonuclar = rehber.Where(kisi => kisi.isim.Contains(arananKisi) || kisi.soyisim.Contains(arananKisi)).ToList();
                
                Console.WriteLine("Arama Sonuçlariniz:");
                Console.WriteLine("**********************************************");
                
                if(kisiSonuclar.Count == 0){
                    Console.WriteLine("Aradiginiz kisi bulanamadi");
                }

                foreach (var kisi in kisiSonuclar)
                {
                    Console.WriteLine($"isim: {kisi.isim} Soyisim: {kisi.soyisim} Telefon Numarası: {kisi.telefon}");
                }

                break;
            
            case 2:

                 Console.WriteLine("Lütfen telefon numarası giriniz:");
                
                string arananTelefon = Console.ReadLine();
                
                var telefonSonuclar = rehber.Where(kisi => kisi.telefon.Contains(arananTelefon)).ToList();
               
                Console.WriteLine("Arama Sonuçlariniz:");
                Console.WriteLine("**********************************************");
                
                if(telefonSonuclar.Count == 0){
                    Console.WriteLine("Aradiginiz kisi bulanamadı");
                }

                foreach (var kisi in telefonSonuclar)
                {
                    Console.WriteLine($"isim: {kisi.isim} Soyisim: {kisi.soyisim} Telefon Numarasi: {kisi.telefon}");
                }
                break;
            
            default:
                Console.WriteLine("Geçersiz bir seçim yaptiniz. Lütfen tekrar deneyin.");
                break;
        }
        
    }

}