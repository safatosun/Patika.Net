namespace Enum
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(Gunler.Pazar);
			Console.WriteLine((int)Gunler.Salı);

			int sicaklik = 32;

			if (sicaklik <= (int)Hava_Durumu.Normal)
				Console.WriteLine("Dışarıya çıkmak için havanın biraz daha ısınmasını bekleyelim.");
			else if (sicaklik >= (int)Hava_Durumu.Sicak)
				Console.WriteLine("Dışarıya çıkmak için çok sıcak bir gün.");
			else if (sicaklik >= (int)Hava_Durumu.Normal && sicaklik <= (int)Hava_Durumu.Cok_Sicak)
				Console.WriteLine("Hadi dışarıya çıkalım!");
		}
		enum Gunler
		{
			Pazartesi = 1,
			Salı, 
			Çarşamba, 
			Perşembe,
			Cuma, 
			Cumartesi,
			Pazar
		}
		enum Hava_Durumu
		{
			Soguk = 5,
			Normal = 20,
			Sicak = 25,
			Cok_Sicak = 30
		}
	}
}