namespace Laba2DataBase.UserControls
{
    partial class StaffUC
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
            this.VisitorCardListBox = new System.Windows.Forms.ListBox();
            this.StaffComboBox = new System.Windows.Forms.ComboBox();
            this.Stafflabel = new System.Windows.Forms.Label();
            this.BookListBox = new System.Windows.Forms.ListBox();
            this.VisitorListBox = new System.Windows.Forms.ListBox();
            this.SearchVisitorTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabelVisitors = new System.Windows.Forms.Label();
            this.SearchStudentButton = new System.Windows.Forms.Button();
            this.SearchAllStudentButton = new System.Windows.Forms.Button();
            this.SearchLecturerButton = new System.Windows.Forms.Button();
            this.SearchAllLecturerButton = new System.Windows.Forms.Button();
            this.SearchSpecificButton = new System.Windows.Forms.Button();
            this.SearchAuthorsTextBox = new System.Windows.Forms.TextBox();
            this.SearchBookLabel = new System.Windows.Forms.Label();
            this.SearchAllButton = new System.Windows.Forms.Button();
            this.NameVisitorLabel = new System.Windows.Forms.Label();
            this.SurnameVisitorLabel = new System.Windows.Forms.Label();
            this.PatronymicVisitorLabel = new System.Windows.Forms.Label();
            this.PatronymicStaffLabel = new System.Windows.Forms.Label();
            this.SurnameStaffLabel = new System.Windows.Forms.Label();
            this.NameStaffLabel = new System.Windows.Forms.Label();
            this.StaticStaffLabel = new System.Windows.Forms.Label();
            this.BookLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.DateOfTakingTheBookTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.BookDeliveryDateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.GroupOrFacultyLabel = new System.Windows.Forms.Label();
            this.BookDeliveryDateLabel = new System.Windows.Forms.Label();
            this.DateOfTakingTheBookLabel = new System.Windows.Forms.Label();
            this.GiveABookButton = new System.Windows.Forms.Button();
            this.GiveTheBookButton = new System.Windows.Forms.Button();
            this.VisitorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VisitorCardListBox
            // 
            this.VisitorCardListBox.FormattingEnabled = true;
            this.VisitorCardListBox.Location = new System.Drawing.Point(12, 61);
            this.VisitorCardListBox.Name = "VisitorCardListBox";
            this.VisitorCardListBox.Size = new System.Drawing.Size(514, 160);
            this.VisitorCardListBox.TabIndex = 0;
            this.VisitorCardListBox.SelectedIndexChanged += new System.EventHandler(this.VisitorCardListBox_SelectedIndexChanged);
            // 
            // StaffComboBox
            // 
            this.StaffComboBox.FormattingEnabled = true;
            this.StaffComboBox.Location = new System.Drawing.Point(623, 28);
            this.StaffComboBox.Name = "StaffComboBox";
            this.StaffComboBox.Size = new System.Drawing.Size(121, 21);
            this.StaffComboBox.TabIndex = 1;
            this.StaffComboBox.SelectedIndexChanged += new System.EventHandler(this.StaffComboBox_SelectedIndexChanged);
            // 
            // Stafflabel
            // 
            this.Stafflabel.AutoSize = true;
            this.Stafflabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stafflabel.Location = new System.Drawing.Point(567, 28);
            this.Stafflabel.Name = "Stafflabel";
            this.Stafflabel.Size = new System.Drawing.Size(50, 21);
            this.Stafflabel.TabIndex = 2;
            this.Stafflabel.Text = "Staff:";
            // 
            // BookListBox
            // 
            this.BookListBox.FormattingEnabled = true;
            this.BookListBox.Location = new System.Drawing.Point(9, 423);
            this.BookListBox.Name = "BookListBox";
            this.BookListBox.Size = new System.Drawing.Size(517, 160);
            this.BookListBox.TabIndex = 7;
            this.BookListBox.SelectedIndexChanged += new System.EventHandler(this.BookListBox_SelectedIndexChanged);
            // 
            // VisitorListBox
            // 
            this.VisitorListBox.FormattingEnabled = true;
            this.VisitorListBox.Location = new System.Drawing.Point(12, 227);
            this.VisitorListBox.Name = "VisitorListBox";
            this.VisitorListBox.Size = new System.Drawing.Size(514, 160);
            this.VisitorListBox.TabIndex = 8;
            this.VisitorListBox.SelectedIndexChanged += new System.EventHandler(this.VisitorListBox_SelectedIndexChanged);
            // 
            // SearchVisitorTextBox
            // 
            this.SearchVisitorTextBox.Location = new System.Drawing.Point(67, 28);
            this.SearchVisitorTextBox.Name = "SearchVisitorTextBox";
            this.SearchVisitorTextBox.Size = new System.Drawing.Size(123, 20);
            this.SearchVisitorTextBox.TabIndex = 9;
            // 
            // SearchLabelVisitors
            // 
            this.SearchLabelVisitors.AutoSize = true;
            this.SearchLabelVisitors.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchLabelVisitors.Location = new System.Drawing.Point(3, 26);
            this.SearchLabelVisitors.Name = "SearchLabelVisitors";
            this.SearchLabelVisitors.Size = new System.Drawing.Size(63, 21);
            this.SearchLabelVisitors.TabIndex = 10;
            this.SearchLabelVisitors.Text = "Visitor:";
            // 
            // SearchStudentButton
            // 
            this.SearchStudentButton.Location = new System.Drawing.Point(196, 28);
            this.SearchStudentButton.Name = "SearchStudentButton";
            this.SearchStudentButton.Size = new System.Drawing.Size(87, 20);
            this.SearchStudentButton.TabIndex = 11;
            this.SearchStudentButton.Text = "SearchStudent";
            this.SearchStudentButton.UseVisualStyleBackColor = true;
            this.SearchStudentButton.Click += new System.EventHandler(this.SearchStudentButton_Click);
            // 
            // SearchAllStudentButton
            // 
            this.SearchAllStudentButton.Location = new System.Drawing.Point(289, 28);
            this.SearchAllStudentButton.Name = "SearchAllStudentButton";
            this.SearchAllStudentButton.Size = new System.Drawing.Size(75, 20);
            this.SearchAllStudentButton.TabIndex = 12;
            this.SearchAllStudentButton.Text = "AllStudent";
            this.SearchAllStudentButton.UseVisualStyleBackColor = true;
            this.SearchAllStudentButton.Click += new System.EventHandler(this.SearchAllStudentButton_Click);
            // 
            // SearchLecturerButton
            // 
            this.SearchLecturerButton.Location = new System.Drawing.Point(370, 28);
            this.SearchLecturerButton.Name = "SearchLecturerButton";
            this.SearchLecturerButton.Size = new System.Drawing.Size(75, 20);
            this.SearchLecturerButton.TabIndex = 13;
            this.SearchLecturerButton.Text = "SearchLecturer";
            this.SearchLecturerButton.UseVisualStyleBackColor = true;
            this.SearchLecturerButton.Click += new System.EventHandler(this.SearchLecturerButton_Click);
            // 
            // SearchAllLecturerButton
            // 
            this.SearchAllLecturerButton.Location = new System.Drawing.Point(451, 28);
            this.SearchAllLecturerButton.Name = "SearchAllLecturerButton";
            this.SearchAllLecturerButton.Size = new System.Drawing.Size(75, 20);
            this.SearchAllLecturerButton.TabIndex = 14;
            this.SearchAllLecturerButton.Text = "AllLecturer";
            this.SearchAllLecturerButton.UseVisualStyleBackColor = true;
            this.SearchAllLecturerButton.Click += new System.EventHandler(this.SearchAllLecturerButton_Click);
            // 
            // SearchSpecificButton
            // 
            this.SearchSpecificButton.Location = new System.Drawing.Point(208, 398);
            this.SearchSpecificButton.Name = "SearchSpecificButton";
            this.SearchSpecificButton.Size = new System.Drawing.Size(75, 20);
            this.SearchSpecificButton.TabIndex = 15;
            this.SearchSpecificButton.Text = "SearchBook";
            this.SearchSpecificButton.UseVisualStyleBackColor = true;
            this.SearchSpecificButton.Click += new System.EventHandler(this.SearchSpecificButton_Click);
            // 
            // SearchAuthorsTextBox
            // 
            this.SearchAuthorsTextBox.Location = new System.Drawing.Point(67, 398);
            this.SearchAuthorsTextBox.Name = "SearchAuthorsTextBox";
            this.SearchAuthorsTextBox.Size = new System.Drawing.Size(123, 20);
            this.SearchAuthorsTextBox.TabIndex = 16;
            // 
            // SearchBookLabel
            // 
            this.SearchBookLabel.AutoSize = true;
            this.SearchBookLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBookLabel.Location = new System.Drawing.Point(8, 395);
            this.SearchBookLabel.Name = "SearchBookLabel";
            this.SearchBookLabel.Size = new System.Drawing.Size(55, 21);
            this.SearchBookLabel.TabIndex = 17;
            this.SearchBookLabel.Text = "Book:";
            // 
            // SearchAllButton
            // 
            this.SearchAllButton.Location = new System.Drawing.Point(306, 398);
            this.SearchAllButton.Name = "SearchAllButton";
            this.SearchAllButton.Size = new System.Drawing.Size(75, 20);
            this.SearchAllButton.TabIndex = 18;
            this.SearchAllButton.Text = "AllBook";
            this.SearchAllButton.UseVisualStyleBackColor = true;
            this.SearchAllButton.Click += new System.EventHandler(this.SearchAllButton_Click);
            // 
            // NameVisitorLabel
            // 
            this.NameVisitorLabel.AutoSize = true;
            this.NameVisitorLabel.Location = new System.Drawing.Point(646, 128);
            this.NameVisitorLabel.Name = "NameVisitorLabel";
            this.NameVisitorLabel.Size = new System.Drawing.Size(35, 13);
            this.NameVisitorLabel.TabIndex = 19;
            this.NameVisitorLabel.Text = "Name";
            // 
            // SurnameVisitorLabel
            // 
            this.SurnameVisitorLabel.AutoSize = true;
            this.SurnameVisitorLabel.Location = new System.Drawing.Point(579, 128);
            this.SurnameVisitorLabel.Name = "SurnameVisitorLabel";
            this.SurnameVisitorLabel.Size = new System.Drawing.Size(49, 13);
            this.SurnameVisitorLabel.TabIndex = 20;
            this.SurnameVisitorLabel.Text = "Surname";
            // 
            // PatronymicVisitorLabel
            // 
            this.PatronymicVisitorLabel.AutoSize = true;
            this.PatronymicVisitorLabel.Location = new System.Drawing.Point(703, 128);
            this.PatronymicVisitorLabel.Name = "PatronymicVisitorLabel";
            this.PatronymicVisitorLabel.Size = new System.Drawing.Size(59, 13);
            this.PatronymicVisitorLabel.TabIndex = 21;
            this.PatronymicVisitorLabel.Text = "Patronymic";
            // 
            // PatronymicStaffLabel
            // 
            this.PatronymicStaffLabel.AutoSize = true;
            this.PatronymicStaffLabel.Location = new System.Drawing.Point(703, 361);
            this.PatronymicStaffLabel.Name = "PatronymicStaffLabel";
            this.PatronymicStaffLabel.Size = new System.Drawing.Size(59, 13);
            this.PatronymicStaffLabel.TabIndex = 24;
            this.PatronymicStaffLabel.Text = "Patronymic";
            // 
            // SurnameStaffLabel
            // 
            this.SurnameStaffLabel.AutoSize = true;
            this.SurnameStaffLabel.Location = new System.Drawing.Point(579, 361);
            this.SurnameStaffLabel.Name = "SurnameStaffLabel";
            this.SurnameStaffLabel.Size = new System.Drawing.Size(49, 13);
            this.SurnameStaffLabel.TabIndex = 23;
            this.SurnameStaffLabel.Text = "Surname";
            // 
            // NameStaffLabel
            // 
            this.NameStaffLabel.AutoSize = true;
            this.NameStaffLabel.Location = new System.Drawing.Point(646, 361);
            this.NameStaffLabel.Name = "NameStaffLabel";
            this.NameStaffLabel.Size = new System.Drawing.Size(35, 13);
            this.NameStaffLabel.TabIndex = 22;
            this.NameStaffLabel.Text = "Name";
            // 
            // StaticStaffLabel
            // 
            this.StaticStaffLabel.AutoSize = true;
            this.StaticStaffLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StaticStaffLabel.Location = new System.Drawing.Point(535, 327);
            this.StaticStaffLabel.Name = "StaticStaffLabel";
            this.StaticStaffLabel.Size = new System.Drawing.Size(46, 21);
            this.StaticStaffLabel.TabIndex = 28;
            this.StaticStaffLabel.Text = "Staff";
            // 
            // BookLabel
            // 
            this.BookLabel.AutoSize = true;
            this.BookLabel.Location = new System.Drawing.Point(579, 198);
            this.BookLabel.Name = "BookLabel";
            this.BookLabel.Size = new System.Drawing.Size(32, 13);
            this.BookLabel.TabIndex = 31;
            this.BookLabel.Text = "Book";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(703, 198);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(38, 13);
            this.AuthorLabel.TabIndex = 32;
            this.AuthorLabel.Text = "Author";
            // 
            // DateOfTakingTheBookTimePicker1
            // 
            this.DateOfTakingTheBookTimePicker1.Location = new System.Drawing.Point(681, 230);
            this.DateOfTakingTheBookTimePicker1.Name = "DateOfTakingTheBookTimePicker1";
            this.DateOfTakingTheBookTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.DateOfTakingTheBookTimePicker1.TabIndex = 33;
            // 
            // BookDeliveryDateTimePicker2
            // 
            this.BookDeliveryDateTimePicker2.Location = new System.Drawing.Point(649, 275);
            this.BookDeliveryDateTimePicker2.Name = "BookDeliveryDateTimePicker2";
            this.BookDeliveryDateTimePicker2.Size = new System.Drawing.Size(128, 20);
            this.BookDeliveryDateTimePicker2.TabIndex = 34;
            // 
            // GroupOrFacultyLabel
            // 
            this.GroupOrFacultyLabel.AutoSize = true;
            this.GroupOrFacultyLabel.Location = new System.Drawing.Point(620, 166);
            this.GroupOrFacultyLabel.Name = "GroupOrFacultyLabel";
            this.GroupOrFacultyLabel.Size = new System.Drawing.Size(81, 13);
            this.GroupOrFacultyLabel.TabIndex = 35;
            this.GroupOrFacultyLabel.Text = "GroupOrFaculty";
            // 
            // BookDeliveryDateLabel
            // 
            this.BookDeliveryDateLabel.AutoSize = true;
            this.BookDeliveryDateLabel.Location = new System.Drawing.Point(536, 282);
            this.BookDeliveryDateLabel.Name = "BookDeliveryDateLabel";
            this.BookDeliveryDateLabel.Size = new System.Drawing.Size(99, 13);
            this.BookDeliveryDateLabel.TabIndex = 77;
            this.BookDeliveryDateLabel.Text = "Book Delivery Date";
            // 
            // DateOfTakingTheBookLabel
            // 
            this.DateOfTakingTheBookLabel.AutoSize = true;
            this.DateOfTakingTheBookLabel.Location = new System.Drawing.Point(536, 237);
            this.DateOfTakingTheBookLabel.Name = "DateOfTakingTheBookLabel";
            this.DateOfTakingTheBookLabel.Size = new System.Drawing.Size(130, 13);
            this.DateOfTakingTheBookLabel.TabIndex = 76;
            this.DateOfTakingTheBookLabel.Text = "Date Of Taking The Book";
            // 
            // GiveABookButton
            // 
            this.GiveABookButton.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.GiveABookButton.Location = new System.Drawing.Point(536, 423);
            this.GiveABookButton.Name = "GiveABookButton";
            this.GiveABookButton.Size = new System.Drawing.Size(87, 47);
            this.GiveABookButton.TabIndex = 78;
            this.GiveABookButton.Text = "Give a book";
            this.GiveABookButton.UseVisualStyleBackColor = true;
            this.GiveABookButton.Click += new System.EventHandler(this.GiveABookButton_Click);
            // 
            // GiveTheBookButton
            // 
            this.GiveTheBookButton.Location = new System.Drawing.Point(681, 423);
            this.GiveTheBookButton.Name = "GiveTheBookButton";
            this.GiveTheBookButton.Size = new System.Drawing.Size(96, 47);
            this.GiveTheBookButton.TabIndex = 79;
            this.GiveTheBookButton.Text = "Get books";
            this.GiveTheBookButton.UseVisualStyleBackColor = true;
            this.GiveTheBookButton.Click += new System.EventHandler(this.GiveTheBookButton_Click);
            // 
            // VisitorLabel
            // 
            this.VisitorLabel.AutoSize = true;
            this.VisitorLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VisitorLabel.Location = new System.Drawing.Point(532, 95);
            this.VisitorLabel.Name = "VisitorLabel";
            this.VisitorLabel.Size = new System.Drawing.Size(59, 21);
            this.VisitorLabel.TabIndex = 30;
            this.VisitorLabel.Text = "Visitor";
            // 
            // StaffUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GiveTheBookButton);
            this.Controls.Add(this.GiveABookButton);
            this.Controls.Add(this.BookDeliveryDateLabel);
            this.Controls.Add(this.DateOfTakingTheBookLabel);
            this.Controls.Add(this.GroupOrFacultyLabel);
            this.Controls.Add(this.BookDeliveryDateTimePicker2);
            this.Controls.Add(this.DateOfTakingTheBookTimePicker1);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.BookLabel);
            this.Controls.Add(this.VisitorLabel);
            this.Controls.Add(this.StaticStaffLabel);
            this.Controls.Add(this.PatronymicStaffLabel);
            this.Controls.Add(this.SurnameStaffLabel);
            this.Controls.Add(this.NameStaffLabel);
            this.Controls.Add(this.PatronymicVisitorLabel);
            this.Controls.Add(this.SurnameVisitorLabel);
            this.Controls.Add(this.NameVisitorLabel);
            this.Controls.Add(this.SearchAllButton);
            this.Controls.Add(this.SearchBookLabel);
            this.Controls.Add(this.SearchAuthorsTextBox);
            this.Controls.Add(this.SearchSpecificButton);
            this.Controls.Add(this.SearchAllLecturerButton);
            this.Controls.Add(this.SearchLecturerButton);
            this.Controls.Add(this.SearchAllStudentButton);
            this.Controls.Add(this.SearchStudentButton);
            this.Controls.Add(this.SearchLabelVisitors);
            this.Controls.Add(this.SearchVisitorTextBox);
            this.Controls.Add(this.VisitorListBox);
            this.Controls.Add(this.BookListBox);
            this.Controls.Add(this.Stafflabel);
            this.Controls.Add(this.StaffComboBox);
            this.Controls.Add(this.VisitorCardListBox);
            this.Name = "StaffUC";
            this.Size = new System.Drawing.Size(803, 599);
            this.Load += new System.EventHandler(this.StaffUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox VisitorCardListBox;
        private System.Windows.Forms.ComboBox StaffComboBox;
        private System.Windows.Forms.Label Stafflabel;
        private System.Windows.Forms.ListBox BookListBox;
        private System.Windows.Forms.ListBox VisitorListBox;
        private System.Windows.Forms.TextBox SearchVisitorTextBox;
        private System.Windows.Forms.Label SearchLabelVisitors;
        private System.Windows.Forms.Button SearchStudentButton;
        private System.Windows.Forms.Button SearchAllStudentButton;
        private System.Windows.Forms.Button SearchLecturerButton;
        private System.Windows.Forms.Button SearchAllLecturerButton;
        private System.Windows.Forms.Button SearchSpecificButton;
        private System.Windows.Forms.TextBox SearchAuthorsTextBox;
        private System.Windows.Forms.Label SearchBookLabel;
        private System.Windows.Forms.Button SearchAllButton;
        private System.Windows.Forms.Label NameVisitorLabel;
        private System.Windows.Forms.Label SurnameVisitorLabel;
        private System.Windows.Forms.Label PatronymicVisitorLabel;
        private System.Windows.Forms.Label PatronymicStaffLabel;
        private System.Windows.Forms.Label SurnameStaffLabel;
        private System.Windows.Forms.Label NameStaffLabel;
        private System.Windows.Forms.Label StaticStaffLabel;
        private System.Windows.Forms.Label BookLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.DateTimePicker DateOfTakingTheBookTimePicker1;
        private System.Windows.Forms.DateTimePicker BookDeliveryDateTimePicker2;
        private System.Windows.Forms.Label GroupOrFacultyLabel;
        private System.Windows.Forms.Label BookDeliveryDateLabel;
        private System.Windows.Forms.Label DateOfTakingTheBookLabel;
        private System.Windows.Forms.Button GiveABookButton;
        private System.Windows.Forms.Button GiveTheBookButton;
        private System.Windows.Forms.Label VisitorLabel;
    }
}
