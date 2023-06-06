using BookShop_BL.Model;
using System;
using System.Windows.Forms;

namespace BookShop_UI
{
    public partial class BookForm : Form
    {
        public Book Book { get; set; }

        public BookForm()
        {
            InitializeComponent();
        }

        public BookForm(Book book) : this()
        {
            Book = book ?? new Book();
            textBox1.Text = Book.Name;
            textBox2.Text = Book.Author;
            numericUpDown1.Value = Book.Price;
        }

        private void BookForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book = Book ?? new Book();
            Book.Name = textBox1.Text;
            Book.Author = textBox2.Text;
            Book.Price = numericUpDown1.Value;

            Close();
        }
    }
}
