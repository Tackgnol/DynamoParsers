using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class Header
    {
        private static int m_Counter = 0;
        public int Id { get; set; }
        public Patient Person {get; set;}
        public int PersonId
        {
            get
            {
                return Person.Id;
            }
        }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public bool Oczy { get; set; }
        public bool Buty { get; set; }
        public int NumerProby { get; set; }
        public Header(Patient person, DateTime date, string title)
        {
            // ToDo: Implement Oczy, Buty & numer from filename
            Id = System.Threading.Interlocked.Increment(ref m_Counter);
            Person = person;
            Date = date;
            Title = title;
        }
    }

}
