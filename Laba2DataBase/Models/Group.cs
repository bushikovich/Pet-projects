using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class Group
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int Faculty { set; get; }
        public string Facultystring { set; get; }
        public Group()
        {

        }

        public Group(int id, string name, int faculty)
        {
            ID = id;
            Name = name;
            Faculty = faculty;

        }
        public Group(IDataReader reader)
        {
            ID = reader.GetInt32(0);

            Name = reader.GetString(1);

            Faculty = reader.GetInt32(2);
        }
        public override string ToString()
        {
            return $"{ID} {Name} {Facultystring}";
        }

    }
}
