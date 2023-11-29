Rehber rehber = new Rehber();

while (true)
{
    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
    Console.WriteLine("*******************************************");
    Console.WriteLine("(1) Yeni Numara Kaydetmek");
    Console.WriteLine("(2) Varolan Numarayi Silmek");
    Console.WriteLine("(3) Varolan Numarayi Güncelleme");
    Console.WriteLine("(4) Rehberi Listelemek");
    Console.WriteLine("(5) Rehberde Arama Yapmak");

    int secim = Convert.ToInt32(Console.ReadLine());

    switch (secim)
    {
        case 1:
            rehber.numaraKaydet();
            break;
        case 2:
            rehber.numaraSil();
            break;
        case 3:
            rehber.numaraGuncelle();
            break;
        case 4:
            rehber.rehberiListele();
            break;
        case 5:
            rehber.rehberArama();
            break;
        default:
            Console.WriteLine("Geçersiz bir seçim yaptiniz. Sadece listedeki içerikleri seçiniz.");
            break;
    }
}           