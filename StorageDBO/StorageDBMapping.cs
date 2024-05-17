using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using StorageDBO.Entities;

namespace StorageDBO
{
    public class StorageDBMapping : Profile
    {
        public StorageDBMapping() 
        {
            CreateMap<ChangeRecord, StorageDBContext>();
        }
    }
}
