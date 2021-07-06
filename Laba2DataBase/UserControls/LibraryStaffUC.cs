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
    public partial class LibraryStaffUC : BaseUC
    {
        public LibraryStaffUC()
        {
            InitializeComponent();
        }
        List<LibraryStaff> libraryStaffs = new List<LibraryStaff>();
        private void SelectButton_Click(object sender, EventArgs e)
        {
            libraryStaffs = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            LibraryStaffListBox.DataSource = null;
            LibraryStaffListBox.DataSource = libraryStaffs;
        }
        private List<LibraryStaff> Get()
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
        private int? Post(LibraryStaff libraryStaff)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {


                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO LibraryStaff(Surname,Name,Patronymic,DateOfBirth) VALUES(@surname,@name,@patronymic,@dateOfBirth);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@surname", libraryStaff.Surname);
                    command.Parameters.AddWithValue("@name", libraryStaff.Name);
                    command.Parameters.AddWithValue("@patronymic", libraryStaff.Patronymic);
                    command.Parameters.Add("@dateOfBirth", OleDbType.Date).Value = libraryStaff.DateOfBirth;
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
        private bool Delete(LibraryStaff libraryStaff)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM  LibraryStaff WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", libraryStaff.ID);
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
            if (LibraryStaffListBox.SelectedItem is LibraryStaff libraryStaff)
            {
                if (Delete(libraryStaff))
                {
                    libraryStaffs.Remove(libraryStaff);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (LibraryStaffListBox.SelectedItem is LibraryStaff selectedLibraryStaff)
            {
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
                string patronymic = PatronymicTextBox.Text;
                DateTime dateOfBirth = DateOfBirthDateTime.Value;

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(patronymic))
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                selectedLibraryStaff.Name = name;
                selectedLibraryStaff.Patronymic = patronymic;
                selectedLibraryStaff.Surname = surname;
                selectedLibraryStaff.DateOfBirth = dateOfBirth;
                if (Put(selectedLibraryStaff))
                {
                    LibraryStaff edditable = libraryStaffs.First(a => a.ID == selectedLibraryStaff.ID);
                    edditable.Name = selectedLibraryStaff.Name;
                    edditable.Patronymic = selectedLibraryStaff.Patronymic;
                    edditable.Surname = selectedLibraryStaff.Surname;
                    edditable.DateOfBirth = selectedLibraryStaff.DateOfBirth;
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
        private bool Put(LibraryStaff libraryStaff)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE LibraryStaff
                                                                    SET Name = @name, Surname = @surname,  Patronymic=@patronymic
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@surname", libraryStaff.Surname);
                        command.Parameters.AddWithValue("@name", libraryStaff.Name);
                        command.Parameters.AddWithValue("@patronymic", libraryStaff.Patronymic);
                        command.Parameters.AddWithValue("@id", libraryStaff.ID);
                        command.Parameters.Add("@dateOfBirth", OleDbType.Date).Value = libraryStaff.DateOfBirth;
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
            if (SurnameTextBox.Text != "" && NameTextBox.Text != "" && PatronymicTextBox.Text != "")
            {
                LibraryStaff libraryStaff = new LibraryStaff();
                libraryStaff.Surname = SurnameTextBox.Text;
                libraryStaff.Name = NameTextBox.Text;
                libraryStaff.Patronymic = PatronymicTextBox.Text;
                libraryStaff.DateOfBirth = DateOfBirthDateTime.Value;
                int? id = Post(libraryStaff);
                if (id.HasValue)
                {
                    libraryStaff.ID = id.Value;
                    libraryStaffs.Add(libraryStaff);

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
        private void LibraryStaffListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LibraryStaffListBox.SelectedItem is LibraryStaff selectedLibraryStaff)
            {
                NameTextBox.Text = selectedLibraryStaff.Name;
                SurnameTextBox.Text = selectedLibraryStaff.Surname;
                PatronymicTextBox.Text = selectedLibraryStaff.Patronymic;
                DateOfBirthDateTime.Value = selectedLibraryStaff.DateOfBirth;
            }
        }
    }
}
