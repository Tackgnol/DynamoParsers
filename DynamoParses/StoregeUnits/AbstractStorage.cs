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
        public string AdditionalInfo { get; set; }

        protected AbstractStorage()
        {
            _elements = new List<string>();
        }

        public void AddElement(string element)
        {
            if (_validateLine(element))
                _elements.Add(element);
        }

        protected virtual bool _validateLine(string element)
        {
            return true;
        }
    }
}
