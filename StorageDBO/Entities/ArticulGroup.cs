using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDBO.Entities
{
    public class ArticulGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Articul> Articuls { get; set; }

        public ArticulGroup() { Articuls = new List<Articul>(); }
    }
}
