using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using UTS_Project_ViraNarullita.Models.DB;
using UTS_Project_ViraNarullita.Models.DTO;

namespace UTS_Project_ViraNarullita.Validator
{
    public class ValidatorRequestPesanan : AbstractValidator<PesananRequestDTO>
    {
        public ValidatorRequestPesanan()
        {
            RuleFor(x => x.NamaPembeli).NotEmpty().WithMessage("Nama Pembeli tidak boleh kosong!").MinimumLength(3).WithMessage("Nama Pembeli minimal 3 karakter!");

            RuleFor(x => x.AlamatPembeli).NotEmpty().WithMessage("Alamat Pembeli tidak boleh kosong!").MinimumLength(5).WithMessage("Alamat Pembeli minimal 5 karakter!");

            RuleFor(x => x.IdProduk).NotEmpty().WithMessage("Ditolak, Karena tidak ada produk");

            RuleFor(x => x.Jumlah).NotEmpty().Must(ValidJumlah);
        }

        public bool ValidJumlah(int jumlah)
        {
            return jumlah > 0;
        }
    }
}
