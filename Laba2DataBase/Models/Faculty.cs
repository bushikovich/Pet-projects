using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class Faculty
    {
        public int ID { set; get; }
        public string Name { set; get; }

        public Faculty()
        {

        }

        public Faculty(int id, string name)
        {
            ID = id;
            Name = name;

        }
        public Faculty(IDataReader reader)
        {
            ID = reader.GetInt32(0);
            Name = reader.GetString(1);

        }

        public override string ToString()
        {
            return $"{ID} {Name}";
        }

    }
}
