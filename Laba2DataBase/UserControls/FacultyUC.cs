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
    public partial class FacultyUC : BaseUC
    {
        public FacultyUC()
        {
            InitializeComponent();
        }
        List<Faculty> facultys = new List<Faculty>();
        private void SelectButton_Click(object sender, EventArgs e)
        {
            facultys = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {

            FacultyListBox.DataSource = null;
            FacultyListBox.DataSource = facultys;
        }
        private List<Faculty> Get()
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
        private int? Post(Faculty faculty)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO Faculty(Name) VALUES(@name);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@name", faculty.Name);
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
        private bool Delete(Faculty faculty)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM Faculty WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", faculty.ID);
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
            if (FacultyListBox.SelectedItem is Faculty faculty)
            {
                if (Delete(faculty))
                {
                    facultys.Remove(faculty);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (FacultyListBox.SelectedItem is Faculty selectedFaculty)
            {
                string name = NameTextBox.Text;

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                selectedFaculty.Name = name;
                if (Put(selectedFaculty))
                {
                    Faculty edditable = facultys.First(a => a.ID == selectedFaculty.ID);
                    edditable.Name = selectedFaculty.Name;
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
        private bool Put(Faculty faculty)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE Faculty
                                                                    SET Name = @name
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@name", faculty.Name);
                        command.Parameters.AddWithValue("@id", faculty.ID);
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
        private void InsertButton_Click(object sender, EventArgs e)
        {
            //TODO: check all fields
            if (NameTextBox.Text != "")
            {
                Faculty faculty = new Faculty();
                faculty.Name = NameTextBox.Text;
                int? id = Post(faculty);
                if (id.HasValue)
                {
                    faculty.ID = id.Value;
                    facultys.Add(faculty);

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
        private void FacultyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FacultyListBox.SelectedItem is Faculty selectedFaculty)
            {
                NameTextBox.Text = selectedFaculty.Name;
            }
        }
    }
}
