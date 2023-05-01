
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncProject.BLL
{
    public class UnitOfWork: IUnitOfWork
    {

        public ITransactionRepository TransactionRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }

        public UnitOfWork(ITransactionRepository TransactionRepository, ICategoryRepository CategoryRepository)
        {
            this.TransactionRepository = TransactionRepository;
            this.CategoryRepository = CategoryRepository;
        }
    }
}
