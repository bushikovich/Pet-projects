using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class Publishers
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }

        public Publishers()
        {

        }

        public Publishers(int id, string name, string address)
        {
            ID = id;
            Name = name;
            Address = address;

        }
        public Publishers(IDataReader reader)
        {
            ID = reader.GetInt32(0);
            Name = reader.GetString(1);
            Address = reader.GetString(2);

        }
        public override string ToString()
        {
            return $"{ID} {Name} {Address}";
        }
    }
}
