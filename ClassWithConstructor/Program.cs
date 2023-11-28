namespace Constructor
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
			Console.WriteLine("*****Çalışan 1******");
			Calisan calisan1 = new Calisan("Ali", "Ezer", 464821, "IT");
			calisan1.CalisanBilgileri();

			Console.WriteLine("*****Çalışan 2******");
			Calisan calisan2 = new Calisan();
			calisan2.Ad = "Aleyna";
			calisan2.Soyad = "Ezici";
			calisan2.No = 4545454;
			calisan2.Departman = "Finans";
			calisan2.CalisanBilgileri();

			Console.WriteLine("*****Çalışan 3******");
			Calisan calisan3 = new Calisan("Yaren","Akmaz");
			calisan3.CalisanBilgileri();
			Console.ReadKey();
		}

		class Calisan
		{
			public string Ad;
			public string Soyad;
			public int No;
			public string Departman;

			public Calisan(string ad, string soyad, int no, string departman) 
			{
				this.Ad = ad;
				this.Soyad = soyad;
				this.No = no;
				this.Departman = departman;
			}
			public Calisan() { } 

			public Calisan(string ad, string soyad) 
			{
				this.Ad= ad;
				this.Soyad= soyad;
			} 
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