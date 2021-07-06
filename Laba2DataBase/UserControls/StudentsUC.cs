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
    public partial class StudentsUC : BaseUC
    {
        List<Students> students = new List<Students>();

        public StudentsUC()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            students = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            List<Group> groups = new List<Group>();
            groups = GetGroup();
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < groups.Count; j++)
                {
                    if (students[i].Group == groups[j].ID)
                    {
                        students[i].Groupstring = groups[j].Name;
                    }
                }
            }
            StudentsListBox.DataSource = null;
            StudentsListBox.DataSource = students;
        }
        private List<Students> Get()
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
        private int? Post(Students student)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO Students(Surname,Name,Patronymic,DateOfBirth,GroupStudent) VALUES(@surname,@name,@patronymic,@dateOfBirth,@group);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@surname", student.Surname);
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@patronymic", student.Patronymic);
                    command.Parameters.Add("@dateOfBirth", OleDbType.Date).Value = student.DateOfBirth;
                    command.Parameters.AddWithValue("@group", student.Group);
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
        private bool Delete(Students student)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM  Students WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", student.ID);
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
            if (StudentsListBox.SelectedItem is Students student)
            {
                if (Delete(student))
                {
                    students.Remove(student);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (StudentsListBox.SelectedItem is Students selectedStudent)
            {
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
                string patronymic = PatronymicTextBox.Text;
                DateTime dateOfBirth = DateOfBirthDateTime.Value;
                int group = Convert.ToInt32(GroupTextBox.Text);

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(patronymic) && group == null)
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                selectedStudent.Name = name;
                selectedStudent.Patronymic = patronymic;
                selectedStudent.Surname = surname;
                selectedStudent.DateOfBirth = dateOfBirth;
                selectedStudent.Group = group;
                if (Put(selectedStudent))
                {
                    Students edditable = students.First(a => a.ID == selectedStudent.ID);
                    edditable.Name = selectedStudent.Name;
                    edditable.Patronymic = selectedStudent.Patronymic;
                    edditable.Surname = selectedStudent.Surname;
                    edditable.DateOfBirth = selectedStudent.DateOfBirth;
                    edditable.Group = selectedStudent.Group;
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
        private bool Put(Students student)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE Students
                                                                    SET Name = @name, Surname = @surname,Patronymic=@patronymic,GroupStudent=@group
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@surname", student.Surname);
                        command.Parameters.AddWithValue("@name", student.Name);
                        command.Parameters.AddWithValue("@patronymic", student.Patronymic);
                        command.Parameters.AddWithValue("@group", student.Group);
                        command.Parameters.AddWithValue("@id", student.ID);
                        command.Parameters.Add("@dateOfBirth", OleDbType.Date).Value = student.DateOfBirth;
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
            if (SurnameTextBox.Text != "" && NameTextBox.Text != "" && PatronymicTextBox.Text != "" && GroupTextBox.Text != "")
            {
                Students student = new Students();
                student.Surname = SurnameTextBox.Text;
                student.Name = NameTextBox.Text;
                student.Patronymic = PatronymicTextBox.Text;
                student.DateOfBirth = DateOfBirthDateTime.Value;
                student.Group = Convert.ToInt32(GroupTextBox.Text);
                int? id = Post(student);
                if (id.HasValue)
                {
                    student.ID = id.Value;
                    students.Add(student);

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
        private void StudentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentsListBox.SelectedItem is Students selectedStudents)
            {
                NameTextBox.Text = selectedStudents.Name;
                SurnameTextBox.Text = selectedStudents.Surname;
                PatronymicTextBox.Text = selectedStudents.Patronymic;
                DateOfBirthDateTime.Value = selectedStudents.DateOfBirth;
                GroupTextBox.Text = selectedStudents.Group.ToString();
            }
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
    }
}
