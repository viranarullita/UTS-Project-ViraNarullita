namespace UTS_Project_ViraNarullita.Models.DB
{
    public class Pesanan
    {
        public int Id { get; set; }
        public string NamaPembeli { get; set; }
        public string AlamatPembeli { get; set; }
        public int IdProduk { get; set; }
        public int Jumlah { get; set; }
        public DateTime TanggalPesanan { get; set; }
    }
}
