using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    public class Patient
    {
        private static int m_Counter = 0;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
  
        public Patient(string firstName, string lastName, string sex = null)
        {
            Id = System.Threading.Interlocked.Increment(ref m_Counter);
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

    }
}
