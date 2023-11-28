namespace Class
{
	public class Program
	{
		static void Main(string[] args)
		{
			// Söz dizimi
			// class sinifAdi
			//{
			//[Erişim belirleyici] [Veri tipi] OzellikAdi;
			//[Erişim belirleyici] [Geri dönüş tipi] MetotAdi([Parametre Listesi])
			//{
			//Metot komutları
			//}
			//}

			//Erişim belirleyiciler
			// * Public
			// * Private
			// * Internal
			// * Protected
			
			Calisan calisan1 =  new Calisan();
			calisan1.Ad = "Ali";
			calisan1.Soyad = "Ezer";
			calisan1.No = 4654512;
			calisan1.Departman = "IT";
			calisan1.CalisanBilgileri();

			Console.WriteLine("-----------------------------");
			Calisan calisan2 = new Calisan();
			calisan2.Ad = "Aleyna";
			calisan2.Soyad = "Ezici";
			calisan2.No = 4454545;
			calisan2.Departman = "Finans";
			calisan2.CalisanBilgileri();

		}

		class Calisan
		{
			public string Ad;
			public string Soyad;
			public int No;
			public string Departman;

			public void CalisanBilgileri()
			{
				Console.WriteLine("Çalışanın Adı: {0}", Ad);
				Console.WriteLine("Çalışanın Soyadı: {0}", Soyad);
				Console.WriteLine("Çalışanın Numarası: {0}", No);
				Console.WriteLine("Çalışanın Departmanı: {0}", Departman);
			}
		}
	}
}