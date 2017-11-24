using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.Models
{
    enum Sex
    {
        male,
        female
    }
    class DynamicReading
    {
        public string Name { get; set; }
        public Sex Sex { get; set; }


    }
}
