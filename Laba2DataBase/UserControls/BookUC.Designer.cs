namespace Laba2DataBase.UserControls
{
    partial class BookUC
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
            this.PublishingYearLabel = new System.Windows.Forms.Label();
            this.PublisherLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.BookListBox = new System.Windows.Forms.ListBox();
            this.PublishingYearDateTime = new System.Windows.Forms.DateTimePicker();
            this.PublisherTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(506, 178);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 38;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(668, 178);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 37;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(587, 178);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 36;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(425, 178);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 35;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // PublishingYearLabel
            // 
            this.PublishingYearLabel.AutoSize = true;
            this.PublishingYearLabel.Location = new System.Drawing.Point(422, 130);
            this.PublishingYearLabel.Name = "PublishingYearLabel";
            this.PublishingYearLabel.Size = new System.Drawing.Size(80, 13);
            this.PublishingYearLabel.TabIndex = 34;
            this.PublishingYearLabel.Text = "Publishing Year";
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Location = new System.Drawing.Point(450, 97);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(50, 13);
            this.PublisherLabel.TabIndex = 33;
            this.PublisherLabel.Text = "Publisher";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(471, 59);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 32;
            this.NameLabel.Text = "Name";
            // 
            // BookListBox
            // 
            this.BookListBox.FormattingEnabled = true;
            this.BookListBox.Location = new System.Drawing.Point(15, 14);
            this.BookListBox.Name = "BookListBox";
            this.BookListBox.Size = new System.Drawing.Size(401, 381);
            this.BookListBox.TabIndex = 30;
            this.BookListBox.SelectedIndexChanged += new System.EventHandler(this.BookListBox_SelectedIndexChanged);
            // 
            // PublishingYearDateTime
            // 
            this.PublishingYearDateTime.Location = new System.Drawing.Point(512, 130);
            this.PublishingYearDateTime.Name = "PublishingYearDateTime";
            this.PublishingYearDateTime.Size = new System.Drawing.Size(200, 20);
            this.PublishingYearDateTime.TabIndex = 29;
            // 
            // PublisherTextBox
            // 
            this.PublisherTextBox.Location = new System.Drawing.Point(512, 94);
            this.PublisherTextBox.Name = "PublisherTextBox";
            this.PublisherTextBox.Size = new System.Drawing.Size(200, 20);
            this.PublisherTextBox.TabIndex = 28;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(512, 56);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(200, 20);
            this.NameTextBox.TabIndex = 27;
            // 
            // BookUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.PublishingYearLabel);
            this.Controls.Add(this.PublisherLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.BookListBox);
            this.Controls.Add(this.PublishingYearDateTime);
            this.Controls.Add(this.PublisherTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Name = "BookUC";
            this.Size = new System.Drawing.Size(762, 419);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Label PublishingYearLabel;
        private System.Windows.Forms.Label PublisherLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.ListBox BookListBox;
        private System.Windows.Forms.DateTimePicker PublishingYearDateTime;
        private System.Windows.Forms.TextBox PublisherTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
    }
}
