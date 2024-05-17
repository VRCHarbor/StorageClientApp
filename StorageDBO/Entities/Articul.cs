using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDBO.Entities
{
    public class Articul
    {
        public string ArticulSellerCode {get; set;}
        public string ArticulName { get; set;}
        public string? ArticulImage { get; set;}
        public ArticulGroup ArticulGroup { get; set; }
        public int? ArticulGroupID { get; set; }
        public Articul() { }
    }
}
