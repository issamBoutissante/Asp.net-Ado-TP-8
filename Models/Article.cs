using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.net_MVC_TP_8
{
    public class Article
    {
        public int Num_Art { get; set; }
        public string Desig_Art { get; set; }
        public decimal PU_Art { get; set; }
        public int QttEnStock { get; set; }
        public int SeuilMin { get; set; }
        public int SeuilMax { get; set; }
    }
}