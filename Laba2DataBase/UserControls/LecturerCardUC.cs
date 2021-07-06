using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Laba2DataBase.Models;

namespace Laba2DataBase.UserControls
{
    public partial class LecturerCardUC : BaseUC
    {
        public LecturerCardUC()
        {
            InitializeComponent();
        }
        List<LecturerCard> lecturerCards = new List<LecturerCard>();
        private void SelectButton_Click(object sender, EventArgs e)
        {
            lecturerCards = Get;
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            lecturers = GetLecturer();
            bookandAuthors = GetbookandAuthors();
            books = Getbooks();
            libraryStaffs = GetlibraryStaffs();
            for (int i = 0; i < lecturerCards.Count; i++)
            {
                for(int j = 0;j< lecturers.Count;j++)
                {
                    if (lecturerCards[i].Lecturer == lecturers[j].ID)
                        lecturerCards[i].Lecturerstring = string.Join(".", lecturers[j].Surname, lecturers[j].Name.ElementAt(0), lecturers[j].Patronymic.ElementAt(0));
                }
                for (int j = 0; j < libraryStaffs.Count; j++)
                {
                    if (lecturerCards[i].LibraryStaff == libraryStaffs[j].ID)
                        lecturerCards[i].LibraryStaffstring = string.Join(".", libraryStaffs[j].Surname, 
                            libraryStaffs[j].Name.ElementAt(0), libraryStaffs[j].Patronymic.ElementAt(0));
                }
                for (int j = 0; j < bookandAuthors.Count; j++)
                {
                    if (lecturerCards[i].Book == bookandAuthors[j].ID)
                        for (int n = 0; n < bookandAuthors.Count; n++)
                        {
                            if (bookandAuthors[j].Book == books[n].ID)
                                lecturerCards[i].Bookstring = books[n].Name;
                        }
                }    
            }
            
            LecturerCardListBox.DataSource = null;
            LecturerCardListBox.DataSource = lecturerCards;
        }
        private List<LecturerCard> Get
        {
            get
            {
                List<LecturerCard> lecturerCard = new List<LecturerCard>();

                using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
                {
                    try
                    {
                        connection.Open();

                        using (OleDbCommand command = new OleDbCommand("SELECT * FROM LecturerCard Order by ID", connection))
                        {
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.HasRows && reader.Read())
                                    lecturerCard.Add(new LecturerCard(reader));
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

                return lecturerCard;
            }
        }
        private int? Post(LecturerCard lecturerCard)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = @"INSERT INTO LecturerCard(LibraryStaff,Lecturer,Book,BookDelivery,DateOfTakingTheBook,BookDeliveryDate) 
                    VALUES(@libraryStaff,@lecturer,@book,@bookDelivery,@dateOfTakingTheBook,@bookDeliveryDate);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@libraryStaff", lecturerCard.LibraryStaff);
                    command.Parameters.AddWithValue("@lecturer", lecturerCard.Lecturer);
                    command.Parameters.AddWithValue("@book", lecturerCard.Book);
                    command.Parameters.AddWithValue("@bookDelivery", lecturerCard.BookDelivery);
                    command.Parameters.Add("@dateOfTakingTheBook", OleDbType.Date).Value = lecturerCard.DateOfTakingTheBook;
                    command.Parameters.Add("@bookDeliveryDate", OleDbType.Date).Value = lecturerCard.BookDeliveryDate;
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
        private bool Delete(LecturerCard lecturerCard)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM  LecturerCard WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", lecturerCard.ID);
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
            if (LecturerCardListBox.SelectedItem is LecturerCard lecturerCard)
            {
                if (Delete(lecturerCard))
                {
                    lecturerCards.Remove(lecturerCard);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (LecturerCardListBox.SelectedItem is LecturerCard selectedLecturerCard)
            {
                int libraryStaff = Convert.ToInt32(LibraryStaffTextBox.Text);
                int lecturer = Convert.ToInt32(LecturerTextBox.Text);
                int book = Convert.ToInt32(BookTextBox.Text);
                DateTime dateOfTakingTheBook = DateOfTakingTheBookDateTime.Value;
                DateTime bookDeliveryDate = BookDeliveryDateDateTimePicker.Value;
                bool bookDelivery = BookDeliverycheckBox.Checked;

                if (lecturer == null && book == null && libraryStaff == null)
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                selectedLecturerCard.LibraryStaff = libraryStaff;
                selectedLecturerCard.Lecturer = lecturer;
                selectedLecturerCard.Book = book;
                selectedLecturerCard.BookDelivery = bookDelivery;
                selectedLecturerCard.DateOfTakingTheBook = dateOfTakingTheBook;
                selectedLecturerCard.BookDeliveryDate = bookDeliveryDate;
                if (Put(selectedLecturerCard))
                {
                    LecturerCard edditable = lecturerCards.First(a => a.ID == selectedLecturerCard.ID);
                    edditable.LibraryStaff = selectedLecturerCard.LibraryStaff;
                    edditable.Lecturer = selectedLecturerCard.Lecturer;
                    edditable.Book = selectedLecturerCard.Book;
                    edditable.BookDelivery = selectedLecturerCard.BookDelivery;
                    edditable.DateOfTakingTheBook = selectedLecturerCard.DateOfTakingTheBook;
                    edditable.BookDeliveryDate = selectedLecturerCard.BookDeliveryDate;
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
        private bool Put(LecturerCard lecturerCard)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE LecturerCard
                                                                    SET [LibraryStaff] = @libraryStaff, [Lecturer] = @lecturer,[Book] = @book,
                                                                    [BookDelivery] = @bookDelivery, [DateOfTakingTheBook] = @dateOfTakingTheBook,
                                                                    [BookDeliveryDate] = @bookDeliveryDate
                                                                    WHERE [ID] = @id", connection))
                    {
                        command.Parameters.AddWithValue("@libraryStaff", lecturerCard.LibraryStaff);
                        command.Parameters.AddWithValue("@lecturer", lecturerCard.Lecturer);
                        command.Parameters.AddWithValue("@book", lecturerCard.Book);
                        command.Parameters.AddWithValue("@bookDelivery", lecturerCard.BookDelivery);
                        command.Parameters.Add("@dateOfTakingTheBook", OleDbType.Date).Value = lecturerCard.DateOfTakingTheBook;
                        command.Parameters.Add("@bookDeliveryDate", OleDbType.Date).Value = lecturerCard.BookDeliveryDate;
                        command.Parameters.AddWithValue("@id", lecturerCard.ID);
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
            if (LibraryStaffTextBox.Text != "" && BookTextBox.Text != "" && LecturerTextBox.Text != "")
            {

                LecturerCard lecturerCard = new LecturerCard();
                lecturerCard.LibraryStaff = Convert.ToInt32(LibraryStaffTextBox.Text);
                lecturerCard.Book = Convert.ToInt32(BookTextBox.Text);
                lecturerCard.DateOfTakingTheBook = DateOfTakingTheBookDateTime.Value;
                lecturerCard.BookDeliveryDate = BookDeliveryDateDateTimePicker.Value;
                lecturerCard.Lecturer = Convert.ToInt32(LecturerTextBox.Text);
                lecturerCard.BookDelivery = BookDeliverycheckBox.Checked;
                int? id = Post(lecturerCard);
                if (id.HasValue)
                {
                    lecturerCard.ID = id.Value;
                    lecturerCards.Add(lecturerCard);

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
       
        List<Lecturer> lecturers = new List<Lecturer>();
        private List<Lecturer> GetLecturer()
        {
            List<Lecturer> lecturer = new List<Lecturer>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM Lecturers Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                lecturer.Add(new Lecturer(reader));
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

            return lecturer;
        }

        List<BookandAuthor> bookandAuthors = new List<BookandAuthor>();
        private List<BookandAuthor> GetbookandAuthors()
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

        List<Book> books = new List<Book>();
        private List<Book> Getbooks()
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

        List<LibraryStaff> libraryStaffs = new List<LibraryStaff>();
        private List<LibraryStaff> GetlibraryStaffs()
        {
            List<LibraryStaff> libraryStaffs = new List<LibraryStaff>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM LibraryStaff Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                libraryStaffs.Add(new LibraryStaff(reader));
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

            return libraryStaffs;
        }

        private void LecturerCardListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LecturerCardListBox.SelectedItem is LecturerCard selectedLecturerCard)
            {
                LibraryStaffTextBox.Text = selectedLecturerCard.LibraryStaff.ToString();
                LecturerTextBox.Text = selectedLecturerCard.Lecturer.ToString();
                DateOfTakingTheBookDateTime.Value = selectedLecturerCard.DateOfTakingTheBook;
                BookDeliveryDateDateTimePicker.Value = selectedLecturerCard.BookDeliveryDate;
                BookDeliverycheckBox.Checked = selectedLecturerCard.BookDelivery;
                BookTextBox.Text = selectedLecturerCard.Book.ToString();
            }
        }
    }
}
