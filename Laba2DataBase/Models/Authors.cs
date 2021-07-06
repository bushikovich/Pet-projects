using System;
using System.Data;

namespace Laba2DataBase
{
    class Authors
    {
        public int ID { set; get; }
        public string Surname { set; get; }
        public string Name { set; get; }
        public string Patronymic { set; get; }
        public DateTime DateOfBirth { set; get; }

        public Authors()
        {

        }
        public Authors(int id, string surname, string name, string patronymic, DateTime dateOfBirth)
        {
            ID = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
        }
        public Authors(IDataReader reader)
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
