namespace Static
{
	public class Program
	{   
		static void Main(string[] args)
		{
			Console.WriteLine("Çalışan sayısı: {0}" , Calisan.CalisanSayisi); 

			Calisan calisan = new Calisan("Ali", "Ezer", "IT");

			Calisan calisan2 = new Calisan("Aleyna", "Ezici", "Finans");

            Console.WriteLine("Çalışan sayısı: {0}" ,Calisan.CalisanSayisi);


			Calisan calisan3 = new Calisan("Yusuf", "Zile", "Borsa");

			Console.WriteLine("Çalışan sayısı: {0}" ,Calisan.CalisanSayisi);

			Console.WriteLine("Toplama işleminin sonucu: {0}" , Islemler.Topla(400,500));
			Console.WriteLine("Çıkarma işleminin sonucu: {0}" , Islemler.Cıkar(300,100));
		}

		class Calisan 
		{
			private static int calisanSayisi; 

			public static int CalisanSayisi { get => calisanSayisi;} 

			private string Isim;
			private string Soyisim;
			private string Departman;

			static Calisan() 
			{
				calisanSayisi = 0;
			}
			public Calisan(string isim, string soyisim, string departman) 
			{
				this.Isim = isim;
				this.Soyisim = soyisim;
				this.Departman = departman;
				calisanSayisi++;
			}
		}

		static class Islemler
		{
			public static long Topla(int sayi1, int sayi2)
			{
				return sayi1 + sayi2;
			}
			public static long Cıkar(int sayi1, int sayi2)
			{
				return sayi1 - sayi2;
			}
		}
	}
}