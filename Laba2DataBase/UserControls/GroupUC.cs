using Laba2DataBase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace Laba2DataBase.UserControls
{
    public partial class GroupUC : BaseUC
    {
        List<Group> groups = new List<Group>();
        public GroupUC()
        {
            InitializeComponent();
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            groups = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            List<Faculty> facultys = new List<Faculty>();
            facultys = GetFaculty();
            for (int i = 0; i < groups.Count; i++)
            {
                for (int j = 0; j < facultys.Count; j++)
                {
                    if (groups[i].Faculty == facultys[j].ID)
                    {
                        groups[i].Facultystring = facultys[j].Name;
                    }
                }
            }
            GroupListBox.DataSource = null;
            GroupListBox.DataSource = groups;
        }
        private List<Group> Get()
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
        private int? Post(Group group)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {

                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO GroupStudent(Name,Faculty) VALUES(@name,@faculty);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@name", group.Name);
                    command.Parameters.AddWithValue("@faculty", group.Faculty);
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
        private bool Delete(Group group)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM GroupStudent WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", group.ID);
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
            if (GroupListBox.SelectedItem is Group group)
            {
                if (Delete(group))
                {
                    groups.Remove(group);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (GroupListBox.SelectedItem is Group selectedGroup)
            {
                string name = NameTextBox.Text;
                int faculty = Convert.ToInt32(FacultyTextBox.Text);

                if (string.IsNullOrEmpty(name) &&  faculty == null)
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                selectedGroup.Name = name;
                selectedGroup.Faculty = faculty;
                if (Put(selectedGroup))
                {
                    Group edditable = groups.First(a => a.ID == selectedGroup.ID);
                    edditable.Name = selectedGroup.Name;
                    edditable.Faculty = selectedGroup.Faculty;
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
        private bool Put(Group group)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE GroupStudent
                                                                    SET Name = @name,Faculty= @faculty
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@name", group.Name);
                        command.Parameters.AddWithValue("@faculty", group.Faculty);
                        command.Parameters.AddWithValue("@id", group.ID);
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
            if (NameTextBox.Text != "" || FacultyTextBox.Text != "")
            {
                Group group = new Group();
                group.Name = NameTextBox.Text;
                group.Faculty = Convert.ToInt32(FacultyTextBox.Text);
                int? id = Post(group);
                if (id.HasValue)
                {
                    group.ID = id.Value;
                    groups.Add(group);

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
        private void GroupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GroupListBox.SelectedItem is Group selectedGroup)
            {
                NameTextBox.Text = selectedGroup.Name;
                FacultyTextBox.Text = selectedGroup.Faculty.ToString();
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
