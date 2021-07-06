using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class LibraryStaff
    {
        public int ID { set; get; }
        public string Surname { set; get; }
        public string Name { set; get; }
        public string Patronymic { set; get; }
        public DateTime DateOfBirth { set; get; }

        public LibraryStaff()
        {

        }

        public LibraryStaff(int id, string surname, string name, string patronymic, int year, int month, int day)
        {
            ID = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth.AddYears(year);
            DateOfBirth.AddDays(day);
            DateOfBirth.AddMonths(month);
        }
        public LibraryStaff(IDataReader reader)
        {
            ID = reader.GetInt32(0);
            Surname = reader.GetString(1);
            Name = reader.GetString(2);
            Patronymic = reader.GetString(3);
            DateOfBirth = reader.GetDateTime(4);

        }

        public override string ToString()
        {
            return $"{ID} {Surname} {Name} {Patronymic} {DateOfBirth.ToShortDateString()}";
        }
    }
}
