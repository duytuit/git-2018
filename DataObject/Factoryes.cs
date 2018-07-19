using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
   public class Factoryes
    {
        public static IDaoFactory GetFactory(string dataProvider)
        {
            switch (dataProvider.ToLower())
            {
                case "entityframework": return new DaoFactory();

                default: return new DaoFactory();
            }
        }
    }
}
