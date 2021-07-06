using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laba2DataBase.Models;
using System.Data.OleDb;

namespace Laba2DataBase.UserControls
{
    public partial class BookandAuthorUC : BaseUC
    {
        public BookandAuthorUC()
        {
            InitializeComponent();
        }
        List<BookandAuthor> bookandAuthors = new List<BookandAuthor>();
        private void SelectButton_Click(object sender, EventArgs e)
        {
            bookandAuthors = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            List<Authors> authors = new List<Authors>();
            authors = GetAuthor();
            List<Book> books = new List<Book>();
            books = GetBook();
            for(int i=0;i<bookandAuthors.Count;i++)
            {
                for(int j = 0; j <books.Count;j++)
                {
                    if (bookandAuthors[i].Book == books[j].ID)
                        bookandAuthors[i].Bookstring = books[j].Name;
                }
                for (int j = 0; j < authors.Count; j++)
                {
                    if (bookandAuthors[i].Author == authors[j].ID)
                        bookandAuthors[i].Authorstring = string.Join(".", authors[j].Surname, authors[j].Name.ElementAt(0), authors[j].Patronymic.ElementAt(0)); 
                }
            }
            BookandAuthorListBox.DataSource = null;
            BookandAuthorListBox.DataSource = bookandAuthors;
        }
        private List<BookandAuthor> Get()
        {
            List<BookandAuthor> bookandAuthors = new List<BookandAuthor>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM BookandAuthor Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                bookandAuthors.Add(new BookandAuthor(reader));
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return bookandAuthors;
        }
        private int? Post(BookandAuthor bookandAuthor)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO BookandAuthor(Book,Author) VALUES(@book,@author);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@book", bookandAuthor.Book);
                    command.Parameters.AddWithValue("@author", bookandAuthor.Author);
                    try
                    {
                        connection.Open();
                        if (command.ExecuteNonQuery() > 0)
                        {
                            command.CommandText = query2;
                            id = Convert.ToInt32(command.ExecuteScalar());
                            return id;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                       ex.Message,
                        "ERROR",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.None,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
                return null;
            }
        }
        private bool Delete(BookandAuthor bookandAuthor)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM BookandAuthor WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", bookandAuthor.ID);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }

                return false;
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (BookandAuthorListBox.SelectedItem is BookandAuthor bookandAuthor)
            {
                if (Delete(bookandAuthor))
                {
                    bookandAuthors.Remove(bookandAuthor);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (BookandAuthorListBox.SelectedItem is BookandAuthor selectedBookandAuthor)
            {
                int author = Convert.ToInt32(AuthorTextBox.Text);
                int book = Convert.ToInt32(BookTextBox.Text);

                if (book == null && author == null)
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                selectedBookandAuthor.Author = author;
                selectedBookandAuthor.Book = book;
                if (Put(selectedBookandAuthor))
                {
                    BookandAuthor edditable = bookandAuthors.First(a => a.ID == selectedBookandAuthor.ID);
                    edditable.Book = selectedBookandAuthor.Book;
                    edditable.Author = selectedBookandAuthor.Author;
                    PopulateListBox();
                }
            }
        }
        private bool Put(BookandAuthor bookandAuthor)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE BookandAuthor
                                                                    SET Book = @book,Author= @author
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@book", bookandAuthor.Book);
                        command.Parameters.AddWithValue("@author", bookandAuthor.Author);
                        command.Parameters.AddWithValue("@id", bookandAuthor.ID);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                       ex.Message,
                        "ERROR",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.None,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }

                return false;
            }
        }
        private void InsertButton_Click(object sender, EventArgs e)
        {
            //TODO: check all fields
            if (AuthorTextBox.Text != "" || BookTextBox.Text != "")
            {
                BookandAuthor bookandAuthor = new BookandAuthor();
                bookandAuthor.Book = Convert.ToInt32(BookTextBox.Text);
                bookandAuthor.Author = Convert.ToInt32(AuthorTextBox.Text);
                int? id = Post(bookandAuthor);
                if (id.HasValue)
                {
                    bookandAuthor.ID = id.Value;
                    bookandAuthors.Add(bookandAuthor);

                    PopulateListBox();
                }
            }
            else
            {
                MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void BookandAuthorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BookandAuthorListBox.SelectedItem is BookandAuthor selectedBookandAuthor)
            {
                BookTextBox.Text = selectedBookandAuthor.Book.ToString();
                AuthorTextBox.Text = selectedBookandAuthor.Author.ToString();
            }
        }
        private List<Book> GetBook()
        {
            List<Book> books = new List<Book>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM Books Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                books.Add(new Book(reader));
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return books;
        }
        private List<Authors> GetAuthor()
        {
            List<Authors> authors = new List<Authors>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM Authors Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                authors.Add(new Authors(reader));
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            return authors;
        }
    }
}
