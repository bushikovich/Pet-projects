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

namespace Laba2DataBase
{
    public partial class AuthorsUC : BaseUC
    {
        List<Authors> authors = new List<Authors>();
        public AuthorsUC()
        {
            InitializeComponent();
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            authors = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            AuthorsListBox.DataSource = null;
            AuthorsListBox.DataSource = authors;
        }
        private List<Authors> Get()
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
        private int? Post(Authors author)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
            
                   
                    string query2 = "Select @@Identity;";
                    int id = -1;
                    string Query = "INSERT INTO Authors(Surname,Name,Patronymic,DateOfBirth) VALUES(@surname,@name,@patronymic,@dateOfBirth);";

                    using (OleDbCommand command = new OleDbCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@surname", author.Surname);
                        command.Parameters.AddWithValue("@name", author.Name);
                        command.Parameters.AddWithValue("@patronymic", author.Patronymic);
                        command.Parameters.Add("@dateOfBirth", OleDbType.Date).Value = author.DateOfBirth;
                    try
                        {
                            connection.Open();
                            if(command.ExecuteNonQuery()>0)
                            {
                                command.CommandText = query2;
                                id = Convert.ToInt32(command.ExecuteScalar());
                                return id;
                            }
                        }
                        catch(Exception ex)
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
        private bool Delete(Authors author)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM  Authors WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", author.ID);
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
            if (AuthorsListBox.SelectedItem is Authors author)
            {
                if (Delete(author))
                {
                    authors.Remove(author);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (AuthorsListBox.SelectedItem is Authors selectedAuthor)
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

                selectedAuthor.Name = name;
                selectedAuthor.Patronymic = patronymic;
                selectedAuthor.Surname = surname;
                selectedAuthor.DateOfBirth = dateOfBirth;
                if (Put(selectedAuthor))
                {
                    Authors edditable = authors.First(a => a.ID == selectedAuthor.ID);
                    edditable.Name = selectedAuthor.Name;
                    edditable.Patronymic = selectedAuthor.Patronymic;
                    edditable.Surname = selectedAuthor.Surname;
                    edditable.DateOfBirth = selectedAuthor.DateOfBirth;
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
        private bool Put(Authors author)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE Authors
                                                                    SET Name = @name, Surname = @surname,  Patronymic=@patronymic
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@surname", author.Surname);
                        command.Parameters.AddWithValue("@name", author.Name);
                        command.Parameters.AddWithValue("@patronymic", author.Patronymic);
                        command.Parameters.AddWithValue("@id", author.ID);
                        command.Parameters.Add("@dateOfBirth", OleDbType.Date).Value = author.DateOfBirth;
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
                Authors author = new Authors();
                author.Surname = SurnameTextBox.Text;
                author.Name = NameTextBox.Text;
                author.Patronymic = PatronymicTextBox.Text;
                author.DateOfBirth = DateOfBirthDateTime.Value;
                int? id = Post(author);
                if (id.HasValue)
                {
                    author.ID = id.Value;
                    authors.Add(author);

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
        private void AuthorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AuthorsListBox.SelectedItem is Authors selectedAuthor)
            {
                NameTextBox.Text = selectedAuthor.Name;
                SurnameTextBox.Text = selectedAuthor.Surname;
                PatronymicTextBox.Text = selectedAuthor.Patronymic;
                DateOfBirthDateTime.Value = selectedAuthor.DateOfBirth;
            }
        }
    }
}
