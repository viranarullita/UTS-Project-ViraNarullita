using FluentValidation;
using UTS_Project_ViraNarullita.Models.DTO;
using System;

namespace UTS_Project_ViraNarullita.Validator
{
    public class ValidatorRequestProduk : AbstractValidator<ProdukRequestDTO>
    {
        public ValidatorRequestProduk()
        {
            RuleFor(x => x.NamaProduk).NotEmpty().WithMessage("Nama Produk tidak boleh kosong!").MinimumLength(3).WithMessage("Nama Produk minimal 3 karakter!");

            RuleFor(x => x.Supplier).NotEmpty().WithMessage("Supplier tidak boleh kosong!").MinimumLength(3).WithMessage("Nama Supplier minimal 3 karakter!");

            RuleFor(x => x.Harga).NotEmpty();

            RuleFor(x => x.TanggalKadaluwarsa).NotEmpty();
        }

        public bool ValidHarga(int harga)
        {
            return harga > 0;
        }
    }
}

