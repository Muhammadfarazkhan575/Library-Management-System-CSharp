using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {
        List<Book> books = new List<Book>();

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = books;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book b = new Book
            {
                BookID = int.Parse(txtBookID.Text),
                BookName = txtBookName.Text,
                Author = txtAuthor.Text
            };

            books.Add(b);
            RefreshGrid();
            MessageBox.Show("Book Added Successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBookID.Text);
            var book = books.FirstOrDefault(x => x.BookID == id);

            if (book != null)
            {
                book.BookName = txtBookName.Text;
                book.Author = txtAuthor.Text;
                RefreshGrid();
                MessageBox.Show("Book Updated");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBookID.Text);
            var book = books.FirstOrDefault(x => x.BookID == id);

            if (book != null)
            {
                books.Remove(book);
                RefreshGrid();
                MessageBox.Show("Book Deleted");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var result = books.Where(x => x.BookName.Contains(txtSearch.Text)).ToList();
            dataGridView1.DataSource = result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookID.Clear();
            txtBookName.Clear();
            txtAuthor.Clear();
            txtSearch.Clear();
        }
    }
}
