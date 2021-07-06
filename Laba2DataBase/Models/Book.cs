using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2DataBase.Models
{
    class Book
    { 
        public int ID { set; get; }
        public string Name { set; get; }
        public int Publisher { set; get; }
        public string Publisherstring { set; get; }
        public DateTime PublishingYear { set; get; }

        public Book()
        {

        }
        public Book(string name,int publisher,DateTime publishingYear)
        {
            Name = name;
            Publisher = publisher;
            PublishingYear = publishingYear;      
        }
        public Book(IDataReader reader)
        {
            ID = reader.GetInt32(0);
            Name = reader.GetString(1);
            Publisher = reader.GetInt32(3);
            PublishingYear = reader.GetDateTime(2);
        }
        public override string ToString()
        {
            return $"{ID} {Publisherstring} {Name} {PublishingYear.ToShortDateString()}";
        }

    }
}
