using BookShop_BL.Model;
using System;
using System.Windows.Forms;

namespace BookShop_UI
{
    public partial class ClientForm : Form
    {
        public Client Client { get; set; }

        public ClientForm()
        {
            InitializeComponent();
        }

        public ClientForm(Client client) : this()
        {
            Client = client;
            textBox1.Text = Client.Name;
            textBox2.Text = Client.Surname;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client = Client ?? new Client();
            Client.Name = textBox1.Text;
            Client.Surname = textBox2.Text;
            Close();
        }
    }
}
