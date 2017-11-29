using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    public class AbstractStorage
    {
        protected List<string> _elements;

        protected AbstractStorage()
        {
            _elements = new List<string>();
        }

        public void AddElement(string element)
        {
            _elements.Add(element);
        }
    }
}
