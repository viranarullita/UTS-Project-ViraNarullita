using Microsoft.EntityFrameworkCore;
using UTS_Project_ViraNarullita.Models.DB;

namespace UTS_Project_ViraNarullita.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public virtual DbSet<Produk> Produk { get; set; }

        public virtual DbSet<Pesanan> Pesanan { get; set; }
    }
}
