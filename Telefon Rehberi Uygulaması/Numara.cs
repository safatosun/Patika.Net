class Numara
{
    public string isim { get; set; }
    public string soyisim { get; set; }
    public string telefon { get; set; }

    public Numara(string isim, string soyisim, string telefon)
    {
        this.isim = isim;
        this.soyisim = soyisim;
        this.telefon = telefon;
    }
}