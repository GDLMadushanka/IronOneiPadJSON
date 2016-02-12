using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallAPI
{
    public class Header
    {
        public List<Object> HeaderData { get; set; }

        public Header()
        {
            HeaderData = new List<Object>();
        }
        public int GetHeaderLength()
        {
            if (HeaderData != null)
            {
                return HeaderData.Count;
            }
            else { return 0; }
        }
    }
}
