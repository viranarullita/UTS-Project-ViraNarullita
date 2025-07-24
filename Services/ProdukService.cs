using UTS_Project_ViraNarullita.Models.DTO;
using UTS_Project_ViraNarullita.Models;
using UTS_Project_ViraNarullita.Models.DB;

namespace UTS_Project_ViraNarullita.Services
{
    public class ProdukService
    {
        private readonly ApplicationContext _context;

        public ProdukService(ApplicationContext context)
        {
            _context = context;
        }

        public List<ProdukDTO> GetListProduk()
        {
            var datas = _context.Produk.Select(x => new ProdukDTO
            {
                Id = x.Id,
                NamaProduk= x.NamaProduk,
                Supplier = x.Supplier,
                TanggalKadaluwarsa = x.TanggalKadaluwarsa,
                Harga = x.Harga,
                TanggalCreate = x.TanggalCreate,

            }).ToList();
            return datas;
        }

        public ProdukDTO GetById(int ProdukId)
        {
            var databyId = _context.Produk.Where(x => x.Id == ProdukId).Select(x => new ProdukDTO
            {
                Id = x.Id,
                NamaProduk = x.NamaProduk,
                Supplier = x.Supplier,
                TanggalKadaluwarsa = x.TanggalKadaluwarsa,
                Harga = x.Harga,
                TanggalCreate = x.TanggalCreate,
            }).FirstOrDefault();
            return databyId;
        }

        public bool CreateProduk(ProdukRequestDTO Produk)
        {
            try
            {
                var InsertDataProduk = new Produk
                {
                    NamaProduk = Produk.NamaProduk,
                    Supplier = Produk.Supplier,
                    TanggalKadaluwarsa = Produk.TanggalKadaluwarsa,
                    Harga = Produk.Harga,
                    TanggalCreate= DateTime.Now,
                };
                _context.Produk.Add(InsertDataProduk);

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProduk(int Id, ProdukRequestDTO Produk)
        {
            try
            {
                var ProdukOld = _context.Produk.Where(x => x.Id == Id).FirstOrDefault();

                if (ProdukOld != null)
                {
                    ProdukOld.NamaProduk = Produk.NamaProduk;
                    ProdukOld.Supplier = Produk.Supplier;
                    ProdukOld.TanggalKadaluwarsa = Produk.TanggalKadaluwarsa;
                    ProdukOld.Harga = Produk.Harga;
                    ProdukOld.TanggalCreate = DateTime.Now;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteProduk(int id)
        {
            try
            {
                var ProdukData = _context.Produk.FirstOrDefault(DEL => DEL.Id == id);

                if (ProdukData != null)
                {
                    _context.Produk.Remove(ProdukData);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
