using BookShop_BL.Model;
using System;
using System.Windows.Forms;

namespace BookShop_UI
{
    public partial class AuthorizationForm : Form
    {
        public Client Client { get; set; }

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client = new Client()
            {
                Name = textBox1.Text
            };
            DialogResult = DialogResult.OK;
        }
    }
}
