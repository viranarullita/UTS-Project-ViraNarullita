using UTS_Project_ViraNarullita.Models;
using UTS_Project_ViraNarullita.Models.DB;
using UTS_Project_ViraNarullita.Models.DTO;

namespace UTS_Project_ViraNarullita.Services
{
    public class PesananService
    {
        private readonly ApplicationContext _context;

        public PesananService(ApplicationContext context)
        {
            _context = context;
        }

        public List<PesananDTO> GetListPesanan()
        {
            var datas = _context.Pesanan.Select(x => new PesananDTO
            {
                Id = x.Id,
                NamaPembeli = x.NamaPembeli,
                AlamatPembeli = x.AlamatPembeli,
                IdProduk = x.IdProduk,
                Jumlah = x.Jumlah,
                TanggalPesanan = x.TanggalPesanan,

            }).ToList();
            return datas;
        }

        public PesananDTO GetById(int PesananId)
        {
            var databyId = _context.Pesanan.Where(x => x.Id == PesananId).Select(x => new PesananDTO
            {
                Id = x.Id,
                NamaPembeli = x.NamaPembeli,
                AlamatPembeli = x.AlamatPembeli,
                IdProduk = x.IdProduk,
                Jumlah = x.Jumlah,
                TanggalPesanan = x.TanggalPesanan ,
            }).FirstOrDefault();
            return databyId;
        }

        public bool CreatePesanan(PesananRequestDTO Pesanan)
        {
            try
            {
                var InsertDataPesanan = new Pesanan
                {
                    NamaPembeli = Pesanan.NamaPembeli,
                    AlamatPembeli = Pesanan.AlamatPembeli,
                    IdProduk = Pesanan.IdProduk,
                    Jumlah = Pesanan.Jumlah,
                    TanggalPesanan = DateTime.Now,
                };
                _context.Pesanan.Add(InsertDataPesanan);

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePesanan(int Id, PesananRequestDTO Pesanan)
        {
            try
            {
                var PesananOld = _context.Pesanan.Where(x => x.Id == Id).FirstOrDefault();

                if (PesananOld != null)
                {
                    PesananOld.NamaPembeli = Pesanan.NamaPembeli;
                    PesananOld.AlamatPembeli = Pesanan.AlamatPembeli;
                    PesananOld.IdProduk = Pesanan.IdProduk;
                    PesananOld.Jumlah = Pesanan.Jumlah;
                    PesananOld.TanggalPesanan = DateTime.Now;

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

        public bool DeletePesanan(int id)
        {
            try
            {
                var PesananData = _context.Pesanan.FirstOrDefault(DEL => DEL.Id == id);

                if (PesananData != null)
                {
                    _context.Pesanan.Remove(PesananData);
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
