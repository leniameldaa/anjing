using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace maricoba
{

    [DataContract]
    public class Register
    {
        [DataMember]
        public int success { get; set; }
        [DataMember]
        public string message { get; set; }
    }


}
