using BookShop_BL.Model;
using System;
using System.Windows.Forms;

namespace BookShop_UI
{
    public partial class Main : Form
    {
        BSContext db;
        Client client;

        public Main()
        {
            InitializeComponent();
            db = new BSContext();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogBook = new Catalog<Book>(db.Books, db);
            catalogBook.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new BookForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Books.Add(form.Book);
                db.SaveChanges();
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new ClientForm();
            if (form.ShowDialog() == DialogResult.OK) 
            {
                db.Clients.Add(form.Client);
                db.SaveChanges();
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogClient = new Catalog<Client>(db.Clients, db);
            catalogClient.Show();
        }
    }
}
