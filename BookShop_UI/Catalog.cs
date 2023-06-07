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

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Add() 
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Book))
            {
                var book = set.Find(id) as Book;
                if (book != null)
                {
                    var form = new BookForm(book);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }

            else if (typeof(T) == typeof(Client))
            {
                var client = set.Find(id) as Client;
                if (client != null)
                {
                    var form = new ClientForm(client);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
        }

        private void Edit() 
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Book))
            {
                var book = set.Find(id) as Book;
                if (book != null)
                {
                    db.Books.Remove(book);
                    dataGridView.Update();
                }
            }

            else if (typeof(T) == typeof(Client))
            {
                var client = set.Find(id) as Client;
                if (client != null)
                {
                    db.Clients.Remove(client);
                    dataGridView.Update();
                }
            }
        }
    }
}
