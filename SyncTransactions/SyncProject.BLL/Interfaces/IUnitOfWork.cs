using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SyncProject.BLL
{
    public interface IUnitOfWork
    {
        public ITransactionRepository TransactionRepository{ get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
    }
}
