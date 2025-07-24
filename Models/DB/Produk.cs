namespace UTS_Project_ViraNarullita.Models.DB
{
    public class Produk
    {
        public int Id { get; set; }
        public string NamaProduk { get; set; }
        public string Supplier { get; set; }
        public DateTime TanggalKadaluwarsa { get; set; }
        public decimal Harga { get; set; }
        public DateTime TanggalCreate { get; set; }
    }
}
