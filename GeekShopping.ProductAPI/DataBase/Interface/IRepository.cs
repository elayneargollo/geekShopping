using GeekShopping.ProductAPI.Model.Base;

namespace GeekShopping.ProductApi.DataBase.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T item);
        T GetById(long id);
        IEnumerable<T> GetAll();
        Task<T> Update(T item);
        void Delete(long id);
        bool Exists(long? id);
    }
}