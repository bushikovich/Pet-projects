using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class LecturerCard
    {
        public int ID { set; get; }
        public int LibraryStaff { set; get; }
        public int Lecturer { set; get; }
        public int Book { set; get; }
        public bool BookDelivery { set; get; }
        public DateTime DateOfTakingTheBook { set; get; }
        public DateTime BookDeliveryDate { set; get; }

        public string LibraryStaffstring { set; get; }
        public string Lecturerstring { set; get; }
        public string Bookstring { set; get; }

        public LecturerCard()
        {

        }

        public LecturerCard(int id, int librarystaff, int lecturer, int book, bool bookdelivery, int year, int month, int day)
        {
            ID = id;
            LibraryStaff = librarystaff;
            Lecturer = lecturer;
            Book = book;
            BookDelivery = bookdelivery;
            DateOfTakingTheBook.AddYears(year);
            DateOfTakingTheBook.AddDays(day);
            DateOfTakingTheBook.AddMonths(month);
        }
        public LecturerCard(IDataReader reader)
        {
            ID = reader.GetInt32(0);
            LibraryStaff = reader.GetInt32(1);
            Lecturer = reader.GetInt32(2);
            Book = reader.GetInt32(3);
            BookDelivery = reader.GetBoolean(4);
            DateOfTakingTheBook = reader.GetDateTime(5);
            BookDeliveryDate = reader.GetDateTime(5);
        }

        public override string ToString()
        {
            string bookDelivery  = "not handed over";
            if (BookDelivery)
                bookDelivery = "handed over";
            return $"{ID} {LibraryStaffstring} {Lecturerstring} {Bookstring} {DateOfTakingTheBook.ToShortDateString()} {bookDelivery} {BookDeliveryDate.ToShortDateString()} ";
        }

    }
}
