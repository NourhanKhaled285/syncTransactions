using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncProject.DAL;

namespace SyncProject.BLL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TransactionDatabaseContext context;

        public GenericRepository(TransactionDatabaseContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(T item)
        {
            await context.Set<T>().AddAsync(item);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(T item)
        {
            context.Set<T>().Remove(item);
            return await context.SaveChangesAsync();
        }

        public async Task<T> Get(int? id)
            => await context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll()
            => await context.Set<T>().ToListAsync();


        public async Task<int> Update(T item)
        {
            context.Set<T>().Update(item);
            return await context.SaveChangesAsync();
        }
    }
}
