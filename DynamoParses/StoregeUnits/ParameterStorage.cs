using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    public class ParameterStorage : AbstractStorage
    {
        public ParameterStorage() : base(){ }

        public List<Parameter> ParseElements()
        {
            throw new NotImplementedException();
        }
    }
}
