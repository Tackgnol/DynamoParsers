using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class Header
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Date { get; set; }
        public string Sex { get; set; }
        public Header(string firstName,string lastName, string date, string sex)
        {
            Firstname = firstName;
            Lastname = lastName;
            Date = DateTime.ParseExact(date, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Sex = sex;
        }
    }

}
