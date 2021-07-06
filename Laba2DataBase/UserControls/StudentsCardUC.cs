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
    public partial class StudentsCardUC : BaseUC
    {
        public StudentsCardUC()
        {
            InitializeComponent();
        }
        List<StudentsCard> studentsCard = new List<StudentsCard>();

        private void SelectButton_Click(object sender, EventArgs e)
        {
            studentsCard = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            student = Getstudent();
            bookandAuthors = GetbookandAuthors();
            books = Getbooks();
            libraryStaffs = GetlibraryStaffs();
            int[] mass = new int[3];
            for (int i = 0; i < studentsCard.Count; i++)
            {
                for (int j = 0; j < student.Count; j++)
                {
                    if (studentsCard[i].Student == student[j].ID)
                        studentsCard[i].Studentstring = string.Join(".", student[j].Surname, student[j].Name.ElementAt(0), student[j].Patronymic.ElementAt(0));
                }
                for (int j = 0; j < libraryStaffs.Count; j++)
                {
                    if (studentsCard[i].LibraryStaff == libraryStaffs[j].ID)
                        studentsCard[i].LibraryStaffstring = string.Join(".", libraryStaffs[j].Surname,
                            libraryStaffs[j].Name.ElementAt(0), libraryStaffs[j].Patronymic.ElementAt(0));
                }
                for (int j = 0; j < bookandAuthors.Count; j++)
                {
                    if (studentsCard[i].Book == bookandAuthors[j].ID)
                        for (int n = 0; n < bookandAuthors.Count; n++)
                        {
                            if (bookandAuthors[j].Book == books[n].ID)
                                studentsCard[i].Bookstring = books[n].Name;
                        }
                }
            }

            StudentCardListBox.DataSource = null;
            StudentCardListBox.DataSource = studentsCard;
        }
        private List<StudentsCard> Get()
        {
            List<StudentsCard> studentsCard = new List<StudentsCard>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM StudentsCard Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                studentsCard.Add(new StudentsCard(reader));
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

            return studentsCard;
        }
        private int? Post(StudentsCard studentCard)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO StudentsCard(LibraryStaff,Student,Book,BookDelivery,DateOfTakingTheBook,BookDeliveryDate) VALUES(@libraryStaff,@student,@book,@bookDelivery,@dateOfTakingTheBook,@bookDeliveryDate);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@libraryStaff", studentCard.LibraryStaff);
                    command.Parameters.AddWithValue("@student", studentCard.Student);
                    command.Parameters.AddWithValue("@book", studentCard.Book);
                    command.Parameters.AddWithValue("@bookDelivery", studentCard.BookDelivery);
                    command.Parameters.Add("@dateOfTakingTheBook", OleDbType.Date).Value = studentCard.DateOfTakingTheBook;
                    command.Parameters.Add("@bookDeliveryDate", OleDbType.Date).Value = studentCard.BookDeliveryDate;
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
        private bool Delete(StudentsCard studentCard)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM StudentsCard WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", studentCard.ID);
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
            if (StudentCardListBox.SelectedItem is StudentsCard selectedStudentCard)
            {
                if (Delete(selectedStudentCard))
                {
                    studentsCard.Remove(selectedStudentCard);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (StudentCardListBox.SelectedItem is StudentsCard selectedStudentCard)
            {
                int libraryStaff = Convert.ToInt32(LibraryStaffTextBox.Text);
                int student = Convert.ToInt32(StudentTextBox.Text);
                int book = Convert.ToInt32(BookTextBox.Text);
                DateTime dateOfTakingTheBook = DateOfTakingTheBookDateTime.Value;
                DateTime bookDeliveryDate = BookDeliveryDateDateTimePicker.Value;
                bool bookDelivery = BookDeliverycheckBox.Checked;

                if (student == null && book == null && libraryStaff == null)
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                selectedStudentCard.LibraryStaff = libraryStaff;
                selectedStudentCard.Student = student;
                selectedStudentCard.Book = book;
                selectedStudentCard.BookDelivery = bookDelivery;
                selectedStudentCard.DateOfTakingTheBook = dateOfTakingTheBook;
                selectedStudentCard.BookDeliveryDate = bookDeliveryDate;
                if (Put(selectedStudentCard))
                {
                    StudentsCard edditable = studentsCard.First(a => a.ID == selectedStudentCard.ID);
                    edditable.LibraryStaff = selectedStudentCard.LibraryStaff;
                    edditable.Student = selectedStudentCard.Student;
                    edditable.Book = selectedStudentCard.Book;
                    edditable.BookDelivery = selectedStudentCard.BookDelivery;
                    edditable.DateOfTakingTheBook = selectedStudentCard.DateOfTakingTheBook;
                    edditable.BookDeliveryDate = selectedStudentCard.BookDeliveryDate;
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
        private bool Put(StudentsCard studentCard)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE StudentsCard
                                                                    SET [LibraryStaff] = @libraryStaff, [Student] = @student,[Book] = @book,[BookDelivery] = @bookDelivery, 
                                                                    [DateOfTakingTheBook] = @dateOfTakingTheBook,[BookDeliveryDate]=@bookDeliveryDate
                                                                    WHERE [ID] = @id", connection))
                    {
                        command.Parameters.AddWithValue("@libraryStaff", studentCard.LibraryStaff);
                        command.Parameters.AddWithValue("@student", studentCard.Student);
                        command.Parameters.AddWithValue("@book", studentCard.Book);
                        command.Parameters.AddWithValue("@bookDelivery", studentCard.BookDelivery);
                        command.Parameters.Add("@dateOfTakingTheBook", OleDbType.Date).Value = studentCard.DateOfTakingTheBook;
                        command.Parameters.Add("@bookDeliveryDate", OleDbType.Date).Value = studentCard.BookDeliveryDate;
                        command.Parameters.AddWithValue("@id", studentCard.ID);
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
            if (LibraryStaffTextBox.Text != "" && BookTextBox.Text != "" && StudentTextBox.Text != "")
            {

                StudentsCard studentCard = new StudentsCard();
                studentCard.LibraryStaff = Convert.ToInt32(LibraryStaffTextBox.Text);
                studentCard.Book = Convert.ToInt32(BookTextBox.Text);
                studentCard.DateOfTakingTheBook = DateOfTakingTheBookDateTime.Value;
                studentCard.BookDeliveryDate = BookDeliveryDateDateTimePicker.Value;
                studentCard.Student = Convert.ToInt32(StudentTextBox.Text);
                studentCard.BookDelivery = BookDeliverycheckBox.Checked;
                int? id = Post(studentCard);
                if (id.HasValue)
                {
                    studentCard.ID = id.Value;
                    studentsCard.Add(studentCard);

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

        List<Students> student = new List<Students>();
        private List<Students> Getstudent()
        {
            List<Students> student = new List<Students>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM Students Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                student.Add(new Students(reader));
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

            return student;
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

        private void StudentCardListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentCardListBox.SelectedItem is StudentsCard selectedStudentCard)
            {
                LibraryStaffTextBox.Text = selectedStudentCard.LibraryStaff.ToString();
                StudentTextBox.Text = selectedStudentCard.Student.ToString();
                DateOfTakingTheBookDateTime.Value = selectedStudentCard.DateOfTakingTheBook;
                BookDeliveryDateDateTimePicker.Value = selectedStudentCard.BookDeliveryDate;
                BookDeliverycheckBox.Checked = selectedStudentCard.BookDelivery;
                BookTextBox.Text = selectedStudentCard.Book.ToString();
            }
        }
    }
}
