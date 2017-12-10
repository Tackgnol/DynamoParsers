using DynamoParses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParses.StoregeUnits
{
    public class ContactTimeStorage : AbstractStorage
    {
        public ContactTimeStorage() : base(){ }

        public List<ContactTime> ParseElements()
        {
            throw new NotImplementedException();
        }
    }
}
