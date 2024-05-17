using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDBO.Entities
{
    public class ChangeRecord
    {

        public int Id { get; set; }
        public DateOnly ChangeDate { get; set; }
        
        public List<ArticulCountInRecord> Records { get; set; }
        public ChangeRecord() { }
    }

    public class InRecord : ChangeRecord 
    {
        public List<InRecordCount> Records { get => (List<InRecordCount>)base.Records; set => base.Records = value; }

    }

    public class OutRecord : ChangeRecord 
    {
    }
}
