using BookShop_BL.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_UI
{
    public partial class Main : Form
    {
        BSContext db;
        Cart cart;
        Client client;

        public Main()
        {
            InitializeComponent();
            db = new BSContext();

            cart = new Cart(client);
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

        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                listBox1.Invoke((Action)delegate
                {
                    listBox1.Items.AddRange(db.Books.ToArray());
                    UpdateLists();
                });
            });
        }

        private void UpdateLists()
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(cart.GetAll().ToArray());
            label1.Text = "Sum: " + cart.Price;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Book book)
            {
                cart.Add(book);
                listBox2.Items.Add(book);
                UpdateLists();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                listBox2.Items.Clear();
                cart = new Cart(client);

                MessageBox.Show("Payment was succeed. ", "Purchase completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please login!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AuthorizationForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var tempClient = db.Clients.FirstOrDefault(c => c.Name.Equals(form.Client.Name));
                if (tempClient != null)
                {
                    client = tempClient;
                }
                else
                {
                    db.Clients.Add(form.Client);
                    db.SaveChanges();
                    client = form.Client;
                }

                cart.Client = client;
            }

            linkLabel1.Text = $"Hello, {client.Name}";
        }
    }
}
