using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class Lecturer
    {
        public int ID { set; get; }
        public string Surname { set; get; }
        public string Name { set; get; }
        public string Patronymic { set; get; }
        public DateTime DateOfBirth { set; get; }
        public int Faculty { set; get; }

        public string Facultystring { set; get; }

        public Lecturer()
        {

        }

        public Lecturer(int id, string surname, string name, string patronymic, int year, int month, int day, int faculty)
        {
            ID = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Faculty = faculty;
            DateOfBirth.AddYears(year);
            DateOfBirth.AddDays(day);
            DateOfBirth.AddMonths(month);
        }

        public Lecturer(IDataReader reader)
        {
            ID = reader.GetInt32(0);
            Surname = reader.GetString(1);
            Name = reader.GetString(2);
            Patronymic = reader.GetString(3);
            DateOfBirth = reader.GetDateTime(4);
            Faculty = reader.GetInt32(5);

        }

        public override string ToString()
        {
            return $"{ID} {Surname} {Name} {Patronymic} {DateOfBirth.ToShortDateString()} {Facultystring}";
        }

    }
}
