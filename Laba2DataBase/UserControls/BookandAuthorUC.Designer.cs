namespace Laba2DataBase.UserControls
{
    partial class BookandAuthorUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InsertButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.BookLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.BookandAuthorListBox = new System.Windows.Forms.ListBox();
            this.BookTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(507, 167);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 56;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(669, 167);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 55;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(588, 167);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 54;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(426, 167);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 53;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // BookLabel
            // 
            this.BookLabel.AutoSize = true;
            this.BookLabel.Location = new System.Drawing.Point(466, 102);
            this.BookLabel.Name = "BookLabel";
            this.BookLabel.Size = new System.Drawing.Size(32, 13);
            this.BookLabel.TabIndex = 52;
            this.BookLabel.Text = "Book";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(460, 65);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(38, 13);
            this.AuthorLabel.TabIndex = 51;
            this.AuthorLabel.Text = "Author";
            // 
            // BookandAuthorListBox
            // 
            this.BookandAuthorListBox.FormattingEnabled = true;
            this.BookandAuthorListBox.Location = new System.Drawing.Point(19, 17);
            this.BookandAuthorListBox.Name = "BookandAuthorListBox";
            this.BookandAuthorListBox.Size = new System.Drawing.Size(401, 381);
            this.BookandAuthorListBox.TabIndex = 50;
            this.BookandAuthorListBox.SelectedIndexChanged += new System.EventHandler(this.BookandAuthorListBox_SelectedIndexChanged);
            // 
            // BookTextBox
            // 
            this.BookTextBox.Location = new System.Drawing.Point(507, 99);
            this.BookTextBox.Name = "BookTextBox";
            this.BookTextBox.Size = new System.Drawing.Size(200, 20);
            this.BookTextBox.TabIndex = 49;
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(507, 62);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(200, 20);
            this.AuthorTextBox.TabIndex = 48;
            // 
            // BookandAuthorUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.BookLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.BookandAuthorListBox);
            this.Controls.Add(this.BookTextBox);
            this.Controls.Add(this.AuthorTextBox);
            this.Name = "BookandAuthorUC";
            this.Size = new System.Drawing.Size(799, 418);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Label BookLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.ListBox BookandAuthorListBox;
        private System.Windows.Forms.TextBox BookTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
    }
}
