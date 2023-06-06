using System.Data.Entity;

namespace BookShop_BL.Model
{
    public class BSContext : DbContext
    {
        public BSContext() : base("BSConnection") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Paycheck> Paychecks { get; set; }
    }
}
