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
    public partial class BookUC : BaseUC
    {
        public BookUC()
        {
            InitializeComponent();
        }
        List<Book> books = new List<Book>();
        private void SelectButton_Click(object sender, EventArgs e)
        {
            books = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            List<Publishers> publishers = new List<Publishers>();
            publishers = GetPubliushers();
            for(int i = 0; i < books.Count;i++)
            {
                for(int j =0; j < publishers.Count ;j++)
                {
                    if (books[i].Publisher == publishers[j].ID)
                        books[i].Publisherstring = publishers[j].Name;
                }
            }
            BookListBox.DataSource = null;
            BookListBox.DataSource = books;
        }
        private List<Book> Get()
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
        private int? Post(Book book)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {


                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO Books(Name,Publisher,PublishingYear) VALUES(@name,@publisher,@publishingYear);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@name", book.Name);
                    command.Parameters.AddWithValue("@publisher", book.Publisher);
                    command.Parameters.Add("@publishingYear", OleDbType.Date).Value = book.PublishingYear;
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
        private bool Delete(Book book)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM Books WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", book.ID);
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
            if (BookListBox.SelectedItem is Book book)
            {
                if (Delete(book))
                {
                    books.Remove(book);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (BookListBox.SelectedItem is Book selectedBook)
            {
                string name = NameTextBox.Text;
                int publisher = Convert.ToInt32(PublisherTextBox.Text);
                DateTime publishingYear = PublishingYearDateTime.Value;

                if (string.IsNullOrEmpty(name)&& publisher == null)
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }
                selectedBook.Name = name;
                selectedBook.Publisher = publisher;
                selectedBook.PublishingYear = publishingYear;
                if (Put(selectedBook))
                {
                    Book edditable = books.First(a => a.ID == selectedBook.ID);
                    edditable.Name = selectedBook.Name;
                    edditable.Publisher = selectedBook.Publisher;
                    edditable.PublishingYear = selectedBook.PublishingYear;
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
        private bool Put(Book book)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE Books
                                                                    SET Name = @name,Publisher=@publisher,PublishingYear=@publishingYear
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@name", book.Name);
                        command.Parameters.AddWithValue("@publisher", book.Publisher);
                        command.Parameters.Add("@publishingYear", OleDbType.Date).Value = book.PublishingYear;
                        command.Parameters.AddWithValue("@id", book.ID);
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
            if (PublisherTextBox.Text != "" && NameTextBox.Text != "")
            {
                string name = NameTextBox.Text;
                int publisher = Convert.ToInt32(PublisherTextBox.Text);
                DateTime publishingYear = PublishingYearDateTime.Value;

                Book book = new Book(name, publisher,publishingYear);
                int? id = Post(book);
                if (id.HasValue)
                {
                    book.ID = id.Value;
                    books.Add(book);

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
        private void BookListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BookListBox.SelectedItem is Book selectedBook)
            {
                NameTextBox.Text = selectedBook.Name;
                PublisherTextBox.Text = selectedBook.Publisher.ToString();
                PublishingYearDateTime.Value = selectedBook.PublishingYear;
            }
        }
        private List<Publishers> GetPubliushers()
        {
            List<Publishers> publishers = new List<Publishers>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM Publishers Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                publishers.Add(new Publishers(reader));
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

            return publishers;
        }
    }
}
