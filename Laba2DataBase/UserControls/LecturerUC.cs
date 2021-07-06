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
    public partial class LecturerUC : BaseUC
    {
        List<Lecturer> lecturers = new List<Lecturer>();
        public LecturerUC()
        {
            InitializeComponent();
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            lecturers = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            List<Faculty> facultys = new List<Faculty>();
            facultys = GetFaculty();
            for(int i =0;i<lecturers.Count;i++)
            {
                for(int j = 0; j<facultys.Count;j++)
                {
                    if (lecturers[i].Faculty == facultys[j].ID)
                    {
                        lecturers[i].Facultystring = facultys[j].Name;
                    }
                }
            }
            LecturersListBox.DataSource = null;
            LecturersListBox.DataSource = lecturers;
        }
        private List<Lecturer> Get()
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
        private int? Post(Lecturer lecturer)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO Lecturers(Surname,Name,Patronymic,DateOfBirth,Faculty) VALUES(@surname,@name,@patronymic,@dateOfBirth,@faculty);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@surname", lecturer.Surname);
                    command.Parameters.AddWithValue("@name", lecturer.Name);
                    command.Parameters.AddWithValue("@patronymic", lecturer.Patronymic);
                    command.Parameters.Add("@dateOfBirth", OleDbType.Date).Value = lecturer.DateOfBirth;
                    command.Parameters.AddWithValue("@faculty", lecturer.Faculty);
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
        private bool Delete(Lecturer lecturer)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM  Lecturers WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", lecturer.ID);
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
            if (LecturersListBox.SelectedItem is Lecturer lecturer)
            {
                if (Delete(lecturer))
                {
                    lecturers.Remove(lecturer);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (LecturersListBox.SelectedItem is Lecturer selectedLecturer)
            {
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
                string patronymic = PatronymicTextBox.Text;
                DateTime dateOfBirth = DateOfBirthDateTime.Value;
                int faculty = Convert.ToInt32(FacultyBox.Text);

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(patronymic )&& faculty==null)
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                selectedLecturer.Name = name;
                selectedLecturer.Patronymic = patronymic;
                selectedLecturer.Surname = surname;
                selectedLecturer.DateOfBirth = dateOfBirth;
                selectedLecturer.Faculty = faculty;
                if (Put(selectedLecturer))
                {
                    Lecturer edditable = lecturers.First(a => a.ID == selectedLecturer.ID);
                    edditable.Name = selectedLecturer.Name;
                    edditable.Patronymic = selectedLecturer.Patronymic;
                    edditable.Surname = selectedLecturer.Surname;
                    edditable.DateOfBirth = selectedLecturer.DateOfBirth;
                    edditable.Faculty = selectedLecturer.Faculty;
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
        private bool Put(Lecturer lecturer)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE Lecturers
                                                                    SET Name = @name, Surname = @surname,Patronymic=@patronymic,Faculty= @faculty
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@surname", lecturer.Surname);
                        command.Parameters.AddWithValue("@name", lecturer.Name);
                        command.Parameters.AddWithValue("@patronymic", lecturer.Patronymic);
                        command.Parameters.AddWithValue("@faculty", lecturer.Faculty);
                        command.Parameters.AddWithValue("@id", lecturer.ID);
                        command.Parameters.Add("@dateOfBirth", OleDbType.Date).Value = lecturer.DateOfBirth;
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
            if (SurnameTextBox.Text != "" && NameTextBox.Text != "" && PatronymicTextBox.Text != "" && FacultyBox.Text != "")
            {
                Lecturer lecturer = new Lecturer();
                lecturer.Surname = SurnameTextBox.Text;
                lecturer.Name = NameTextBox.Text;
                lecturer.Patronymic = PatronymicTextBox.Text;
                lecturer.DateOfBirth = DateOfBirthDateTime.Value;
                lecturer.Faculty = Convert.ToInt32(FacultyBox.Text);
                int? id = Post(lecturer);
                if (id.HasValue)
                {
                    lecturer.ID = id.Value;
                    lecturers.Add(lecturer);

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
        private void LecturersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LecturersListBox.SelectedItem is Lecturer selectedLecturer)
            {
                NameTextBox.Text = selectedLecturer.Name;
                SurnameTextBox.Text = selectedLecturer.Surname;
                PatronymicTextBox.Text = selectedLecturer.Patronymic;
                DateOfBirthDateTime.Value = selectedLecturer.DateOfBirth;
                FacultyBox.Text = selectedLecturer.Faculty.ToString();
            }
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
    }
}
