using Shop.Business.Data.Contracts;
using Shop.Business.Repository.Contracts;
using Shop.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Repository
{
    class StorageRecordRepository: Repository<IStorageRecordBusiness>, IStorageRecordRepository
    {
    }
}
