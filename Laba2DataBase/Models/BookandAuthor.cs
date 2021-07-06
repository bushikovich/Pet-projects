using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class BookandAuthor
    {
        public int ID { set; get; }
        public int Author { set; get; }
        public int Book { set; get; }
        public string Bookstring { set; get; }
        public string Authorstring { set; get; }
        public BookandAuthor()
        {

        }

        public BookandAuthor(int id, int author, int book)
        {
            ID = id;
            Book = book;
            Author = author;

        }
        public BookandAuthor(IDataReader reader)
        {
            ID = reader.GetInt32(0);

            Book = reader.GetInt32(1);

            Author = reader.GetInt32(2);
        }

        public override string ToString()
        {
            return $"{ID} {Bookstring} {Authorstring}";
        }
    }
}
