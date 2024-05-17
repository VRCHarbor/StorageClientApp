using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDBO.Entities
{
    public class ArticulCountInRecord
    {

        public int RecordId {  get; set; }
        public string ArticulID { get; set; }
        public Articul Articul { get; set; }
        public int Count { get; set; }


        public ChangeRecord Record { get; set; }

        public ArticulCountInRecord() { }
    }

    public class InRecordCount : ArticulCountInRecord 
    {
    }

    public class OutRecordCount : ArticulCountInRecord 
    {
    }
}
