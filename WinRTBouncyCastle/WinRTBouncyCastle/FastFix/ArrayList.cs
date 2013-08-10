using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class ArrayList : List<object>
    {

        public ArrayList()
        {
        }

        public ArrayList(int capacity)
            : base(capacity)
        {
        }

        public ArrayList(IEnumerable<object> enumerable)
            : base(enumerable)
        {
        }

        public ArrayList(IEnumerable enumerable)
            : base()
        {
            foreach (var item in enumerable)
            {
                this.Add(item);
            }
        }
    }
}
