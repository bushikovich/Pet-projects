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
    public partial class PublishersUC : BaseUC
    {
        List<Publishers> publishers = new List<Publishers>();
        public PublishersUC()
        {
            InitializeComponent();
        }
        private void SelectButton_Click(object sender, EventArgs e)
        {
            publishers = Get();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            PublishersListBox.DataSource = null;
            PublishersListBox.DataSource = publishers;
        }
        private List<Publishers> Get()
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
        private int? Post(Publishers publishers)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {


                string query2 = "Select @@Identity;";
                int id = -1;
                string Query = "INSERT INTO Publishers(Address,Name) VALUES(@address,@name);";

                using (OleDbCommand command = new OleDbCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@address", publishers.Address);
                    command.Parameters.AddWithValue("@name", publishers.Name);

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
        private bool Delete(Publishers publishers)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("DELETE FROM  Publishers WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", publishers.ID);
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
            if (PublishersListBox.SelectedItem is Publishers publisher)
            {
                if (Delete(publisher))
                {
                    publishers.Remove(publisher);
                    PopulateListBox();
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (PublishersListBox.SelectedItem is Publishers publisher)
            {
                string name = NameTextBox.Text;
                string address = AddressTextBox.Text;;

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(address))
                {
                    MessageBox.Show(
              "Not all fields are filled",
              "ERROR",
              MessageBoxButtons.OK,
              MessageBoxIcon.None,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
                }

                publisher.Name = name;
                publisher.Address = address;
                if (Put(publisher))
                {
                    Publishers edditable = publishers.First(a => a.ID == publisher.ID);
                    edditable.Name = publisher.Name;
                    edditable.Address = publisher.Address;
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
        private bool Put(Publishers publisher)
        {
            using (OleDbConnection connection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(@"UPDATE Publishers
                                                                    SET Name = @name, Address = @address
                                                                    WHERE ID = @id", connection))
                    {
                        command.Parameters.AddWithValue("@surname", publisher.Address);
                        command.Parameters.AddWithValue("@name", publisher.Name);
                        command.Parameters.AddWithValue("@id", publisher.ID);
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
            if (AddressTextBox.Text != "" && NameTextBox.Text != "")
            {
                Publishers publisher = new Publishers();
                publisher.Address = AddressTextBox.Text;
                publisher.Name = NameTextBox.Text;
                int? id = Post(publisher);
                if (id.HasValue)
                {
                    publisher.ID = id.Value;
                    publishers.Add(publisher);

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
        private void PublishersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PublishersListBox.SelectedItem is Publishers selectedPublisher)
            {
                NameTextBox.Text = selectedPublisher.Name;
                AddressTextBox.Text = selectedPublisher.Address;
            }
        }
    }
}
