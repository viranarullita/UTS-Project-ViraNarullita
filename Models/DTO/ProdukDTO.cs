namespace UTS_Project_ViraNarullita.Models.DTO
{
    public class ProdukDTO
    {
        public int Id { get; set; }
        public string NamaProduk { get; set; }
        public string Supplier { get; set; }
        public DateTime TanggalKadaluwarsa { get; set; }
        public decimal Harga { get; set; }
        public DateTime TanggalCreate { get; set; }
    }
}
