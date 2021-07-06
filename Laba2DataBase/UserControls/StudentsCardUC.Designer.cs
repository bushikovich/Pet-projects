namespace Laba2DataBase.UserControls
{
    partial class StudentsCardUC
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
            this.BookDeliverycheckBox = new System.Windows.Forms.CheckBox();
            this.BookDeliveryLabel = new System.Windows.Forms.Label();
            this.InsertButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.DateOfTakingTheBookLabel = new System.Windows.Forms.Label();
            this.BookLabel = new System.Windows.Forms.Label();
            this.StudentLabel = new System.Windows.Forms.Label();
            this.LibraryStaffLabel = new System.Windows.Forms.Label();
            this.StudentCardListBox = new System.Windows.Forms.ListBox();
            this.DateOfTakingTheBookDateTime = new System.Windows.Forms.DateTimePicker();
            this.BookTextBox = new System.Windows.Forms.TextBox();
            this.StudentTextBox = new System.Windows.Forms.TextBox();
            this.LibraryStaffTextBox = new System.Windows.Forms.TextBox();
            this.BookDeliveryDateLabel = new System.Windows.Forms.Label();
            this.BookDeliveryDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // BookDeliverycheckBox
            // 
            this.BookDeliverycheckBox.AutoSize = true;
            this.BookDeliverycheckBox.Location = new System.Drawing.Point(505, 167);
            this.BookDeliverycheckBox.Name = "BookDeliverycheckBox";
            this.BookDeliverycheckBox.Size = new System.Drawing.Size(15, 14);
            this.BookDeliverycheckBox.TabIndex = 71;
            this.BookDeliverycheckBox.UseVisualStyleBackColor = true;
            // 
            // BookDeliveryLabel
            // 
            this.BookDeliveryLabel.AutoSize = true;
            this.BookDeliveryLabel.Location = new System.Drawing.Point(426, 168);
            this.BookDeliveryLabel.Name = "BookDeliveryLabel";
            this.BookDeliveryLabel.Size = new System.Drawing.Size(73, 13);
            this.BookDeliveryLabel.TabIndex = 70;
            this.BookDeliveryLabel.Text = "Book Delivery";
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(491, 261);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 69;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(653, 261);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 68;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(572, 261);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 67;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(410, 261);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 66;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // DateOfTakingTheBookLabel
            // 
            this.DateOfTakingTheBookLabel.AutoSize = true;
            this.DateOfTakingTheBookLabel.Location = new System.Drawing.Point(425, 128);
            this.DateOfTakingTheBookLabel.Name = "DateOfTakingTheBookLabel";
            this.DateOfTakingTheBookLabel.Size = new System.Drawing.Size(130, 13);
            this.DateOfTakingTheBookLabel.TabIndex = 65;
            this.DateOfTakingTheBookLabel.Text = "Date Of Taking The Book";
            // 
            // BookLabel
            // 
            this.BookLabel.AutoSize = true;
            this.BookLabel.Location = new System.Drawing.Point(426, 93);
            this.BookLabel.Name = "BookLabel";
            this.BookLabel.Size = new System.Drawing.Size(32, 13);
            this.BookLabel.TabIndex = 64;
            this.BookLabel.Text = "Book";
            // 
            // StudentLabel
            // 
            this.StudentLabel.AutoSize = true;
            this.StudentLabel.Location = new System.Drawing.Point(426, 58);
            this.StudentLabel.Name = "StudentLabel";
            this.StudentLabel.Size = new System.Drawing.Size(44, 13);
            this.StudentLabel.TabIndex = 63;
            this.StudentLabel.Text = "Student";
            // 
            // LibraryStaffLabel
            // 
            this.LibraryStaffLabel.AutoSize = true;
            this.LibraryStaffLabel.Location = new System.Drawing.Point(425, 21);
            this.LibraryStaffLabel.Name = "LibraryStaffLabel";
            this.LibraryStaffLabel.Size = new System.Drawing.Size(60, 13);
            this.LibraryStaffLabel.TabIndex = 62;
            this.LibraryStaffLabel.Text = "LibraryStaff";
            // 
            // StudentCardListBox
            // 
            this.StudentCardListBox.FormattingEnabled = true;
            this.StudentCardListBox.Location = new System.Drawing.Point(3, 18);
            this.StudentCardListBox.Name = "StudentCardListBox";
            this.StudentCardListBox.Size = new System.Drawing.Size(401, 381);
            this.StudentCardListBox.TabIndex = 61;
            this.StudentCardListBox.SelectedIndexChanged += new System.EventHandler(this.StudentCardListBox_SelectedIndexChanged);
            // 
            // DateOfTakingTheBookDateTime
            // 
            this.DateOfTakingTheBookDateTime.Location = new System.Drawing.Point(570, 122);
            this.DateOfTakingTheBookDateTime.Name = "DateOfTakingTheBookDateTime";
            this.DateOfTakingTheBookDateTime.Size = new System.Drawing.Size(121, 20);
            this.DateOfTakingTheBookDateTime.TabIndex = 60;
            // 
            // BookTextBox
            // 
            this.BookTextBox.Location = new System.Drawing.Point(491, 93);
            this.BookTextBox.Name = "BookTextBox";
            this.BookTextBox.Size = new System.Drawing.Size(200, 20);
            this.BookTextBox.TabIndex = 59;
            // 
            // StudentTextBox
            // 
            this.StudentTextBox.Location = new System.Drawing.Point(491, 55);
            this.StudentTextBox.Name = "StudentTextBox";
            this.StudentTextBox.Size = new System.Drawing.Size(200, 20);
            this.StudentTextBox.TabIndex = 58;
            // 
            // LibraryStaffTextBox
            // 
            this.LibraryStaffTextBox.Location = new System.Drawing.Point(491, 18);
            this.LibraryStaffTextBox.Name = "LibraryStaffTextBox";
            this.LibraryStaffTextBox.Size = new System.Drawing.Size(200, 20);
            this.LibraryStaffTextBox.TabIndex = 57;
            // 
            // BookDeliveryDateLabel
            // 
            this.BookDeliveryDateLabel.AutoSize = true;
            this.BookDeliveryDateLabel.Location = new System.Drawing.Point(427, 212);
            this.BookDeliveryDateLabel.Name = "BookDeliveryDateLabel";
            this.BookDeliveryDateLabel.Size = new System.Drawing.Size(99, 13);
            this.BookDeliveryDateLabel.TabIndex = 73;
            this.BookDeliveryDateLabel.Text = "Book Delivery Date";
            // 
            // BookDeliveryDateDateTimePicker
            // 
            this.BookDeliveryDateDateTimePicker.Location = new System.Drawing.Point(570, 206);
            this.BookDeliveryDateDateTimePicker.Name = "BookDeliveryDateDateTimePicker";
            this.BookDeliveryDateDateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.BookDeliveryDateDateTimePicker.TabIndex = 72;
            // 
            // StudentsCardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BookDeliveryDateLabel);
            this.Controls.Add(this.BookDeliveryDateDateTimePicker);
            this.Controls.Add(this.BookDeliverycheckBox);
            this.Controls.Add(this.BookDeliveryLabel);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.DateOfTakingTheBookLabel);
            this.Controls.Add(this.BookLabel);
            this.Controls.Add(this.StudentLabel);
            this.Controls.Add(this.LibraryStaffLabel);
            this.Controls.Add(this.StudentCardListBox);
            this.Controls.Add(this.DateOfTakingTheBookDateTime);
            this.Controls.Add(this.BookTextBox);
            this.Controls.Add(this.StudentTextBox);
            this.Controls.Add(this.LibraryStaffTextBox);
            this.Name = "StudentsCardUC";
            this.Size = new System.Drawing.Size(752, 425);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox BookDeliverycheckBox;
        private System.Windows.Forms.Label BookDeliveryLabel;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Label DateOfTakingTheBookLabel;
        private System.Windows.Forms.Label BookLabel;
        private System.Windows.Forms.Label StudentLabel;
        private System.Windows.Forms.Label LibraryStaffLabel;
        private System.Windows.Forms.ListBox StudentCardListBox;
        private System.Windows.Forms.DateTimePicker DateOfTakingTheBookDateTime;
        private System.Windows.Forms.TextBox BookTextBox;
        private System.Windows.Forms.TextBox StudentTextBox;
        private System.Windows.Forms.TextBox LibraryStaffTextBox;
        private System.Windows.Forms.Label BookDeliveryDateLabel;
        private System.Windows.Forms.DateTimePicker BookDeliveryDateDateTimePicker;
    }
}
