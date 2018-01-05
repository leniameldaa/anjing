using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maricoba
{

    public class ProductData
    {
        public int success { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public string product_name { get; set; }
        public string category { get; set; }
        public string brand { get; set; }
        public string price { get; set; }
        public string image { get; set; }
    }

}
