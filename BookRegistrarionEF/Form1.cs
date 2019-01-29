using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistrarionEF {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            refereshCbxBook();
        }

        private void cbxBook_SelectedIndexChanged(object sender, EventArgs e) {
            
        }

        private void btnAddBook_Click(object sender, EventArgs e) {
            Book boo = new Book();
            boo.ISBN = "789123";
            boo.Title = "a vary interesting book title";
            boo.Price = 1;

            BookDB.AddBook(boo);
            MessageBox.Show("Book Added!");
            refereshCbxBook();
        }

        private void refereshCbxBook() {
            List<Book> books = BookDB.GetAllBooks();
            cbxBook.DataSource = books;
            cbxBook.DisplayMember = nameof(Book.Title);
        }

        private void btnCustomer_Click(object sender, EventArgs e) {
            Customer cus = new Customer() {
                FirstName = "j",
                LastName = "h",
                DateOfBirth = new DateTime(1980, 1, 1),
                Title = "Mr."
            };

            cus = CustomerDB.AddCustomer(cus);
            MessageBox.Show("Customer Added!");

            cus.FirstName = "jim;";
            CustomerDB.Update(cus);
            MessageBox.Show("Customer Updated!");

            CustomerDB.DeleteCustomer(cus);
            MessageBox.Show("Customer Deleted");

        }
    }
}
