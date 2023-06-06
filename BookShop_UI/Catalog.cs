using BookShop_BL.Model;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace BookShop_UI
{
    public partial class Catalog<T> : Form
        where T : class
    {
        BSContext db;
        DbSet<T> set;

        public Catalog(DbSet<T> set, BSContext db)
        {
            InitializeComponent();

            this.db = db;
            this.set = set;
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }
    }
}
