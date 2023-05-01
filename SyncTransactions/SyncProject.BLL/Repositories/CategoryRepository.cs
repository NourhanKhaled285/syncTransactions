using SyncProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncProject.BLL
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly TransactionDatabaseContext context;

        public CategoryRepository(TransactionDatabaseContext context):base(context)
        {
            this.context = context;

        }
    
    }
}
