using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class StudentsCard
    {
        public int ID { set; get; }
        public int LibraryStaff { set; get; }
        public int Student { set; get; }
        public int Book { set; get; }
        public bool BookDelivery { set; get; }
        public DateTime DateOfTakingTheBook { set; get; }
        public DateTime BookDeliveryDate { set; get; }

        public string LibraryStaffstring { set; get; }
        public string Studentstring { set; get; }
        public string Bookstring { set; get; }

        public StudentsCard(int id, int librarystaff, int student, int book, bool bookdelivery, int year, int month, int day)
        {
            ID = id;
            LibraryStaff = librarystaff;
            Student = student;
            Book = book;
            BookDelivery = bookdelivery;
            DateOfTakingTheBook.AddYears(year);
            DateOfTakingTheBook.AddDays(day);
            DateOfTakingTheBook.AddMonths(month);
        }
        public StudentsCard(IDataReader reader)
        {
            ID = reader.GetInt32(0);
            LibraryStaff = reader.GetInt32(1);
            Student = reader.GetInt32(2);
            Book = reader.GetInt32(3);
            BookDelivery = reader.GetBoolean(4);
            DateOfTakingTheBook = reader.GetDateTime(5);
            BookDeliveryDate = reader.GetDateTime(6);
        }
        public StudentsCard()
        {

        }

        public override string ToString()
        {
            string bookDelivery = "not handed over";
            if (BookDelivery)
                bookDelivery = "handed over";
            return $"{ID} {LibraryStaffstring} {Studentstring} {Bookstring} {DateOfTakingTheBook.ToShortDateString()} {bookDelivery} {BookDeliveryDate.ToShortDateString()}";
        }
    }
}
