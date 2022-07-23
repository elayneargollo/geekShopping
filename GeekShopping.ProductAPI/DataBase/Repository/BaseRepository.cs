using GeekShopping.ProductApi.DataBase.Interface;
using GeekShopping.ProductAPI.Model.Base;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        private DbSet<T> dataset;

        public BaseRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public async Task<T> Add(T item)
        {
            try
            {
                dataset.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {

            return dataset.Any(b => b.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return dataset.ToList();
        }

        public T GetById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public async Task<T> Update(T item)
        {

            if (!Exists(item.Id)) return null;

            var result = dataset.SingleOrDefault(b => b.Id == item.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
            return result;
        }
    }
}