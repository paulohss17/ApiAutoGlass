using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAutoGlass.Model
{
    public class Produto
    {
        public int idprod { get; set; }

        public string nomeprod { get; set; }

        public string status { get; set; }
        public string datafab { get; set; }

        public string dataval { get; set; }
        
        public int forn_idforn { get; set; }
    }
}
