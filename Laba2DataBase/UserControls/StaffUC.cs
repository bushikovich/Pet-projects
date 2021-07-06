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
    public partial class StaffUC : BaseUC
    {
        public StaffUC()
        {
            InitializeComponent();
        }
        List<BookandAuthor> bookandAuthors = new List<BookandAuthor>();
        List<StudentsCard> studentsCard = new List<StudentsCard>();
        List<LecturerCard> lecturerCards = new List<LecturerCard>();
        List<Lecturer> lecturers = new List<Lecturer>();
        List<LibraryStaff> libraryStaffs = new List<LibraryStaff>();
        private void StaffUC_Load(object sender, EventArgs e)
        {
            libraryStaffs = GetLibraryStaff();
            for (int i = 0; i < libraryStaffs.Count; i++)
            {
                StaffComboBox.Items.Add(string.Join(".", libraryStaffs[i].ID, libraryStaffs[i].Surname,
                            libraryStaffs[i].Name.ElementAt(0), libraryStaffs[i].Patronymic.ElementAt(0)));
            }
        }
        private List<LibraryStaff> GetLibraryStaff()
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
        private void StaffComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            libraryStaffs = GetLibraryStaff();
            for (int i = 0; i < libraryStaffs.Count; i++)
            {
                for (int j = 0; j < StaffComboBox.Items.Count; j++)
                {
                    string ID = StaffComboBox.Items[j].ToString();
                    if (libraryStaffs[i].ID == (Convert.ToInt32(ID.ElementAt(0)) - '0'))
                    {
                        SurnameStaffLabel.Text = libraryStaffs[i].Surname;
                        NameStaffLabel.Text = libraryStaffs[i].Name;
                        PatronymicStaffLabel.Text = libraryStaffs[i].Patronymic;
                    }
                }
            }
        }
        private void SearchAllLecturerButton_Click(object sender, EventArgs e)
        {
            lecturerCards = GetLecturerCard;
            lecturers = GetLecturers();
            PopulateLecturerListBox();
        }
        private List<Lecturer> GetLecturers()
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
        private void PopulateLecturerListBox()
        {
            List<Faculty> facultys = new List<Faculty>();
            facultys = GetFaculty();
            for (int i = 0; i < lecturers.Count; i++)
            {
                for (int j = 0; j < facultys.Count; j++)
                {
                    if (lecturers[i].Faculty == facultys[j].ID)
                    {
                        lecturers[i].Facultystring = facultys[j].Name;
                    }
                }
            }
            VisitorListBox.DataSource = null;
            VisitorListBox.DataSource = lecturers;
            lecturers = GetLecturers();
            bookandAuthors = GetbookandAuthors();
            books = Getbooks();
            libraryStaffs = GetlibraryStaffs();
            for (int i = 0; i < lecturerCards.Count; i++)
            {
                for (int j = 0; j < lecturers.Count; j++)
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

            VisitorCardListBox.DataSource = null;
            VisitorCardListBox.DataSource = lecturerCards;
        }
        private List<Faculty> GetFaculty()
        {
            List<Faculty> faculty = new List<Faculty>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM Faculty Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                faculty.Add(new Faculty(reader));
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

            return faculty;
        }
        private List<LecturerCard> GetLecturerCard
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
        private void SearchAllStudentButton_Click(object sender, EventArgs e)
        {
            student = Getstudent();
            studentsCard = GetStudentCard();
            PopulateStudentListBox();
        }
        private void PopulateStudentListBox()
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

            VisitorCardListBox.DataSource = null;
            VisitorCardListBox.DataSource = studentsCard;

            List<Group> groups = new List<Group>();
            groups = GetGroup();
            for (int i = 0; i < student.Count; i++)
            {
                for (int j = 0; j < groups.Count; j++)
                {
                    if (student[i].Group == groups[j].ID)
                    {
                        student[i].Groupstring = groups[j].Name;
                    }
                }
            }
            VisitorListBox.DataSource = null;
            VisitorListBox.DataSource = student;
        }
        private List<StudentsCard> GetStudentCard()
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
        private List<Group> GetGroup()
        {
            List<Group> group = new List<Group>();

            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM GroupStudent Order by ID", connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                                group.Add(new Group(reader));
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

            return group;
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

        private void SearchAllButton_Click(object sender, EventArgs e)
        {
            bookandAuthors = GetbookandAuthors();
            PopulateBookListBox();
        }
        private void PopulateBookListBox()
        {
            List<Authors> authors = new List<Authors>();
            authors = GetAuthor();
            List<Book> books = new List<Book>();
            books = Getbooks();
            for (int i = 0; i < bookandAuthors.Count; i++)
            {
                for (int j = 0; j < books.Count; j++)
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
            BookListBox.DataSource = null;
            BookListBox.DataSource = bookandAuthors;
        }

        private void SearchStudentButton_Click(object sender, EventArgs e)
        {
            List<StudentsCard> searchstudentsCard = new List<StudentsCard>();
            List<Students> searchstudent = new List<Students>();
            string surname = SearchVisitorTextBox.Text;
            student = Getstudent();
            studentsCard = GetStudentCard();
            for (int i = 0; i < student.Count; i++)
            {
                for (int j = 0; j < surname.Length; j++)
                {
                    if (student[i].Surname.ElementAt(j) == surname.ElementAt(j))
                    {
                        if (j + 1 == surname.Length)
                        { searchstudent.Add(student[i]); }
                    }
                    else
                    {
                        j = surname.Length;
                    }
                }
            }

            for (int i = 0; i < studentsCard.Count; i++)
            {
                for (int j = 0; j < student.Count; j++)
                {
                    if (studentsCard[i].Student == student[j].ID)
                    {

                        for (int n = 0; n < surname.Length; n++)
                        {
                            if (student[j].Surname.ElementAt(n) == surname.ElementAt(n))
                            {
                                if (n + 1 == surname.Length)
                                { searchstudentsCard.Add(studentsCard[i]); }
                            }
                            else
                            {
                                n = surname.Length;
                            }
                        }
                    }
                }
            }
            PopulateSeachStudentListBox(searchstudentsCard, searchstudent);
        }
        private void PopulateSeachStudentListBox(List<StudentsCard> studentsCard, List<Students> student)
        {
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

            VisitorCardListBox.DataSource = null;
            VisitorCardListBox.DataSource = studentsCard;

            List<Group> groups = new List<Group>();
            groups = GetGroup();
            for (int i = 0; i < student.Count; i++)
            {
                for (int j = 0; j < groups.Count; j++)
                {
                    if (student[i].Group == groups[j].ID)
                    {
                        student[i].Groupstring = groups[j].Name;
                    }
                }
            }
            VisitorListBox.DataSource = null;
            VisitorListBox.DataSource = student;
        }

        private void SearchLecturerButton_Click(object sender, EventArgs e)
        {
            List<LecturerCard> searchLecturerCard = new List<LecturerCard>();
            List<Lecturer> searchLecturer = new List<Lecturer>();
            string surname = SearchVisitorTextBox.Text;
            lecturers = GetLecturers();
            lecturerCards = GetLecturerCard;
            for (int i = 0; i < lecturers.Count; i++)
            {
                for (int j = 0; j < surname.Length; j++)
                {
                    if (lecturers[i].Surname.ElementAt(j) == surname.ElementAt(j))
                    {
                        if (j + 1 == surname.Length)
                        { searchLecturer.Add(lecturers[i]); }
                    }
                    else
                    {
                        j = surname.Length;
                    }
                }
            }

            for (int i = 0; i < lecturerCards.Count; i++)
            {
                for (int j = 0; j < lecturers.Count; j++)
                {
                    if (lecturerCards[i].Lecturer == lecturers[j].ID)
                    {

                        for (int n = 0; n < surname.Length; n++)
                        {
                            if (lecturers[j].Surname.ElementAt(n) == surname.ElementAt(n))
                            {
                                if (n + 1 == surname.Length)
                                { searchLecturerCard.Add(lecturerCards[i]); }
                            }

                            else
                            {
                                n = surname.Length;
                            }
                        }
                    }
                }
            }
            PopulateSeachLecturerListBox(searchLecturerCard, searchLecturer);
        }
        private void PopulateSeachLecturerListBox(List<LecturerCard> lecturerCards, List<Lecturer> lecturers)
        {
            List<Faculty> facultys = new List<Faculty>();
            facultys = GetFaculty();
            for (int i = 0; i < lecturers.Count; i++)
            {
                for (int j = 0; j < facultys.Count; j++)
                {
                    if (lecturers[i].Faculty == facultys[j].ID)
                    {
                        lecturers[i].Facultystring = facultys[j].Name;
                    }
                }
            }
            VisitorListBox.DataSource = null;
            VisitorListBox.DataSource = lecturers;
            lecturers = GetLecturers();
            bookandAuthors = GetbookandAuthors();
            books = Getbooks();
            libraryStaffs = GetlibraryStaffs();
            for (int i = 0; i < lecturerCards.Count; i++)
            {
                for (int j = 0; j < lecturers.Count; j++)
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

            VisitorCardListBox.DataSource = null;
            VisitorCardListBox.DataSource = lecturerCards;
        }

        private void SearchSpecificButton_Click(object sender, EventArgs e)
        {
            List<BookandAuthor> searchBookandAuthors = new List<BookandAuthor>();
            string book = SearchAuthorsTextBox.Text;
            bookandAuthors = GetbookandAuthors();
            List<Authors> authors = new List<Authors>();
            authors = GetAuthor();
            List<Book> books = new List<Book>();
            books = Getbooks();
            for (int i = 0; i < bookandAuthors.Count; i++)
            {
                for (int j = 0; j < books.Count; j++)
                {
                    if (bookandAuthors[i].Book == books[j].ID)
                        for (int n = 0; n < book.Length; n++)
                        {
                            if (books[j].Name.ElementAt(n) == book.ElementAt(n))
                            {
                                if (n + 1 == book.Length)
                                { searchBookandAuthors.Add(bookandAuthors[i]); }
                            }

                            else
                            {
                                n = book.Length;
                            }
                        }
                }
            }
            PopulateSearchBookListBox(searchBookandAuthors);
        }
        private void PopulateSearchBookListBox(List<BookandAuthor> bookandAuthors)
        {
            List<Authors> authors = new List<Authors>();
            authors = GetAuthor();
            List<Book> books = new List<Book>();
            books = Getbooks();
            for (int i = 0; i < bookandAuthors.Count; i++)
            {
                for (int j = 0; j < books.Count; j++)
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
            BookListBox.DataSource = null;
            BookListBox.DataSource = bookandAuthors;
        }

        private void VisitorCardListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Authors> authors = new List<Authors>();
            authors = GetAuthor();
            List<Book> books = new List<Book>();
            books = Getbooks();
            if (VisitorCardListBox.SelectedItem is LecturerCard selectedLecturerCard)
            {
                List<Faculty> facultys = new List<Faculty>();
                facultys = GetFaculty();
                lecturers = GetLecturers();
                for (int j = 0; j < lecturers.Count; j++)
                {
                    if (selectedLecturerCard.Lecturer == lecturers[j].ID)
                    {
                        NameVisitorLabel.Text = lecturers[j].Name;
                        SurnameVisitorLabel.Text = lecturers[j].Surname;
                        PatronymicVisitorLabel.Text = lecturers[j].Patronymic;
                        for (int i = 0; i < facultys.Count; i++)
                        {
                            if (lecturers[j].Faculty == facultys[i].ID)
                            {
                                GroupOrFacultyLabel.Text = facultys[i].Name;
                            }
                        }
                    }
                }
                for (int j = 0; j < bookandAuthors.Count; j++)
                {
                    if (selectedLecturerCard.Book == bookandAuthors[j].ID)
                    {
                        for (int n = 0; n < bookandAuthors.Count; n++)
                        {
                            if (bookandAuthors[j].Book == books[n].ID)
                                BookLabel.Text = books[n].Name;
                        }
                        for (int n = 0; n < bookandAuthors.Count; n++)
                        {
                            if (bookandAuthors[j].Author == authors[n].ID)
                                AuthorLabel.Text = string.Join(".", authors[j].Surname, authors[j].Name.ElementAt(0), authors[j].Patronymic.ElementAt(0));
                        }
                    }
                }
                DateOfTakingTheBookTimePicker1.Value = selectedLecturerCard.DateOfTakingTheBook;
                BookDeliveryDateTimePicker2.Value = selectedLecturerCard.BookDeliveryDate;
            }
            if (VisitorCardListBox.SelectedItem is StudentsCard selectedStudentCard)
            {
                List<Group> groups = new List<Group>();
                groups = GetGroup();
                student = Getstudent();
                for (int j = 0; j < student.Count; j++)
                {
                    if (selectedStudentCard.Student == student[j].ID)
                    {
                        NameVisitorLabel.Text = student[j].Name;
                        SurnameVisitorLabel.Text = student[j].Surname;
                        PatronymicVisitorLabel.Text = student[j].Patronymic;
                        for (int i = 0; i < groups.Count; i++)
                        {
                            if (student[j].Group == groups[i].ID)
                            {
                                GroupOrFacultyLabel.Text = groups[i].Name;
                            }
                        }
                    }
                }
                for (int j = 0; j < bookandAuthors.Count; j++)
                {
                    if (selectedStudentCard.Book == bookandAuthors[j].ID)
                    {
                        for (int n = 0; n < bookandAuthors.Count; n++)
                        {
                            if (bookandAuthors[j].Book == books[n].ID)
                                BookLabel.Text = books[n].Name;
                        }
                        for (int n = 0; n < bookandAuthors.Count; n++)
                        {
                            if (bookandAuthors[j].Author == authors[n].ID)
                                AuthorLabel.Text = string.Join(".", authors[j].Surname, authors[j].Name.ElementAt(0), authors[j].Patronymic.ElementAt(0));
                        }
                    }
                }
                DateOfTakingTheBookTimePicker1.Value = selectedStudentCard.DateOfTakingTheBook;
                BookDeliveryDateTimePicker2.Value = selectedStudentCard.BookDeliveryDate;
            }
        }

        private void VisitorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (VisitorListBox.SelectedItem is Lecturer selectedLecturer)
            {
                List<Faculty> facultys = new List<Faculty>();
                facultys = GetFaculty();
                NameVisitorLabel.Text = selectedLecturer.Name;
                SurnameVisitorLabel.Text = selectedLecturer.Surname;
                PatronymicVisitorLabel.Text = selectedLecturer.Patronymic;
                for (int i = 0; i < facultys.Count; i++)
                {
                    if (selectedLecturer.Faculty == facultys[i].ID)
                    {
                        GroupOrFacultyLabel.Text = facultys[i].Name;
                    }
                }
            }

            if (VisitorListBox.SelectedItem is Students selectedStudents)
            {
                List<Group> groups = new List<Group>();
                groups = GetGroup();
                NameVisitorLabel.Text = selectedStudents.Name;
                SurnameVisitorLabel.Text = selectedStudents.Surname;
                PatronymicVisitorLabel.Text = selectedStudents.Patronymic;
                for (int i = 0; i < groups.Count; i++)
                {
                    if (selectedStudents.Group == groups[i].ID)
                    {
                        GroupOrFacultyLabel.Text = groups[i].Name;
                    }
                }
            }
        }

        private void BookListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BookListBox.SelectedItem is BookandAuthor selectedBookandAuthor)
            {
                List<Authors> authors = new List<Authors>();
                authors = GetAuthor();
                List<Book> books = new List<Book>();
                books = Getbooks();

                for (int j = 0; j < books.Count; j++)
                {
                    if (selectedBookandAuthor.Book == books[j].ID)
                        BookLabel.Text = books[j].Name;
                }
                for (int j = 0; j < authors.Count; j++)
                {
                    if (selectedBookandAuthor.Author == authors[j].ID)
                        AuthorLabel.Text = string.Join(".", authors[j].Surname, authors[j].Name.ElementAt(0), authors[j].Patronymic.ElementAt(0));
                }

            }
        }

        private void GiveABookButton_Click(object sender, EventArgs e)
        {
            List<Group> groups = new List<Group>();
            groups = GetGroup();
            List<Faculty> facultys = new List<Faculty>();
            facultys = GetFaculty();
            for (int i = 0; i < facultys.Count; i++)
            {
                if (facultys[i].Name == GroupOrFacultyLabel.Text)
                {
                    LecturerCard lecturerCard = new LecturerCard();
                    libraryStaffs = GetLibraryStaff();
                    for (int j = 0; j < libraryStaffs.Count; j++)
                    {
                        for (int n = 0; n < StaffComboBox.Items.Count; n++)
                        {
                            string ID = StaffComboBox.Items[n].ToString();
                            if (libraryStaffs[j].ID == (Convert.ToInt32(ID.ElementAt(0)) - '0'))
                            {
                                lecturerCard.LibraryStaff = libraryStaffs[j].ID;
                            }
                        }
                    }
                    if (BookListBox.SelectedItem is BookandAuthor selectedBookandAuthor)
                        lecturerCard.Book = selectedBookandAuthor.ID;
                    lecturerCard.DateOfTakingTheBook = DateOfTakingTheBookTimePicker1.Value;
                    lecturerCard.BookDeliveryDate = BookDeliveryDateTimePicker2.Value;
                    if (VisitorListBox.SelectedItem is Lecturer selectedLecturer)
                        lecturerCard.Lecturer = selectedLecturer.ID;
                    lecturerCard.BookDelivery = false;
                    int? id = PostLecturer(lecturerCard);
                    if (id.HasValue)
                    {
                        lecturerCard.ID = id.Value;
                        lecturerCards.Add(lecturerCard);

                        PopulateLecturerListBox();
                    }
                }
            }
            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].Name == GroupOrFacultyLabel.Text)
                {
                    StudentsCard studentCard = new StudentsCard();
                    libraryStaffs = GetLibraryStaff();
                    for (int j = 0; j < libraryStaffs.Count; j++)
                    {
                        for (int n = 0; n < StaffComboBox.Items.Count; n++)
                        {
                            string ID = StaffComboBox.Items[n].ToString();
                            if (libraryStaffs[j].ID == (Convert.ToInt32(ID.ElementAt(0)) - '0'))
                            {
                                studentCard.LibraryStaff = libraryStaffs[j].ID;
                            }
                        }
                    }
                    if (BookListBox.SelectedItem is BookandAuthor selectedBookandAuthor)
                        studentCard.Book = selectedBookandAuthor.ID;
                    studentCard.DateOfTakingTheBook = DateOfTakingTheBookTimePicker1.Value;
                    studentCard.BookDeliveryDate = BookDeliveryDateTimePicker2.Value;
                    if (VisitorListBox.SelectedItem is Students selectedStudents)
                        studentCard.Student = selectedStudents.ID;
                    studentCard.BookDelivery = false;
                    int? id = PostStudent(studentCard);
                    if (id.HasValue)
                    {
                        studentCard.ID = id.Value;
                        studentsCard.Add(studentCard);

                        PopulateStudentListBox();
                    }
                }
            }
        }

        private int? PostLecturer(LecturerCard lecturerCard)
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
        private int? PostStudent(StudentsCard studentCard)
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

        private void GiveTheBookButton_Click(object sender, EventArgs e)
        {
            lecturerCards = GetLecturerCard;
            studentsCard = GetStudentCard();
            List<Group> groups = new List<Group>();
            groups = GetGroup();
            List<Faculty> facultys = new List<Faculty>();
            facultys = GetFaculty();
            for (int i = 0; i < facultys.Count; i++)
            {
                if (facultys[i].Name == GroupOrFacultyLabel.Text)
                {
                    if (VisitorCardListBox.SelectedItem is LecturerCard selectedLecturerCard)
                    {

                        selectedLecturerCard.BookDelivery = true;
                        selectedLecturerCard.BookDeliveryDate = BookDeliveryDateTimePicker2.Value;
                        if (PutLecturer(selectedLecturerCard))
                        {
                            LecturerCard edditable = lecturerCards.First(a => a.ID == selectedLecturerCard.ID);
                            edditable.LibraryStaff = selectedLecturerCard.LibraryStaff;
                            edditable.Lecturer = selectedLecturerCard.Lecturer;
                            edditable.Book = selectedLecturerCard.Book;
                            edditable.BookDelivery = selectedLecturerCard.BookDelivery;
                            edditable.DateOfTakingTheBook = selectedLecturerCard.DateOfTakingTheBook;
                            edditable.BookDeliveryDate = selectedLecturerCard.BookDeliveryDate;
                     //       PopulateLecturerListBox();
                        }
                        if (DeleteLecturer(selectedLecturerCard))
                        {
                            lecturerCards.Remove(selectedLecturerCard);
                            PopulateLecturerListBox();
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
            }
            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].Name == GroupOrFacultyLabel.Text)
                {
                    if (VisitorCardListBox.SelectedItem is StudentsCard selectedStudentCard)
                    {

                        selectedStudentCard.BookDelivery = true;
                        selectedStudentCard.BookDeliveryDate = BookDeliveryDateTimePicker2.Value;
                        if (PutStudent(selectedStudentCard))
                        {
                            StudentsCard edditable = studentsCard.First(a => a.ID == selectedStudentCard.ID);
                            edditable.LibraryStaff = selectedStudentCard.LibraryStaff;
                            edditable.Student = selectedStudentCard.Student;
                            edditable.Book = selectedStudentCard.Book;
                            edditable.BookDelivery = selectedStudentCard.BookDelivery;
                            edditable.DateOfTakingTheBook = selectedStudentCard.DateOfTakingTheBook;
                            edditable.BookDeliveryDate = selectedStudentCard.BookDeliveryDate;
                //            PopulateStudentListBox();
                           
                        }
                        if (DeleteStudent(selectedStudentCard))
                        {
                            studentsCard.Remove(selectedStudentCard);
                            PopulateStudentListBox();
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
            }
        }

        private bool PutLecturer(LecturerCard lecturerCard)
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
        private bool PutStudent(StudentsCard studentCard)
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

        private bool DeleteLecturer(LecturerCard lecturerCard)
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
        private bool DeleteStudent(StudentsCard studentCard)
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
    }
}
