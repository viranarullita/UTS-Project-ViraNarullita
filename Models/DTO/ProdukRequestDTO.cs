namespace UTS_Project_ViraNarullita.Models.DTO
{
    public class ProdukRequestDTO
    {
        public string NamaProduk { get; set; }
        public string Supplier { get; set; }
        public decimal Harga { get; set; }
        public DateTime TanggalKadaluwarsa { get; set; }
    }
}
